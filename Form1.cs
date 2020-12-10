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

        string fighter1;
        string fighter2;

        int rounds_amount = 3;

        int l_points1 = 0;
        int l_points2 = 0;
        int l_points3 = 0;
        int l_points4 = 0;
        int l_points5 = 0;
        int l_cuts1 = 0;
        int l_cuts2 = 0;
        int l_cuts3 = 0;
        int l_cuts4 = 0;
        int l_cuts5 = 0;

        int r_points1 = 0;
        int r_points2 = 0;
        int r_points3 = 0;
        int r_points4 = 0;
        int r_points5 = 0;
        int r_cuts1 = 0;
        int r_cuts2 = 0;
        int r_cuts3 = 0;
        int r_cuts4 = 0;
        int r_cuts5 = 0;

        int l_totalPoints = 0;
        int r_totalPoints = 0;

        private void fighter1_TextChanged(object sender, EventArgs e)
        {
            fighter1 = textBox1.Text;
        }

        private void fighter2_TextChanged(object sender, EventArgs e)
        {
            fighter2 = textBox4.Text;
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

            l_points1 = Convert.ToInt32(comboBox1.Text);

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

                    l_points2 = Convert.ToInt32(comboBox3.Text);

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

                    l_points3 = Convert.ToInt32(comboBox8.Text);

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

                    l_points4 = Convert.ToInt32(comboBox6.Text);

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

                    l_points5 = Convert.ToInt32(comboBox10.Text);

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
                rounds_amount = 5;

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
                rounds_amount = 3;

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

                    l_cuts1 = Convert.ToInt32(comboBox2.Text);

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

                    l_cuts2 = Convert.ToInt32(comboBox4.Text);

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

                    l_cuts3 = Convert.ToInt32(comboBox7.Text);

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

                    l_cuts4 = Convert.ToInt32(comboBox5.Text);

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

                    l_cuts5 = Convert.ToInt32(comboBox9.Text);

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

                    r_points1 = Convert.ToInt32(comboBox21.Text);

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

                    r_points2 = Convert.ToInt32(comboBox19.Text);

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

                    r_points3 = Convert.ToInt32(comboBox17.Text);

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

                    r_points4 = Convert.ToInt32(comboBox15.Text);

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

                    r_points5 = Convert.ToInt32(comboBox13.Text);

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

                    r_cuts1 = Convert.ToInt32(comboBox20.Text);

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

                    r_cuts2 = Convert.ToInt32(comboBox18.Text);

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

                    r_cuts3 = Convert.ToInt32(comboBox16.Text);

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

                    r_cuts4 = Convert.ToInt32(comboBox14.Text);

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

                    r_cuts5 = Convert.ToInt32(comboBox12.Text);

                    count2 -= Convert.ToInt32(comboBox12.Text);
                    textBox3.Text = Convert.ToString(count2);
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to reset the scoreboard values?", "Reset all values?", MessageBoxButtons.YesNo);

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
            DialogResult result = MessageBox.Show("Do you want to save the scoreboard?", "Save the scoreboard?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Save();
            }
            else
            {
                // Do nothing
            }
        }

        public void Save()
        {
            DateTime DateNow = DateTime.Now;
            string dateNow = Convert.ToString(DateNow);

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = "Scoreboard.txt";
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            fileDialog.RestoreDirectory = true;

            string directoryPath; // Directory path
            if (textBox2.Text != null && textBox2.Text != "")
                l_totalPoints = Convert.ToInt32(textBox2.Text); // Left total points
            if (textBox3.Text != null && textBox3.Text != "")
                r_totalPoints = Convert.ToInt32(textBox3.Text); // Right total points

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                directoryPath = fileDialog.InitialDirectory + fileDialog.FileName;

                if (!File.Exists(fileDialog.FileName)) // If file doesn't exist
                {
                    File.Create(fileDialog.FileName).Close();

                    using (StreamWriter sw = File.AppendText(fileDialog.FileName))
                    {
                        sw.WriteLine("[ SAVED: " + dateNow + " ]"); // [ SAVED: 1.1.2020 18.00.00 ]
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >

                        sw.WriteLine("Rounds amount: " + rounds_amount);
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Fighter 1: " + fighter1); // Fighter 1: Conor McGregor
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Round 1 points: " + l_points1 + " (" + l_cuts1 + " cuts)"); // Round 1 points: 10 (0 cuts)
                        sw.WriteLine("Round 2 points: " + l_points2 + " (" + l_cuts2 + " cuts)"); // Round 2 points: 10 (0 cuts)
                        sw.WriteLine("Round 3 points: " + l_points3 + " (" + l_cuts3 + " cuts)"); // Round 3 points: 10 (0 cuts)
                        if (rounds_amount == 5)
                        {
                            sw.WriteLine("Round 4 points: " + l_points4 + " (" + l_cuts4 + " cuts)"); // Round 4 points: 10 (0 cuts)
                            sw.WriteLine("Round 5 points: " + l_points5 + " (" + l_cuts5 + " cuts)"); // Round 5 points: 10 (0 cuts)
                        }
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Total points: " + l_totalPoints); // Total points: 30
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >

                        sw.WriteLine("Fighter 2: " + fighter2); // Fighter 2: Dustin Poirier
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Round 1 points: " + r_points1 + " (" + r_cuts1 + " cuts)"); // Round 1 points: 10 (0 cuts)
                        sw.WriteLine("Round 2 points: " + r_points2 + " (" + r_cuts2 + " cuts)"); // Round 2 points: 10 (0 cuts)
                        sw.WriteLine("Round 3 points: " + r_points3 + " (" + r_cuts3 + " cuts)"); // Round 3 points: 10 (0 cuts)
                        if (rounds_amount == 5)
                        {
                            sw.WriteLine("Round 4 points: " + r_points4 + " (" + r_cuts4 + " cuts)"); // Round 4 points: 10 (0 cuts)
                            sw.WriteLine("Round 5 points: " + r_points5 + " (" + r_cuts5 + " cuts)"); // Round 5 points: 10 (0 cuts)
                        }
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Total points: " + r_totalPoints); // Total points: 30
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >
                    }
                }
                else // If file already exists
                {
                    File.WriteAllText(@directoryPath, string.Empty); // Empty the old file

                    using (StreamWriter sw = File.AppendText(fileDialog.FileName))
                    {
                        sw.WriteLine("[ SAVED: " + dateNow + " ]"); // [ SAVED: 1.1.2020 18.00.00 ]
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >

                        sw.WriteLine("Rounds amount: " + rounds_amount);
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >

                        sw.WriteLine("Fighter 1: " + fighter1); // Fighter 1: Conor McGregor
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Round 1 points: " + l_points1 + " (" + l_cuts1 + " cuts)"); // Round 1 points: 10 (0 cuts)
                        sw.WriteLine("Round 2 points: " + l_points2 + " (" + l_cuts2 + " cuts)"); // Round 2 points: 10 (0 cuts)
                        sw.WriteLine("Round 3 points: " + l_points3 + " (" + l_cuts3 + " cuts)"); // Round 3 points: 10 (0 cuts)
                        if (rounds_amount == 5)
                        {
                            sw.WriteLine("Round 4 points: " + l_points4 + " (" + l_cuts4 + " cuts)"); // Round 4 points: 10 (0 cuts)
                            sw.WriteLine("Round 5 points: " + l_points5 + " (" + l_cuts5 + " cuts)"); // Round 5 points: 10 (0 cuts)
                        }
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Total points: " + l_totalPoints); // Total points: 30
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >

                        sw.WriteLine("Fighter 2: " + fighter2); // Fighter 2: Dustin Poirier
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Round 1 points: " + r_points1 + " (" + r_cuts1 + " cuts)"); // Round 1 points: 10 (0 cuts)
                        sw.WriteLine("Round 2 points: " + r_points2 + " (" + r_cuts2 + " cuts)"); // Round 2 points: 10 (0 cuts)
                        sw.WriteLine("Round 3 points: " + r_points3 + " (" + r_cuts3 + " cuts)"); // Round 3 points: 10 (0 cuts)
                        if (rounds_amount == 5)
                        {
                            sw.WriteLine("Round 4 points: " + r_points4 + " (" + r_cuts4 + " cuts)"); // Round 4 points: 10 (0 cuts)
                            sw.WriteLine("Round 5 points: " + r_points5 + " (" + r_cuts5 + " cuts)"); // Round 5 points: 10 (0 cuts)
                        }
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Total points: " + r_totalPoints); // Total points: 30
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >
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
            // textBox1.Text = null;
            // textBox4.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;

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

            // Save values
            rounds_amount = 3;
            l_points1 = 0;
            l_points2 = 0;
            l_points3 = 0;
            l_points4 = 0;
            l_points5 = 0;
            l_cuts1 = 0;
            l_cuts2 = 0;
            l_cuts3 = 0;
            l_cuts4 = 0;
            l_cuts5 = 0;
            r_points1 = 0;
            r_points2 = 0;
            r_points3 = 0;
            r_points4 = 0;
            r_points5 = 0;
            r_cuts1 = 0;
            r_cuts2 = 0;
            r_cuts3 = 0;
            r_cuts4 = 0;
            r_cuts5 = 0;
            fighter1 = null;
            fighter2 = null;
            l_totalPoints = 0;
            r_totalPoints = 0;
        }

        private void resetR1_Button_Click(object sender, EventArgs e)
        {
            int round1_value = 0;

            box1_Set = false;
            comboBox1.Enabled = true;
            l_points1 = 0;

            if (!String.IsNullOrEmpty(comboBox1.Text))
                round1_value += Convert.ToInt32(comboBox1.Text);

            minus_box1_Set = false;
            comboBox2.Enabled = true;
            l_cuts1 = 0;

            if (!String.IsNullOrEmpty(comboBox2.Text))
                round1_value -= Convert.ToInt32(comboBox2.Text);

            r_box1_Set = false;
            comboBox21.Enabled = true;
            r_points1 = 0;

            if (!String.IsNullOrEmpty(comboBox21.Text))
                round1_value += Convert.ToInt32(comboBox21.Text);

            r_minus_box1_Set = false;
            comboBox20.Enabled = true;
            r_cuts1 = 0;

            if (!String.IsNullOrEmpty(comboBox20.Text))
                round1_value -= Convert.ToInt32(comboBox20.Text);

            //count -= round1_value;
            textBox2.Text = Convert.ToString(count - round1_value);
        }

        private void resetR2_Button_Click(object sender, EventArgs e)
        {

        }

        private void resetR3_Button_Click(object sender, EventArgs e)
        {

        }

        private void resetR4_Button_Click(object sender, EventArgs e)
        {

        }

        private void resetR5_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
