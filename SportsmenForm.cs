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
            dgvSportsmen.Columns.Add("Id", "ID");
            dgvSportsmen.Columns.Add("FullName", "ФИО");
            dgvSportsmen.Columns.Add("Birthday", "Дата рождения");
            dgvSportsmen.Columns.Add("ParentPhone", "Телефон родителя");
            dgvSportsmen.Columns["Id"].Visible = false;
            dgvSportsmen.Rows.Clear();

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Sportsmen ORDER BY FullName", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvSportsmen.Rows.Add(
                            reader["Id"],
                            reader["FullName"],
                            DateTime.Parse(reader["Birthday"].ToString()).ToString("dd.MM.yyyy"),
                            reader["ParentPhone"]
                        );
                    }
                }
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("ФИО обязательно!", "Ошибка");
                return;
            }

            try
            {
                bool isEdit = btnAdd.Tag != null;
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    string sql = isEdit ?
                        "UPDATE Sportsmen SET FullName=@n, Birthday=@b, ParentPhone=@p WHERE Id=@id" :
                        "INSERT INTO Sportsmen (FullName, Birthday, ParentPhone) VALUES (@n, @b, @p)";

                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@b", dtpBirthday.Value);
                        cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                        if (isEdit) cmd.Parameters.AddWithValue("@id", btnAdd.Tag);
                        cmd.ExecuteNonQuery();
                    }


                    if (isEdit)
                    {
                        btnAdd.Tag = null;
                        btnAdd.Text = "➕ Добавить";
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }

                    txtFullName.Clear();
                    dtpBirthday.Value = DateTime.Today;
                    txtPhone.Text = "";
                    LoadSportsmen();
                    MessageBox.Show(isEdit ? "Обновлено!" : "Добавлен!", "Готово");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvSportsmen.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите спортсмена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Удалить {dgvSportsmen.SelectedRows[0].Cells["FullName"].Value}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var id = Convert.ToInt32(dgvSportsmen.SelectedRows[0].Cells["Id"].Value);
                    using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand("DELETE FROM Sportsmen WHERE Id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadSportsmen();
                    MessageBox.Show("Спортсмен удалён!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSportsmen.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите спортсмена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var row = dgvSportsmen.SelectedRows[0];
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                dtpBirthday.Value = DateTime.ParseExact(row.Cells["Birthday"].Value.ToString(), "dd.MM.yyyy", null);
                txtPhone.Text = row.Cells["ParentPhone"].Value.ToString();

                btnAdd.Text = "💾 Сохранить";
                btnAdd.Tag = Convert.ToInt32(row.Cells["Id"].Value);
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}