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
    public partial class ReportsForm : Form
    {
        private string dbPath = Path.Combine(Application.StartupPath, "start.db");
        private Dictionary<string, int> childrenDict = new Dictionary<string, int>();//в списке показывает только фио ребенка
        public ReportsForm()
        {
            InitializeComponent();

            // настройка дат по умолчанию
            dtpFrom1.Value = dtpFrom2.Value = dtpFrom3.Value = DateTime.Today.AddMonths(-1);
            dtpTo1.Value = dtpTo2.Value = dtpTo3.Value = DateTime.Today;

            // загрузка списка детей для 3-го отчёта
            LoadChildren();
        }
        private void btnGenerate1_Click_1(object sender, EventArgs e)//прогульщики
        {
            dgvReport1.Columns.Clear();
            dgvReport1.Columns.Add("FullName", "ФИО ребёнка");
            dgvReport1.Columns.Add("Total", "Всего тренировок");
            dgvReport1.Columns.Add("Missed", "Пропущено");
            dgvReport1.Columns.Add("Percent", "% посещаемости");//4столбца для результатов

            string sql = @"
                SELECT 
                    s.FullName,
                    COUNT(a.Id) AS Total,
                    SUM(CASE WHEN a.Attended = 0 THEN 1 ELSE 0 END) AS Missed,
                    ROUND(AVG(CASE WHEN a.Attended = 1 THEN 100.0 ELSE 0 END), 1) AS Percent
                FROM Sportsmen s
                LEFT JOIN Attendances a ON s.Id = a.SportsmanId
                    AND a.TrainingDate BETWEEN @from AND @to
                GROUP BY s.Id, s.FullName
                HAVING Missed > 2
                ORDER BY Missed DESC";//запрос на тренеровки и % пропусков

            dgvReport1.Rows.Clear();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@from", dtpFrom1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", dtpTo1.Value.ToString("yyyy-MM-dd"));

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())// заполнение таблицы
                    {
                        dgvReport1.Rows.Add(
                            reader["FullName"],
                            reader["Total"],
                            reader["Missed"],
                            reader["Percent"] + "%"
                        );
                    }
                }
            }
        }

        private void btnGenerate2_Click_1(object sender, EventArgs e)//тренера
        {
            dgvReport2.Columns.Clear();
            dgvReport2.Columns.Add("CoachName", "Тренер");
            dgvReport2.Columns.Add("SportType", "Вид спорта");
            dgvReport2.Columns.Add("Total", "Занятий");
            dgvReport2.Columns.Add("Attended", "Посещено");
            dgvReport2.Columns.Add("Percent", "% посещаемости");

            string sql = @"
                SELECT 
                    c.FullName AS CoachName,
                    c.SportType,
                    COUNT(a.Id) AS Total,
                    SUM(CASE WHEN a.Attended = 1 THEN 1 ELSE 0 END) AS Attended,
                    CASE 
                        WHEN COUNT(a.Id) = 0 THEN 0
                        ELSE ROUND(SUM(CASE WHEN a.Attended = 1 THEN 100.0 ELSE 0 END) / COUNT(a.Id), 1)
                    END AS Percent
                FROM Coaches c
                LEFT JOIN Attendances a ON c.Id = a.CoachId
                    AND a.TrainingDate BETWEEN @from AND @to
                GROUP BY c.Id, c.FullName, c.SportType";//

            dgvReport2.Rows.Clear();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@from", dtpFrom2.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", dtpTo2.Value.ToString("yyyy-MM-dd"));

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvReport2.Rows.Add(
                            reader["CoachName"],
                            reader["SportType"],
                            reader["Total"],
                            reader["Attended"],
                            reader["Percent"] + "%"
                        );
                    }
                }
            }
        }
        private void LoadChildren()//загрузка списка детей
        {
            cmbChild.Items.Clear();
            childrenDict.Clear();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand("SELECT Id, FullName FROM Sportsmen ORDER BY FullName", conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                    {
                        string n = r["FullName"].ToString();
                        cmbChild.Items.Add(n);
                        childrenDict[n] = Convert.ToInt32(r["Id"]);
                    }
            }
            if (cmbChild.Items.Count > 0) cmbChild.SelectedIndex = 0;
        }
        private void btnGenerate3_Click_1(object sender, EventArgs e)//активность
        {
            if (cmbChild.SelectedItem == null) { MessageBox.Show("Выберите ребёнка!"); return; }
            //настройка таблицы результатов
            dgvReport3.Columns.Clear();
            dgvReport3.Columns.AddRange(new DataGridViewColumn[] {
        new DataGridViewTextBoxColumn { Name = "Date", HeaderText = "Дата" },
        new DataGridViewTextBoxColumn { Name = "CoachName", HeaderText = "Тренер" },
        new DataGridViewTextBoxColumn { Name = "SportType", HeaderText = "Вид спорта" },
        new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Статус" }
    });

            string fullName = cmbChild.SelectedItem.ToString();//получаем фио выбранного ребенка
            int childId = childrenDict[fullName];

            string sql = @"
        SELECT a.TrainingDate, c.FullName, c.SportType,
            CASE WHEN a.Attended = 1 THEN 'Был' ELSE 'Пропустил' END AS Status
        FROM Attendances a
        JOIN Coaches c ON a.CoachId = c.Id
        WHERE a.SportsmanId = @childId AND a.TrainingDate BETWEEN @from AND @to
        ORDER BY a.TrainingDate DESC";

            dgvReport3.Rows.Clear();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@childId", childId);
                cmd.Parameters.AddWithValue("@from", dtpFrom3.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@to", dtpTo3.Value.ToString("yyyy-MM-dd"));

                using (var r = cmd.ExecuteReader())//читает результаты
                    while (r.Read())
                        dgvReport3.Rows.Add(
                            DateTime.Parse(r["TrainingDate"].ToString()).ToString("dd.MM.yyyy"),//формируем датудля отображения
                            r["FullName"],
                            r["SportType"],
                            r["Status"]
                        );
            }
        }
    }
}