using System;
using System.Windows.Forms;

namespace Renderite2D_Game_Engine
{
    public partial class ProgressWindow : Form
    {
        public event Action<ProgressWindow> UpdateEvent;

        private readonly Timer timer = new Timer();

        public ProgressWindow()
        {
            InitializeComponent();

            timer.Interval = 1;
            timer.Tick += Timer_Tick;
        }

        ~ProgressWindow() => timer.Tick -= Timer_Tick;

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateEvent?.Invoke(this);
        }

        private void ProgressWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.Cancel;
        }

        public void Finish()
        {
            DialogResult = DialogResult.OK;
        }

        private void ProgressWindow_Shown(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
