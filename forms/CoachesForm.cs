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
                using (var cmd = new SQLiteCommand("SELECT * FROM Coaches ORDER BY FullName", conn))//б
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
                return;//если фио пустое то ошибка
            }

            try//добавление
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();

                    if (btnAdd.Tag == null) //добавляем
                    {
                        using (var cmd = new SQLiteCommand(
                            "INSERT INTO Coaches (FullName, SportType) VALUES (@name, @sport)", conn))
                        {
                            cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@sport", cmbSportType.Text);//имя и спорт
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else //редактирование 
                    {
                        int id = (int)btnAdd.Tag;
                        using (var cmd = new SQLiteCommand(
                            "UPDATE Coaches SET FullName = @name, SportType = @sport WHERE Id = @id", conn))//запрос обновления данных
                        {
                            cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                            cmd.Parameters.AddWithValue("@sport", cmbSportType.Text);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                txtFullName.Clear();//очищает поля ввода
                cmbSportType.SelectedIndex = -1;//сброс спорта
                LoadCoaches();//перезагружает таблицу
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
                return;//если строка не выделена то ошибка
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
                        using (var cmd = new SQLiteCommand("DELETE FROM Coaches WHERE Id = @id", conn))//запрос на удаление
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

        private void btnEdit_Click(object sender, EventArgs e)//ред
        {
            if (dgvCoaches.SelectedRows.Count == 0)//выделена ли хоть одна строка
            {
                MessageBox.Show("Выберите тренера!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvCoaches.SelectedRows[0];
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            cmbSportType.Text = row.Cells["SportType"].Value.ToString();

            btnAdd.Text = "Сохранить";
            btnAdd.Tag = Convert.ToInt32(row.Cells["Id"].Value);
        }
    }
}