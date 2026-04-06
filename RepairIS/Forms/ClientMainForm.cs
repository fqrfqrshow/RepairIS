using System;
using System.Windows.Forms;
using RepairIS.Facades;

namespace RepairIS.Forms
{
    public partial class ClientMainForm : Form
    {
        private int userId;
        private RequestSystemFacade facade;

        public ClientMainForm(int userId, RequestSystemFacade facade)
        {
            this.userId = userId;
            this.facade = facade;
            InitializeComponent();
            lblWelcome.Text = $"Добро пожаловать, пользователь {userId}!";
        }

        private void btnCreateRequest_Click(object sender, EventArgs e)
        {
            new CreateRequestForm(userId, facade).ShowDialog();
        }

        private void btnMyRequests_Click(object sender, EventArgs e)
        {
            new MyRequestsForm(userId, facade).ShowDialog();
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            new RequestStatusForm(userId, facade).ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }
    }
}