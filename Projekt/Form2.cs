using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace Projekt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            var driveList = System.IO.DriveInfo.GetDrives().ToList();
            this.comboBox1.DataSource = driveList;

            
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {

 
           Properties.Settings.Default.Laufwerk = comboBox1.Text;
           Properties.Settings.Default.Ersteller = Ersteller.Text;
            Properties.Settings.Default.Save();


            /*
             * 
             * old method
            // Open App.Config of executable
            System.Configuration.Configuration config =
             ConfigurationManager.OpenExeConfiguration
                        (ConfigurationUserLevel.None);

            // Add an Application Setting.
            config.AppSettings.Settings.Remove("Laufwerk");
            config.AppSettings.Settings.Add("Laufwerk", comboBox1.Text);

            config.AppSettings.Settings.Remove("Ersteller");
            config.AppSettings.Settings.Add("Ersteller", Ersteller.Text);

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");
            */


            // here is the new one





            Projekt f1 = (Projekt)Application.OpenForms["Projekt"];
            Label tb = (Label)f1.Controls["label8"];
            //tb.Text = configvalue1;
            tb.Text = Properties.Settings.Default.Laufwerk;

            this.Close();

        }

        private void Ersteller_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
