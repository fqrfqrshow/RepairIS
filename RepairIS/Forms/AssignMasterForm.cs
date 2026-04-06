using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RepairIS.Facades;
using RepairIS.Models;

namespace RepairIS.Forms
{
    public partial class AssignMasterForm : Form
    {
        private int requestId;
        private RequestSystemFacade facade;
        private List<Master> masters;

        public AssignMasterForm(int requestId, RequestSystemFacade facade)
        {
            this.requestId = requestId;
            this.facade = facade;
            InitializeComponent();
            open();
        }

        // open(): void - как на диаграмме
        private void open()
        {
            showRequestInfo();
            showMasterList();
        }

        // showRequestInfo(): void - как на диаграмме
        private void showRequestInfo()
        {
            var request = facade.GetRequest(requestId);
            if (request != null)
            {
                lblRequestInfo.Text = $"Заявка №{requestId} | Статус: {request.Status}";
            }
        }

        // showMasterList(): void - как на диаграмме
        private void showMasterList()
        {
            masters = facade.GetMasters();
            cmbMasters.DisplayMember = "Name";
            cmbMasters.DataSource = masters;

            if (masters.Count == 0)
            {
                MessageBox.Show("Нет доступных мастеров. Сначала добавьте мастера!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // selectMaster(): Master - как на диаграмме
        private Master selectMaster()
        {
            return (Master)cmbMasters.SelectedItem;
        }

        // saveMaster(): void - как на диаграмме (сохраняет назначение)
        private void saveMaster()
        {
            if (selectMaster() == null)
            {
                MessageBox.Show("Выберите мастера!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            facade.AssignMaster(requestId, selectMaster().Id);
            MessageBox.Show($"Мастер {selectMaster().Name} назначен на заявку №{requestId}!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveMaster();
        }
    }
}