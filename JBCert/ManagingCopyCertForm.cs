using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JBCert
{
    public partial class ManagingCopyCertForm : Form
    {
        IManagingCopiedCertService managingCopiedCertService;
        IManagingCertService managingCertService;
        public ManagingCopyCertForm()
        {
            InitializeComponent();
            managingCopiedCertService = new ManagingCopiedCertService();
            managingCertService = new ManagingCertService();
        }

        private void ManagingCopyCertForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadCopiedCertList()
        {
            
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in CopiedCertDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = true;
            }
        }

        private void DeSelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in CopiedCertDataGridView.Rows)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)row.Cells[1];
                currentCheckBox.Value = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void DetailButton_Click(object sender, EventArgs e)
        {
            List<int> copiedCertIds = (from DataGridViewRow r in CopiedCertDataGridView.Rows
                                 where Convert.ToBoolean(r.Cells[1].Value) == true
                                 select Convert.ToInt32(r.Cells[0].Value)).ToList();
            if (copiedCertIds.Count == 1)
            {
                int copiedCertId = copiedCertIds.FirstOrDefault();
            }
            else if (copiedCertIds.Count == 0)
            {
                NotificationForm notificationForm = new NotificationForm("Chưa chọn văn bằng nào", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
            else
            {
                NotificationForm notificationForm = new NotificationForm("Chỉ được chọn 1 văn bằng để xem chi tiết", "Cảnh báo", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> copiedCertIds = (from DataGridViewRow r in CopiedCertDataGridView.Rows
                                           where Convert.ToBoolean(r.Cells[1]) == true
                                           select Convert.ToInt32(r.Cells[0])).ToList();
                ConfirmForm confirmForm = new ConfirmForm("Đồng ý xóa ?");
                confirmForm.ShowDialog();
                if (confirmForm.Result == DialogResult.Yes)
                {

                }
            }
            catch(Exception ex)
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Error);
                notificationForm.ShowDialog();
            }
        }
    }
}
