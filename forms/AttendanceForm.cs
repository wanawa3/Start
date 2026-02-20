using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Start
{
    public partial class AttendanceForm : Form
    {
        private string dbPath = Path.Combine(Application.StartupPath, "start.db");
        private List<Coach> coaches = new List<Coach>();

        private class Coach
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public override string ToString() => FullName; 
        }

        public AttendanceForm()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadCoaches();
        }

        private void SetupDataGridView()
        {
            dgvAttendance.Columns.Clear();
            dgvAttendance.Columns.Add("Id", "ID");
            dgvAttendance.Columns.Add("FullName", "ФИО");
            dgvAttendance.Columns.Add("Birthday", "Дата рождения");
            dgvAttendance.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Attended",
                HeaderText = "Был на тренировке",
                Width = 150
            });
            dgvAttendance.Columns["Id"].Visible = false;
            dgvAttendance.Columns["Birthday"].Width = 120;
            dgvAttendance.AllowUserToAddRows = false;
        }

        private void LoadCoaches()//загрузка тренеров
        {
            coaches.Clear();
            cmbCoach.Items.Clear();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand("SELECT Id, FullName FROM Coaches ORDER BY FullName", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        coaches.Add(new Coach
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1)
                        });
                    }
                }
            }
            cmbCoach.Items.AddRange(coaches.ToArray());
            if (coaches.Count > 0) cmbCoach.SelectedIndex = 0;
        }

        private void LoadSportsmenForCoach()//дети
        {
            if (cmbCoach.SelectedIndex < 0) return;

            int coachId = coaches[cmbCoach.SelectedIndex].Id;
            string date = dtpDate.Value.ToString("yyyy-MM-dd");

            dgvAttendance.Rows.Clear();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand(@"
                SELECT s.Id, s.FullName, s.Birthday, COALESCE(a.Attended, 0)
                FROM Sportsmen s
                LEFT JOIN Attendances a 
                    ON s.Id = a.SportsmanId 
                    AND a.CoachId = @cid 
                    AND a.TrainingDate = @date
                ORDER BY s.FullName", conn))//берет всех детей из таблицы
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@cid", coachId);
                cmd.Parameters.AddWithValue("@date", date);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvAttendance.Rows.Add(
                            reader["Id"],
                            reader["FullName"],
                            DateTime.Parse(reader["Birthday"].ToString()).ToString("dd.MM.yyyy"),
                            reader.GetBoolean(3)
                        );
                    }
                }
            }
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (cmbCoach.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите тренера!");
                return;
            }

            int coachId = coaches[cmbCoach.SelectedIndex].Id;
            string date = dtpDate.Value.ToString("yyyy-MM-dd");

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                foreach (DataGridViewRow row in dgvAttendance.Rows)
                {
                    if (row.IsNewRow) continue;
                    int sportsmanId = Convert.ToInt32(row.Cells["Id"].Value);
                    bool attended = Convert.ToBoolean(row.Cells["Attended"].Value);

                    using (var cmd = new SQLiteCommand(
                        "REPLACE INTO Attendances (Id, SportsmanId, CoachId, TrainingDate, Attended) VALUES (NULL, @sid, @cid, @date, @att)", conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", sportsmanId);
                        cmd.Parameters.AddWithValue("@cid", coachId);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@att", attended ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Посещаемость сохранена!");
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadSportsmenForCoach();
        }

        private void cmbCoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSportsmenForCoach();
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}