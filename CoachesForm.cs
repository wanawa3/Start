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
    public partial class CoachesForm : Form
    {
        private string dbPath = Path.Combine(Application.StartupPath, "start.db");

        public CoachesForm()
        {
            InitializeComponent();
            LoadCoaches();
        }

        private void LoadCoaches()
        {
            dgvCoaches.Columns.Clear();
            dgvCoaches.Columns.Add("Id", "ID");
            dgvCoaches.Columns.Add("FullName", "ФИО");
            dgvCoaches.Columns.Add("SportType", "Вид спорта");
            dgvCoaches.Columns["Id"].Visible = false;

            dgvCoaches.Rows.Clear();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM Coaches ORDER BY FullName", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvCoaches.Rows.Add(
                            reader["Id"],
                            reader["FullName"],
                            reader["SportType"]
                        );
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || string.IsNullOrWhiteSpace(cmbSportType.Text))
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    if (btnAdd.Tag == null) 
                    {
                        using (var cmd = new SQLiteCommand(
                            "INSERT INTO Coaches (FullName, SportType) VALUES (@name, @sport)", conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@sport", cmbSportType.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else 
                    {
                        int id = (int)btnAdd.Tag;
                        using (var cmd = new SQLiteCommand(
                            "UPDATE Coaches SET FullName = @name, SportType = @sport WHERE Id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@sport", cmbSportType.Text);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        btnAdd.Tag = null;
                        btnAdd.Text = "➕ Добавить";
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }

                txtFullName.Clear();
                cmbSportType.SelectedIndex = -1;
                LoadCoaches();
                MessageBox.Show(btnAdd.Tag == null ? "Тренер добавлен!" : "Данные обновлены!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCoaches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тренера!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить тренера?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var id = Convert.ToInt32(dgvCoaches.SelectedRows[0].Cells["Id"].Value);
                    using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand("DELETE FROM Coaches WHERE Id = @id", conn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadCoaches();
                    MessageBox.Show("Тренер удалён!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCoaches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите тренера!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvCoaches.SelectedRows[0];
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            cmbSportType.Text = row.Cells["SportType"].Value.ToString();

            btnAdd.Text = "Сохранить";
            btnAdd.Tag = Convert.ToInt32(row.Cells["Id"].Value);
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
    }
}