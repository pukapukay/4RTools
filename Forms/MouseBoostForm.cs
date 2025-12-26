using System;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class MouseBoostForm : Form, IObserver
    {
        public MouseBoostForm(Subject subject)
        {
            InitializeComponent();
            subject.Attach(this);

            this.txtToggleKey.KeyDown += new System.Windows.Forms.KeyEventHandler(FormUtils.OnKeyDown);
            this.txtToggleKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtToggleKey.TextChanged += new EventHandler(this.onToggleKeyChange);
            this.numMoveSpeed.ValueChanged += new EventHandler(this.onMoveSpeedChange);
            this.chkEnabled.CheckedChanged += new EventHandler(this.onEnabledChange);
        }

        public void Update(ISubject subject)
        {
            switch ((subject as Subject).Message.code)
            {
                case MessageCode.PROFILE_CHANGED:
                    this.chkEnabled.Checked = ProfileSingleton.GetCurrent().MouseBoost.isEnabled;
                    this.txtToggleKey.Text = ProfileSingleton.GetCurrent().MouseBoost.toggleKey.ToString();
                    this.numMoveSpeed.Value = ProfileSingleton.GetCurrent().MouseBoost.moveSpeed;
                    break;
                case MessageCode.TURN_ON:
                    ProfileSingleton.GetCurrent().MouseBoost.Start();
                    break;
                case MessageCode.TURN_OFF:
                    ProfileSingleton.GetCurrent().MouseBoost.Stop();
                    break;
            }
        }

        private void onEnabledChange(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().MouseBoost.isEnabled = this.chkEnabled.Checked;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MouseBoost);
        }

        private void onToggleKeyChange(object sender, EventArgs e)
        {
            try
            {
                Key key = (Key)Enum.Parse(typeof(Key), txtToggleKey.Text.ToString());
                ProfileSingleton.GetCurrent().MouseBoost.toggleKey = key;
                ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MouseBoost);
            }
            catch { }
        }

        private void onMoveSpeedChange(object sender, EventArgs e)
        {
            ProfileSingleton.GetCurrent().MouseBoost.moveSpeed = (int)this.numMoveSpeed.Value;
            ProfileSingleton.SetConfiguration(ProfileSingleton.GetCurrent().MouseBoost);
        }
    }
}
