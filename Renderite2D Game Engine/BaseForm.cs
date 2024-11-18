using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class BaseForm : Form
    {
        protected bool IsClosingForms { get; private set; }
        protected bool replaceForm = true;

        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            LoadForm();
            if (this is not Home)
                WinFormController.startingForm?.Hide();
        }

        public void CloseAndGoToPreviousForm()
        {
            if (WinFormController.previouslyOpenForm != null)
            {
                IsClosingForms = true;
                WinFormController.currentlyOpenForm?.Close();
                IsClosingForms = false;
                WinFormController.previouslyOpenForm?.Show();
                WinFormController.previouslyOpenForm?.LoadForm();
            }
        }

        public void CloseAndGoHome()
        {
            if (WinFormController.startingForm != null)
            {
                IsClosingForms = true;
                WinFormController.currentlyOpenForm?.Close();
                IsClosingForms = false;
                WinFormController.startingForm.Show();
                WinFormController.startingForm?.LoadForm();
            }
        }

        public void LoadForm()
        {
            if (replaceForm)
            {
                WinFormController.currentlyOpenForm?.Hide();
                if (WinFormController.currentlyOpenForm != null)
                    WinFormController.previouslyOpenForm = WinFormController.currentlyOpenForm;
                WinFormController.currentlyOpenForm = this;
            }
        }
    }
}
