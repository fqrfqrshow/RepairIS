using System;
using System.Windows.Forms;
using RepairIS.Facades;

namespace RepairIS.Forms
{
    public partial class LoginForm : Form
    {
        private RequestSystemFacade facade;

        public LoginForm()
        {
            facade = new RequestSystemFacade();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userId;
            if (!int.TryParse(txtUserId.Text, out userId))
            {
                MessageBox.Show("Введите корректный ID пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = cmbRole.SelectedItem.ToString();

            if (role == "Заказчик")
            {
                ClientMainForm clientForm = new ClientMainForm(userId, facade);
                clientForm.Show();
                this.Hide();
            }
            else if (role == "Менеджер")
            {
                AllRequestsForm managerForm = new AllRequestsForm(facade);
                managerForm.Show();
                this.Hide();
            }
            else if (role == "Мастер")
            {
                MasterRequestsForm masterForm = new MasterRequestsForm(userId, facade);
                masterForm.Show();
                this.Hide();
            }
        }
    }
}