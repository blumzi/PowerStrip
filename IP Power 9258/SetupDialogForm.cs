using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.IPPower9258;

namespace ASCOM.IPPower9258
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        public SetupDialogForm()
        {
            Form form = this.FindForm();

            InitializeComponent();
            // Initialise current values of user settings from the ASCOM Profile 
            textIPAddress.Text = IPPower9258.Instance.ipAddress;
            chkTrace.Checked = Switch.traceState;
            for (int i = 0; i < 4; i++)
            {
                Control[] controls;

                controls = form.Controls.Find("switchName" + i.ToString(), true);
                if (controls != null)
                    controls[0].Text = IPPower9258.Instance.switchNames[i];

                controls = form.Controls.Find("switchDesc" + i.ToString(), true);
                if (controls != null)
                    controls[0].Text = IPPower9258.Instance.switchDescriptions[i];
            }
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here

            if (IPPower9258.ValidIPv4(textIPAddress.Text))
                IPPower9258.Instance.ipAddress = textIPAddress.Text;
            else {
                textIPAddress.Text = "";
            }
            Switch.traceState = chkTrace.Checked;

            Form form = FindForm();
            Control[] controls;
            for (int i = 0; i < 4; i++)
            {
                controls = form.Controls.Find("switchName" + i.ToString(), true);
                if (controls != null)
                    IPPower9258.Instance.switchNames[i] = controls[0].Text;
                controls = form.Controls.Find("switchDesc" + i.ToString(), true);
                if (controls != null)
                    IPPower9258.Instance.switchDescriptions[i] = controls[0].Text;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void switchName_TextChanged(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Name;
            int id = Int32.Parse(name.Substring(name.Length - 1));

            IPPower9258.Instance.switchNames[id] = ((TextBox)sender).Text;
        }

        private void switchDescription_TextChanged(object sender, EventArgs e)
        {
            string name = ((TextBox)sender).Name;
            int id = Int32.Parse(name.Substring(name.Length - 1));

            IPPower9258.Instance.switchNames[id] = ((TextBox)sender).Text;
        }

        private void textIPAddress_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = ((TextBox)sender);

            if (IPPower9258.ValidIPv4(tb.Text)) {
                IPPower9258.Instance.ipAddress = tb.Text;
            } else
            {
                tb.Text = "Invalid IP Address";
            }
        }

        private void textIPAddress_Validating(object sender, CancelEventArgs e)
        {
            string address = ((TextBox)sender).Text;

            if (! IPPower9258.ValidIPv4(address))
            {
                e.Cancel = true;
            }
        }
    }
}