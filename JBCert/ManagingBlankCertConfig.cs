using Model;
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
    public partial class ManagingBlankCertConfig : Form
    {
        IManagingBlankCertConfigService managingBlankCertConfigService;
        IManagingBlankCertTypeService managingBlankCertTypeService;
        public ManagingBlankCertConfig()
        {
            InitializeComponent();
            managingBlankCertConfigService = new ManagingBlankCertConfigService();
            managingBlankCertTypeService = new ManagingBlankCertTypeService();
        }

        private void BlankCertConfigDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManagingBlankCertConfig_Load(object sender, EventArgs e)
        {
            try
            {
                // load blank cert config list
                LoadBlankCertConfig();

                // load blank cert type
                List<BlankCertTypeModel> blankCertTypeModels = managingBlankCertTypeService.GetAllBlankCertType();
                blankCertTypeModels.Add(new BlankCertTypeModel()
                {
                    Id = -1,
                    Name = "Tất cả"
                });
                BlankCertTypeComboBox.DataSource = blankCertTypeModels.OrderBy(x => x.Id).ToList();
                BlankCertTypeComboBox.ValueMember = "Id";
                BlankCertTypeComboBox.DisplayMember = "Name";

                // Load status isActived
                List<IsActiveModel> isActiveModels = new List<IsActiveModel>();
                isActiveModels.Add(new IsActiveModel()
                {
                    Id = -1,
                    Name = "Tất cả"
                });
                isActiveModels.Add(new IsActiveModel()
                {
                    Id = 0,
                    Name = "Chưa dùng"
                });
                isActiveModels.Add(new IsActiveModel()
                {
                    Id = 1,
                    Name = "Đang dùng"
                });

                IsActiveComboBox.DataSource = isActiveModels;
                IsActiveComboBox.DisplayMember = "Name";
                IsActiveComboBox.ValueMember = "Id";
            }
            catch(Exception ex)
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }

        private void LoadBlankCertConfig()
        {
            try
            {
                List<BlankCertConfigModel> blankCertConfigModels = managingBlankCertConfigService.GetAllBlankCertConfig();
                BlankCertConfigDataGridView.Rows.Clear();
                int i = 0;
                foreach (var blankCertConfigModel in blankCertConfigModels)
                {
                    BlankCertConfigDataGridView.Rows.Add
                    (
                        blankCertConfigModel.Id,
                        false,
                        i++,
                        blankCertConfigModel.BlankCertTypeName,
                        blankCertConfigModel.CreatedAt.ToString("dd/MM/yyyy"),
                        blankCertConfigModel.IsActive == true ? "Đang dùng" : "Không dùng"
                    );
                }
            }
            catch (Exception ex)
            {
                NotificationForm notificationForm = new NotificationForm(Common.Common.COMMON_ERORR, "Lỗi", MessageBoxIcon.Warning);
                notificationForm.ShowDialog();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddBlankCertConfigForm addBlankCertConfigForm = new AddBlankCertConfigForm();
            addBlankCertConfigForm.ShowDialog();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
