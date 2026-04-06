using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using RepairIS.Models;
using RepairIS.Facades;

namespace RepairIS.Forms
{
    public partial class AddMasterForm : Form
    {
        private RequestSystemFacade facade;

        public AddMasterForm(RequestSystemFacade facade)
        {
            this.facade = facade;
            InitializeComponent();
            open();
        }

        // open(): void - как на диаграмме
        private void open()
        {
            showForm();
        }

        // showForm(): void - как на диаграмме (отображает форму)
        private void showForm()
        {
            this.Show();
        }

        // enterMasterData(): void - как на диаграмме (ввод данных в поля)
        private void enterMasterData()
        {
            // Пользователь вводит данные в текстовые поля
        }

        // save(): void - как на диаграмме
        private void save()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите ФИО мастера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон мастера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newMaster = new Master
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text
            };

            facade.SaveMaster(newMaster);

            MessageBox.Show($"Мастер {txtName.Text} успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}