using System;
using System.Linq;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class MachineCardForm : Form
    {
        private int machineId;
        private RequestSystemFacade facade;

        public MachineCardForm(int machineId, RequestSystemFacade facade)
        {
            this.machineId = machineId;
            this.facade = facade;
            InitializeComponent();
            LoadMachineData();
            LoadRepairHistory();
        }

        private void LoadMachineData()
        {
            var machine = facade.GetMachine(machineId);
            if (machine != null)
            {
                lblModelValue.Text = machine.Model;
                lblSerialValue.Text = machine.SerialNumber;
                lblManufacturerValue.Text = machine.Manufacturer;
            }
            else
            {
                MessageBox.Show("Станок не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void LoadRepairHistory()
        {
            var allRequests = facade.GetAllRequests();
            var machineRequests = allRequests.Where(r => r.MachineId == machineId).ToList();

            dgvHistory.DataSource = null;
            dgvHistory.DataSource = machineRequests.Select(r => new
            {
                r.Id,
                r.Status,
                r.Description,
                r.CreatedAt
            }).ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}