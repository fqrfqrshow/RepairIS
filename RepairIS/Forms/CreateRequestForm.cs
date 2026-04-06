using Newtonsoft.Json;
using RepairIS.Facades;
using RepairIS.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RepairIS.Forms
{
    public partial class CreateRequestForm : Form
    {
        private int userId;
        private RequestSystemFacade facade;
        private List<Machine> userMachines;

        public CreateRequestForm(int userId, RequestSystemFacade facade)
        {
            this.userId = userId;
            this.facade = facade;
            InitializeComponent();
            create(); // Метод из диаграммы
        }

        // create(): void - как на диаграмме
        private void create()
        {
            showUserMachines();
        }

        // showUserMachines(): void - как на диаграмме
        private void showUserMachines()
        {
            userMachines = facade.GetMachines(userId);
            cmbMachines.DisplayMember = "Model";
            cmbMachines.DataSource = userMachines;

            if (userMachines.Count == 0)
            {
                MessageBox.Show("У вас нет станков. Добавьте новый станок!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // selectMachine(): Machine - как на диаграмме
        private Machine selectMachine()
        {
            return (Machine)cmbMachines.SelectedItem;
        }

        // addNewMachine(): void - как на диаграмме
        private void addNewMachine()
        {
            Form newMachineForm = new Form();
            newMachineForm.Text = "Добавить новый станок";
            newMachineForm.Size = new System.Drawing.Size(450, 350);
            newMachineForm.StartPosition = FormStartPosition.CenterParent;

            Label lblModel = new Label() { Text = "Модель:", Location = new System.Drawing.Point(30, 30), Size = new System.Drawing.Size(100, 30) };
            TextBox txtModel = new TextBox() { Location = new System.Drawing.Point(140, 30), Size = new System.Drawing.Size(250, 30) };

            Label lblSerial = new Label() { Text = "Серийный номер:", Location = new System.Drawing.Point(30, 80), Size = new System.Drawing.Size(100, 30) };
            TextBox txtSerial = new TextBox() { Location = new System.Drawing.Point(140, 80), Size = new System.Drawing.Size(250, 30) };

            Label lblManufacturer = new Label() { Text = "Производитель:", Location = new System.Drawing.Point(30, 130), Size = new System.Drawing.Size(100, 30) };
            TextBox txtManufacturer = new TextBox() { Location = new System.Drawing.Point(140, 130), Size = new System.Drawing.Size(250, 30) };

            Button btnOk = new Button() { Text = "Сохранить", Location = new System.Drawing.Point(140, 200), Size = new System.Drawing.Size(150, 40), BackColor = System.Drawing.Color.LightGreen };
            btnOk.Click += (sender, args) =>
            {
                if (string.IsNullOrWhiteSpace(txtModel.Text))
                {
                    MessageBox.Show("Введите модель станка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Machine newMachine = new Machine
                {
                    Model = txtModel.Text,
                    SerialNumber = txtSerial.Text,
                    Manufacturer = txtManufacturer.Text,
                    OwnerId = userId
                };
                facade.SaveMachine(JsonConvert.SerializeObject(newMachine));
                newMachineForm.Close();
                showUserMachines();
                MessageBox.Show("Станок добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            newMachineForm.Controls.AddRange(new Control[] { lblModel, txtModel, lblSerial, txtSerial, lblManufacturer, txtManufacturer, btnOk });
            newMachineForm.ShowDialog();
        }

        // save(): void - как на диаграмме
        private void save()
        {
            if (selectMachine() == null)
            {
                MessageBox.Show("Выберите станок!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание проблемы!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContactPhone.Text))
            {
                MessageBox.Show("Введите контактные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newRequest = new Request
            {
                MachineId = selectMachine().Id,
                ClientId = userId,
                Status = "Ожидает обработки",
                Description = txtDescription.Text,
                ContactPhone = txtContactPhone.Text,
                InspectionMethod = rbSelfDelivery.Checked ? "сам привезёт" : "выезд мастера",
                CreatedAt = DateTime.Now
            };

            facade.CreateOrder(JsonConvert.SerializeObject(newRequest));

            MessageBox.Show("Заявка успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Обработчики событий (вызывают методы логики)
        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            addNewMachine();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}