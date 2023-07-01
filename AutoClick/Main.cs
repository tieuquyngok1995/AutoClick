using AutoClick.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClick
{
    public partial class Main : Form
    {
        KeyHook gloablKeyHook = new KeyHook();

        #region Event
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            settingInit();

            // Add event key
            gloablKeyHook.HookedKeys.Add(Keys.A);
            gloablKeyHook.HookedKeys.Add(Keys.B);
            gloablKeyHook.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gloablKeyHook.KeyUp += new KeyEventHandler(gkh_KeyUp);
        }

        private void txtNumCounter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumCounter_Click(object sender, EventArgs e)
        {
            this.txtNumCounter.SelectAll();
        }
        #endregion

        #region Setting
        private void settingInit()
        {
            // Setting combobox mouse
            Dictionary<int, string> dicData = new Dictionary<int, string>();
            dicData.Add(0, "Left");
            dicData.Add(1, "Right");
            cbMouse.DataSource = new BindingSource(dicData, null);
            cbMouse.DisplayMember = "Value";
            cbMouse.ValueMember = "Key";
            cbMouse.SelectedIndex = 0;

            // Setting combobox click
            dicData.Clear();
            dicData.Add(0, "Single");
            dicData.Add(1, "Double");
            cbClick.DataSource = new BindingSource(dicData, null);
            cbClick.DisplayMember = "Value";
            cbClick.ValueMember = "Key";
            cbClick.SelectedIndex = 0;

            // Setting combobox hotkey1
            dicData.Clear();
            dicData.Add(0, "None");
            dicData.Add(1, "Ctrl");
            dicData.Add(2, "Ctrl+Alt");
            cbHotkey1.DataSource = new BindingSource(dicData, null);
            cbHotkey1.DisplayMember = "Value";
            cbHotkey1.ValueMember = "Key";
            cbHotkey1.SelectedIndex = 0;

            // Setting combobox hotkey2
            dicData.Clear();
            dicData.Add(0, "F1");
            dicData.Add(1, "F2");
            dicData.Add(2, "F3");
            dicData.Add(3, "F4");
            dicData.Add(4, "F5");
            dicData.Add(5, "F6");
            dicData.Add(6, "F7");
            dicData.Add(7, "F8");
            dicData.Add(8, "F9");
            cbHotkey2.DataSource = new BindingSource(dicData, null);
            cbHotkey2.DisplayMember = "Value";
            cbHotkey2.ValueMember = "Key";
            cbHotkey2.SelectedIndex = 2;
        }
        #endregion


        void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            //listBox1.Items.Add("Up\t" + e.KeyCode.ToString());
            e.Handled = true;
        }

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            //listBox1.Items.Add("Down\t" + e.KeyCode.ToString());
            e.Handled = true;
        }
    }
}
