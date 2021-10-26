using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            if (OpenDlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenDlg.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }

            OpenDlg.Dispose();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            if (SaveDlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveDlg.FileName);

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }

                Writer.Close();
            }
            SaveDlg.Dispose();

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение создал студент СибГУТИ\nВащенко С. Д.\n2021");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            listBox1.BeginUpdate();

            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' },
            StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in Strings)
            {
                string Str = s.Trim();

                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }
            }

            listBox1.EndUpdate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            textBox1.Clear();
            richTextBox1.Clear();
            comboBox1.Text = default;
            comboBox2.Text = default;
            radioButton1.Checked = true;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            listBox1.Sorted = false;
            listBox2.Sorted = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            string Find = textBox1.Text;

            if (checkBox1.Checked)
            {
                foreach (string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }

            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Sorted = false;
            comboBox1.Text = "Cортировка по...";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Sorted = false;
            comboBox2.Text = "Cортировка по...";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();

            AddRec.Owner = this;
            AddRec.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate();
            foreach (object Item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(Item);
            }
            listBox2.EndUpdate();
            if (listBox1.SelectedIndex != -1)
            {
                for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
                    listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            foreach (object Item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(Item);
            }
            listBox1.EndUpdate();
            if (listBox2.SelectedIndex != -1)
            {
                for (int i = listBox2.SelectedItems.Count - 1; i >= 0; i--)
                    listBox2.Items.Remove(listBox2.SelectedItems[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Sorted = false;
            string[] arr = new string[listBox1.Items.Count];            
            if (comboBox1.SelectedIndex == 0)
            {
                listBox1.Sorted = true;
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                listBox1.Sorted = true;
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    arr[i] = listBox1.Items[i].ToString();
                }
                string[] reversed = arr.Reverse().ToArray();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.Items[i] = reversed[i];
                }
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    arr[i] = listBox1.Items[i].ToString();
                }
                Array.Sort(arr, (x, y) => x.Length.CompareTo(y.Length));
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.Items[i] = arr[i];
                }
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    arr[i] = listBox1.Items[i].ToString();
                }
                Array.Sort(arr, (x, y) => y.Length.CompareTo(x.Length));
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.Items[i] = arr[i];
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Sorted = false;
            string[] arr = new string[listBox2.Items.Count];
            if (comboBox2.SelectedIndex == 0)
            {
                listBox2.Sorted = true;
            }

            else if (comboBox2.SelectedIndex == 1)
            {
                listBox2.Sorted = true;
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    arr[i] = listBox2.Items[i].ToString();
                }
                string[] reversed = arr.Reverse().ToArray();
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox2.Items[i] = reversed[i];
                }
            }

            else if (comboBox2.SelectedIndex == 2)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    arr[i] = listBox2.Items[i].ToString();
                }
                Array.Sort(arr, (x, y) => x.Length.CompareTo(y.Length));
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox2.Items[i] = arr[i];
                }
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    arr[i] = listBox2.Items[i].ToString();
                }
                Array.Sort(arr, (x, y) => y.Length.CompareTo(x.Length));
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    listBox2.Items[i] = arr[i];
                }
            }
        }
    }
}
