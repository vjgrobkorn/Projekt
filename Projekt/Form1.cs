using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;


namespace Projekt
{
    public partial class Projekt : Form
    {
        public Projekt()
        {
            InitializeComponent();

            label8.Text = Properties.Settings.Default.Laufwerk;
            string creator = Properties.Settings.Default.Ersteller;
            //label8.Text = ConfigurationManager.AppSettings["Laufwerk"];
            //string creator = ConfigurationManager.AppSettings["Ersteller"];

            if (creator == "" || string.IsNullOrEmpty(Properties.Settings.Default.Laufwerk)) MessageBox.Show("Bitte das Konfigurationsmenue aufrufen!");

            string Datum = DateTime.Now.ToString("yyMM");
            int Date = int.Parse(Datum);
            numericUpDown1.Value = Date;

        }

           private void button1_Click(object sender, EventArgs e)
        {
            string b1 = numericUpDown1.Value.ToString();
            string b2 = textBox2.Text;
            string b3 = textBox3.Text;
            string b4 = textBox4.Text;

            string drive = label8.Text;
            
            string startfolder = drive + "Content\\" + b1 + "_" + b2 + "_" + b3;

            string Client = System.IO.Path.Combine(startfolder, "01_CLIENT");
            string RESOURCES = System.IO.Path.Combine(startfolder, "02_RESOURCES");
            string PROJECTFILES = System.IO.Path.Combine(startfolder, "03_PROJECTFILES");
            string PRERENDERER = System.IO.Path.Combine(startfolder, "04_PRE-RENDER");
            string RENDER = System.IO.Path.Combine(startfolder, "05_RENDER");
            string REFERENCES = System.IO.Path.Combine(startfolder, "06_REFERENCE");
            string TXT = System.IO.Path.Combine(startfolder, "07_TXT");
            string UPLOAD = System.IO.Path.Combine(startfolder, "08_UPLOAD");
            string OUT = System.IO.Path.Combine(startfolder, "09_OUT");

            string project = System.IO.Path.Combine(startfolder, PROJECTFILES);

            string ae = System.IO.Path.Combine(project, "AE");
            string ai = System.IO.Path.Combine(project, "AI");
            string blender = System.IO.Path.Combine(project, "BLENDER");
            string c4d = System.IO.Path.Combine(project, "C4D");
            string pr = System.IO.Path.Combine(project, "PR");
            string ps = System.IO.Path.Combine(project, "PS");
            string vvvv = System.IO.Path.Combine(project, "vvvv");
            string other = System.IO.Path.Combine(project, "Unity");

            string descfile = TXT + "\\description.txt";

            string mydate = System.DateTime.Now.ToLongDateString();
            string mytime = System.DateTime.Now.ToLongTimeString();
            string creator = Properties.Settings.Default.Ersteller;

            int error = 0;

            if (textBox3.TextLength != 7)
            {
                MessageBox.Show("Projektnummer muss immer 7 Ziffern haben");
                error = 1;
            }

            /* if (textBox1.TextLength != 4)
            {
                MessageBox.Show("Projektdatum muss 4 Ziffern im Format YYMM (JAHRJAHRMONATMONAT) haben");
                error = 1;
            }
            */
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Es wurde kein Projektname vergeben");
                error = 1;
            }

            if (creator == "" || string.IsNullOrEmpty(Properties.Settings.Default.Laufwerk))
            {
                MessageBox.Show("Im Konfigurationsmenü wurden die Ersteller-Initialien nicht vergeben oder das Standardlaufwerk nicht gesetzt. \r\n\r\n Bitte ins Konfigurationsmenü gehen und die Werte vergeben", "Hinweis", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                error = 1;
            }

        if (error == 0)
            {
                
                                
                System.IO.Directory.CreateDirectory(startfolder);

                System.IO.Directory.CreateDirectory(Client);
                System.IO.Directory.CreateDirectory(RESOURCES);
                System.IO.Directory.CreateDirectory(PROJECTFILES);
                System.IO.Directory.CreateDirectory(PRERENDERER);
                System.IO.Directory.CreateDirectory(RENDER);
                System.IO.Directory.CreateDirectory(REFERENCES);
                System.IO.Directory.CreateDirectory(TXT);
                System.IO.Directory.CreateDirectory(UPLOAD);
                System.IO.Directory.CreateDirectory(OUT);

                System.IO.Directory.CreateDirectory(ae);
                System.IO.Directory.CreateDirectory(ai);
                System.IO.Directory.CreateDirectory(blender);
                System.IO.Directory.CreateDirectory(c4d);
                System.IO.Directory.CreateDirectory(pr);
                System.IO.Directory.CreateDirectory(ps);
                System.IO.Directory.CreateDirectory(vvvv);
                System.IO.Directory.CreateDirectory(other);

                //in Datei schreiben
                FileStream fs = new FileStream(descfile, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("=== "+ creator + " === created this Project on "+ mydate + " on " + mytime + " ===" + "\r\n\r\n" +  textBox4.Text);
                sw.Close();
                // MessageBoxIcon.Information;
                MessageBox.Show("Es wurde das Projekt in " + startfolder + " erfolgreich angelegt", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //MessageBox.Show(b1 + "_" + b2 + "_" + b3);

                /*
                textBox2.Text = "Projektname";
                textBox3.Text = "aktuelle Projektnummer muss 7-stellig sein";
                textBox4.Text = "kurze Projektbeschreibung";
                */

                foreach (TextBox textBox in Controls.OfType<TextBox>())
                    textBox.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Projektnummer Fehler: Projektnummer besteht aus einer 7-stelligen Zahl");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logando Projekt Erstellung\r\n\r\n©2019 [ grobkorn ]\r\n\r\nver 1.0");
            
        }

        private void konfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(); // Objekt von Form2 erstellen:
            frm.Show(); // Form2 anzeigen
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void label8_Click(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
