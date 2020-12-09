using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (comboBox11.Text == "3")
            {
                comboBox6.Enabled = false;
                comboBox10.Enabled = false;
                comboBox5.Enabled = false;
                comboBox9.Enabled = false;
                comboBox13.Enabled = false;
                comboBox15.Enabled = false;
                comboBox14.Enabled = false;
                comboBox12.Enabled = false;
            }
        }

        bool box1_Set = false;
        bool box2_Set = false;
        bool box3_Set = false;
        bool box4_Set = false;
        bool box5_Set = false;

        bool r_box1_Set = false;
        bool r_box2_Set = false;
        bool r_box3_Set = false;
        bool r_box4_Set = false;
        bool r_box5_Set = false;

        bool minus_box1_Set = false;
        bool minus_box2_Set = false;
        bool minus_box3_Set = false;
        bool minus_box4_Set = false;
        bool minus_box5_Set = false;

        bool r_minus_box1_Set = false;
        bool r_minus_box2_Set = false;
        bool r_minus_box3_Set = false;
        bool r_minus_box4_Set = false;
        bool r_minus_box5_Set = false;

        int count = 0;
        int count2 = 0;

        public void Save()
        {
            //
            // NOT COMPLETED!!!
            //

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            fileDialog.RestoreDirectory = true;

            string directoryPath; // Directory path

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
            directoryPath = fileDialog.InitialDirectory + fileDialog.FileName;

                if (!File.Exists(fileDialog.FileName)) // If file does not exists
                {
                    File.Create(fileDialog.FileName).Close();

                    using (StreamWriter sw = File.AppendText(fileDialog.FileName))
                    {
                        sw.WriteLine("WRITE SOME TEXT"); // Write text to file
                    }
                }
                else // If file already exists
                {
                    using (StreamWriter sw = File.AppendText(fileDialog.FileName))
                    {
                        sw.WriteLine("WRITE SOME TEXT"); // Write text to file
                    }
                }
            }
        }

        public void Clear()
        {
            // Clear only box
        }

        public void Clear_All()
        {
             box1_Set = false;
             box2_Set = false;
             box3_Set = false;
             box4_Set = false;
             box5_Set = false;

             r_box1_Set = false;
             r_box2_Set = false;
             r_box3_Set = false;
             r_box4_Set = false;
             r_box5_Set = false;

             minus_box1_Set = false;
             minus_box2_Set = false;
             minus_box3_Set = false;
             minus_box4_Set = false;
             minus_box5_Set = false;

             r_minus_box1_Set = false;
             r_minus_box2_Set = false;
             r_minus_box3_Set = false;
             r_minus_box4_Set = false;
             r_minus_box5_Set = false;

             count = 0;
             count2 = 0;

            // Fighter name & total points
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;

            // Points & minus points
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
            comboBox5.Text = null;
            comboBox6.Text = null;
            comboBox7.Text = null;
            comboBox8.Text = null;
            comboBox9.Text = null;
            comboBox10.Text = null;
            comboBox12.Text = null;
            comboBox13.Text = null;
            comboBox14.Text = null;
            comboBox15.Text = null;
            comboBox16.Text = null;
            comboBox17.Text = null;
            comboBox18.Text = null;
            comboBox19.Text = null;
            comboBox20.Text = null;
            comboBox21.Text = null;

            // Rounds selector
            comboBox11.Text = "3";

            // Re-disable round 4-5 boxes
            comboBox6.Enabled = false;
            comboBox10.Enabled = false;
            comboBox5.Enabled = false;
            comboBox9.Enabled = false;
            comboBox13.Enabled = false;
            comboBox15.Enabled = false;
            comboBox14.Enabled = false;
            comboBox12.Enabled = false;

            // Re-enable round 1-3 boxes
            // Left points
            comboBox1.Enabled = true;
            comboBox3.Enabled = true;
            comboBox8.Enabled = true;
            // Left cuts
            comboBox2.Enabled = true;
            comboBox4.Enabled = true;
            comboBox7.Enabled = true;
            // Right points
            comboBox21.Enabled = true;
            comboBox19.Enabled = true;
            comboBox17.Enabled = true;
            // Right cuts
            comboBox20.Enabled = true;
            comboBox18.Enabled = true;
            comboBox16.Enabled = true;
        }

        // Left side
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && comboBox1.Text != "")
            {
                if (box1_Set == false)
            {
                box1_Set = true;
                comboBox1.Enabled = false;


            count += Convert.ToInt32(comboBox1.Text);
            textBox2.Text = Convert.ToString(count);
            }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != null && comboBox3.Text != "")
            {
                if (box2_Set == false)
                {
                    box2_Set = true;
                    comboBox3.Enabled = false;

                    count += Convert.ToInt32(comboBox3.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text != null && comboBox8.Text != "")
            {
                if (box3_Set == false)
                {
                    box3_Set = true;
                    comboBox8.Enabled = false;

                    count += Convert.ToInt32(comboBox8.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text != null && comboBox6.Text != "")
            {
                if (box4_Set == false)
                {
                    box4_Set = true;
                    comboBox6.Enabled = false;

                    count += Convert.ToInt32(comboBox6.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox10.Text != null && comboBox10.Text != "")
            {
                if (box5_Set == false)
                {
                    box5_Set = true;
                    comboBox10.Enabled = false;

                    count += Convert.ToInt32(comboBox10.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        // Rounds selector
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "5")
            {
                if (box4_Set == false)
                    comboBox6.Enabled = true;
                if (box5_Set == false)
                    comboBox10.Enabled = true;
                if (minus_box4_Set == false)
                    comboBox5.Enabled = true;
                if (minus_box5_Set == false)
                    comboBox9.Enabled = true;
                if (r_box5_Set == false)
                    comboBox13.Enabled = true;
                if (r_box4_Set == false)
                    comboBox15.Enabled = true;
                if (r_minus_box4_Set == false)
                    comboBox14.Enabled = true;
                if (r_minus_box5_Set == false)
                    comboBox12.Enabled = true;
            }
            else
            {
                comboBox6.Enabled = false;
                comboBox10.Enabled = false;
                comboBox5.Enabled = false;
                comboBox9.Enabled = false;

                comboBox13.Enabled = false;
                comboBox15.Enabled = false;
                comboBox14.Enabled = false;
                comboBox12.Enabled = false;
            }
        }

        // Left minus points
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != null && comboBox2.Text != "")
            {
                if (minus_box1_Set == false)
                {
                    minus_box1_Set = true;
                    comboBox2.Enabled = false;

                    count -= Convert.ToInt32(comboBox2.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text != null && comboBox4.Text != "")
            {
                if (minus_box2_Set == false)
                {
                    minus_box2_Set = true;
                    comboBox4.Enabled = false;

                    count -= Convert.ToInt32(comboBox4.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.Text != null && comboBox7.Text != "")
            {
                if (minus_box3_Set == false)
                {
                    minus_box3_Set = true;
                    comboBox7.Enabled = false;

                    count -= Convert.ToInt32(comboBox7.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text != null && comboBox5.Text != "")
            {
                if (minus_box4_Set == false)
                {
                    minus_box4_Set = true;
                    comboBox5.Enabled = false;

                    count -= Convert.ToInt32(comboBox5.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.Text != null && comboBox9.Text != "")
            {
                if (minus_box5_Set == false)
                {
                    minus_box5_Set = true;
                    comboBox9.Enabled = false;

                    count -= Convert.ToInt32(comboBox9.Text);
                    textBox2.Text = Convert.ToString(count);
                }
            }
        }

        // Right side
        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox21.Text != null && comboBox21.Text != "")
            {
                if (r_box1_Set == false)
                {
                    r_box1_Set = true;
                    comboBox21.Enabled = false;

                    count2 += Convert.ToInt32(comboBox21.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox19.Text != null && comboBox19.Text != "")
            {
                if (r_box2_Set == false)
                {
                    r_box2_Set = true;
                    comboBox19.Enabled = false;

                    count2 += Convert.ToInt32(comboBox19.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox17.Text != null && comboBox17.Text != "")
            {
                if (r_box3_Set == false)
                {
                    r_box3_Set = true;
                    comboBox17.Enabled = false;

                    count2 += Convert.ToInt32(comboBox17.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox15.Text != null && comboBox15.Text != "")
            {
                if (r_box4_Set == false)
                {
                    r_box4_Set = true;
                    comboBox15.Enabled = false;

                    count2 += Convert.ToInt32(comboBox15.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox13.Text != null && comboBox13.Text != "")
            {
                if (r_box5_Set == false)
                {
                    r_box5_Set = true;
                    comboBox13.Enabled = false;

                    count2 += Convert.ToInt32(comboBox13.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        // Right minus points
        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox20.Text != null && comboBox20.Text != "")
            {
                if (r_minus_box1_Set == false)
                {
                    r_minus_box1_Set = true;
                    comboBox20.Enabled = false;

                    count2 -= Convert.ToInt32(comboBox20.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox18.Text != null && comboBox18.Text != "")
            {
                if (r_minus_box2_Set == false)
                {
                    r_minus_box2_Set = true;
                    comboBox18.Enabled = false;

                    count2 -= Convert.ToInt32(comboBox18.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox16.Text != null && comboBox16.Text != "")
            {
                if (r_minus_box3_Set == false)
                {
                    r_minus_box3_Set = true;
                    comboBox16.Enabled = false;

                    count2 -= Convert.ToInt32(comboBox16.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox14.Text != null && comboBox14.Text != "")
            {
                if (r_minus_box4_Set == false)
                {
                    r_minus_box4_Set = true;
                    comboBox14.Enabled = false;

                    count2 -= Convert.ToInt32(comboBox14.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox12.Text != null && comboBox12.Text != "")
            {
                if (r_minus_box5_Set == false)
                {
                    r_minus_box5_Set = true;
                    comboBox12.Enabled = false;

                    count2 -= Convert.ToInt32(comboBox12.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to reset the table?", "Reset the table?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Clear_All();
            }
            else
            {
                // Do nothing
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save the table?", "Save the table?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Save();
            }
            else
            {
                // Do nothing
            }
        }
    }
}
