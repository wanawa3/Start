using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Start
{
    public partial class SportsmenForm : Form
    {
        private string dbPath = Path.Combine(Application.StartupPath, "start.db");

        public SportsmenForm()
        {
            InitializeComponent();
            LoadSportsmen();
        }

        private void LoadSportsmen()
        {
            dgvSportsmen.Columns.Clear();
            dgvSportsmen.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "Id", Visible = false },
                new DataGridViewTextBoxColumn { Name = "FullName", HeaderText = "ФИО" },
                new DataGridViewTextBoxColumn { Name = "Birthday", HeaderText = "Дата рождения" },
                new DataGridViewTextBoxColumn { Name = "ParentPhone", HeaderText = "Телефон родителя" }
            });
            dgvSportsmen.Rows.Clear();

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand("SELECT * FROM Sportsmen ORDER BY FullName", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        dgvSportsmen.Rows.Add(
                            reader["Id"],
                            reader["FullName"],
                            DateTime.Parse(reader["Birthday"].ToString()).ToString("dd.MM.yyyy"),
                            reader["ParentPhone"]
                        );
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)//добавление
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text)) { MessageBox.Show("ФИО обязательно!"); return; }//если фмо нет, ошибка

            bool edit = btnAdd.Tag != null;
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            using (var cmd = new SQLiteCommand(edit ?
                "UPDATE Sportsmen SET FullName=@n, Birthday=@b, ParentPhone=@p WHERE Id=@id" :
                "INSERT INTO Sportsmen (FullName, Birthday, ParentPhone) VALUES (@n, @b, @p)", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                cmd.Parameters.AddWithValue("@b", dtpBirthday.Value);
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                if (edit) cmd.Parameters.AddWithValue("@id", btnAdd.Tag);
                cmd.ExecuteNonQuery();
            }

            if (edit)
            {
                btnAdd.Tag = null;
                btnAdd.Text = "Добавить";
                btnEdit.Enabled = btnDelete.Enabled = true;
            }

            txtFullName.Clear();
            dtpBirthday.Value = DateTime.Today;
            txtPhone.Clear();
            LoadSportsmen();
            MessageBox.Show(edit ? "Обновлено!" : "Добавлен!");
        }
        private void btnDelete_Click_1(object sender, EventArgs e)//удаление
        {
            if (dgvSportsmen.SelectedRows.Count == 0) { MessageBox.Show("Выберите спортсмена!"); return; }
            if (MessageBox.Show($"Удалить {dgvSportsmen.SelectedRows[0].Cells["FullName"].Value}?", "?",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            try
            {
                var id = Convert.ToInt32(dgvSportsmen.SelectedRows[0].Cells["Id"].Value);
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                using (var cmd = new SQLiteCommand("DELETE FROM Sportsmen WHERE Id=@id", conn))//запрос удаления
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                LoadSportsmen();
                MessageBox.Show("Удалён!");
            }
            catch (Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }
        private void btnEdit_Click(object sender, EventArgs e)//ред
        {
            if (dgvSportsmen.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите спортсмена!");
                return;
            }

            var r = dgvSportsmen.SelectedRows[0];
            txtFullName.Text = r.Cells["FullName"].Value.ToString();
            dtpBirthday.Value = DateTime.ParseExact(r.Cells["Birthday"].Value.ToString(), "dd.MM.yyyy", null);
            txtPhone.Text = r.Cells["ParentPhone"].Value.ToString();  

            btnAdd.Text = "Сохранить";
            btnAdd.Tag = Convert.ToInt32(r.Cells["Id"].Value);
            btnEdit.Enabled = btnDelete.Enabled = false;
        }
    }
}
