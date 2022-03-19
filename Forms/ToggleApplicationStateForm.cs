﻿using System;
using System.Drawing;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using _4RTools.Properties;

namespace _4RTools.Forms
{
    public partial class ToggleApplicationStateForm : Form, IObserver
    {
        private UserPreferences userPreferences = new UserPreferences();
        private Subject subject;
        public ToggleApplicationStateForm(Subject subject)
        {
            InitializeComponent();

            subject.Attach(this);
            this.subject = subject;

            KeyboardHook.Enable();
            KeyboardHook.Add(Keys.End, new KeyboardHook.KeyPressed(this.toggleStatus)); //Toggle System (ON-OFF)
            this.txtStatusToggleKey.Text = userPreferences.toggleStateKey;
            this.txtStatusToggleKey.KeyDown += new KeyEventHandler(FormUtils.OnKeyDown);
            this.txtStatusToggleKey.KeyPress += new KeyPressEventHandler(FormUtils.OnKeyPress);
            this.txtStatusToggleKey.TextChanged += new EventHandler(this.onStatusToggleKeyChange);
        }

        public void Update(ISubject subject)
        {
        }

        private void btnToggleStatusHandler(object sender, EventArgs e) { this.toggleStatus(); }

        private void onStatusToggleKeyChange(object sender, EventArgs e)
        {
            if (this.txtStatusToggleKey.Text != this.userPreferences.toggleStateKey)
            {
                Keys previousKey = (Keys)Enum.Parse(typeof(Keys), this.userPreferences.toggleStateKey);
                Keys newKey = (Keys)Enum.Parse(typeof(Keys), this.txtStatusToggleKey.Text);

                KeyboardHook.Remove(previousKey);
                KeyboardHook.Add(newKey, new KeyboardHook.KeyPressed(this.toggleStatus));
                this.userPreferences.toggleStateKey = this.txtStatusToggleKey.Text;
                ProfileSingleton.SetConfiguration(this.userPreferences);
            }
        }

        private bool toggleStatus()
        {
            bool isOn = this.btnStatusToggle.Text == "ON";
            Console.WriteLine("toggleStatus" + isOn);
            if (isOn)
            {
                this.btnStatusToggle.BackColor = Color.Red;
                this.btnStatusToggle.Text = "OFF";
                this.notifyIconTray.Icon = Resources.logo_4rtools_off;
                this.subject.Notify(new Utils.Message(MessageCode.TURN_OFF, null));
            }
            else
            {
                this.btnStatusToggle.BackColor = Color.Green;
                this.btnStatusToggle.Text = "ON";
                this.notifyIconTray.Icon = Resources.logo_4rtools_on;
                this.subject.Notify(new Utils.Message(MessageCode.TURN_ON, null));
            }

            return true;
        }
    }
}