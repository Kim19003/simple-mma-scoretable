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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace SimpleMMAScoreboard
{
    public partial class Form1 : Form
    {
        public string AppName { get { return appName; } }
        private const string appName = "Simple MMA Scoreboard";

        public string AppCreator { get { return appCreator; } }
        private const string appCreator = "Kim19003";

        #region Variables
        // Counters
        int count = 0, count2 = 0;

        // Fighter and judge names
        string fighter1, fighter2, judge;

        // Round amount
        int rounds_amount = 3;

        // Boxes set
        bool box1_Set = false, box2_Set = false, box3_Set = false, box4_Set = false, box5_Set = false, r_box1_Set = false,
        r_box2_Set = false, r_box3_Set = false, r_box4_Set = false, r_box5_Set = false;

        // Minux boxes set
        bool minus_box1_Set = false, minus_box2_Set = false, minus_box3_Set = false, minus_box4_Set = false, minus_box5_Set = false,
        r_minus_box1_Set = false, r_minus_box2_Set = false, r_minus_box3_Set = false, r_minus_box4_Set = false, r_minus_box5_Set = false;

        // Points
        int l_points1 = 0, l_points2 = 0, l_points3 = 0, l_points4 = 0, l_points5 = 0, l_cuts1 = 0, l_cuts2 = 0, l_cuts3 = 0,
        l_cuts4 = 0, l_cuts5 = 0, r_points1 = 0, r_points2 = 0, r_points3 = 0, r_points4 = 0, r_points5 = 0, r_cuts1 = 0,
        r_cuts2 = 0, r_cuts3 = 0, r_cuts4 = 0, r_cuts5 = 0, l_totalPoints = 0, r_totalPoints = 0;
        // ---
        #endregion

        #region FormDependencies
        public Form1()
        {
            InitializeComponent();

            MaximizeBox = false;
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

                resetR4_Button.Enabled = false;
                resetR5_Button.Enabled = false;
            }

            Color_Dark(); // Starting theme
        }
        #endregion

        #region FighterAndJudgeBoxes
        /*
         * fighter1 = Red Corner
         * fighter2 = Blue Corner
         */

        private void fighter1_TextChanged(object sender, EventArgs e)
        {
            fighter1 = textBox1.Text;
        }

        private void fighter2_TextChanged(object sender, EventArgs e)
        {
            fighter2 = textBox4.Text;
        }

        private void judgeBox_TextChanged(object sender, EventArgs e)
        {
            judge = judgeBox.Text;
        }
        #endregion

        #region ColorButtons
        // Color buttons
        private void blueColor_Button_Click(object sender, EventArgs e)
        {
            Color_Blue();
        }

        private void pinkColor_Button_Click(object sender, EventArgs e)
        {
            Color_Pink();
        }

        private void whiteColor_Button_Click(object sender, EventArgs e)
        {
            Color_White();
        }

        private void darkColor_Button_Click(object sender, EventArgs e)
        {
            Color_Dark();
        }
        #endregion

        #region PointBoxes
        /*
         * Box relations:
         * 
         * Round 1: comboBox1 -> comboBox21
         * Round 2: comboBox3 -> comboBox19
         * Round 3: comboBox8 -> comboBox17
         * Round 4: comboBox6 -> comboBox15
         * Round 5: comboBox10 -> comboBox13
         */

        #region LeftPointBoxes
        // -- Left side --
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox1, comboBox21, textBox2, ref box1_Set, ref l_points1, ref count, false);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox3, comboBox19, textBox2, ref box2_Set, ref l_points2, ref count, false);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox8, comboBox17, textBox2, ref box3_Set, ref l_points3, ref count, false);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox6, comboBox15, textBox2, ref box4_Set, ref l_points4, ref count, false);
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox10, comboBox13, textBox2, ref box5_Set, ref l_points5, ref count, false);
        }

        #region LeftMinus
        // - Left minus -
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox2, null, textBox2, ref minus_box1_Set, ref l_cuts1, ref count, true);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox4, null, textBox2, ref minus_box2_Set, ref l_cuts2, ref count, true);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox7, null, textBox2, ref minus_box3_Set, ref l_cuts3, ref count, true);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox5, null, textBox2, ref minus_box4_Set, ref l_cuts4, ref count, true);
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox9, null, textBox2, ref minus_box5_Set, ref l_cuts5, ref count, true);
        }
        #endregion

        #endregion

        #region RightPointBoxes
        // -- Right side --
        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox21, comboBox1, textBox3, ref r_box1_Set, ref r_points1, ref count2, false);
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox19, comboBox3, textBox3, ref r_box2_Set, ref r_points2, ref count2, false);
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox17, comboBox8, textBox3, ref r_box3_Set, ref r_points3, ref count2, false);
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox15, comboBox6, textBox3, ref r_box4_Set, ref r_points4, ref count2, false);
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox13, comboBox10, textBox3, ref r_box5_Set, ref r_points5, ref count2, false);
        }

        #region RightMinus
        // - Right minus -
        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox20, null, textBox3, ref r_minus_box1_Set, ref r_cuts1, ref count2, true);
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox18, null, textBox3, ref r_minus_box2_Set, ref r_cuts2, ref count2, true);
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox16, null, textBox3, ref r_minus_box3_Set, ref r_cuts3, ref count2, true);
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox14, null, textBox3, ref r_minus_box4_Set, ref r_cuts4, ref count2, true);
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox12, null, textBox3, ref r_minus_box5_Set, ref r_cuts5, ref count2, true);
        }
        #endregion

        #endregion

        #endregion

        #region OtherBoxesAndButtons
        // Rounds selector
        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.Text == "5")
            {
                Round_Amount_5();
            }
            else
            {
                Round_Amount_3();
            }
        }

        // Clear-button
        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to reset the scoreboard?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                Clear_All();
            }
            else
            {
                // Do nothing
            }
        }

        // Save-button
        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save the scoreboard?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Save();
            }
            else
            {
                // Do nothing
            }
        }
        // ---

        private void resetR1_Button_Click(object sender, EventArgs e)
        {
            Clear_Round1();
        }

        private void resetR2_Button_Click(object sender, EventArgs e)
        {
            Clear_Round2();
        }

        private void resetR3_Button_Click(object sender, EventArgs e)
        {
            Clear_Round3();
        }

        private void resetR4_Button_Click(object sender, EventArgs e)
        {
            Clear_Round4();
        }

        private void resetR5_Button_Click(object sender, EventArgs e)
        {
            Clear_Round5();
        }
        #endregion

        #region BoxGrayingAndSaving
        // Gray text for hidden boxes
        private void Round4_EC(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.ForeColor = btn.Enabled ? Color.Black : Color.Silver;
        }

        private void Round4_Paint(object sender, PaintEventArgs e)
        {
            var btn = (Button)sender;
            var drawBrush = new SolidBrush(btn.ForeColor);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            resetR4_Button.Text = string.Empty;
            e.Graphics.DrawString("Reset Round 4", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }
        // ---

        private void Round5_EC(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.ForeColor = btn.Enabled ? Color.Black : Color.Silver;
        }

        private void Round5_Paint(object sender, PaintEventArgs e)
        {
            var btn = (Button)sender;
            var drawBrush = new SolidBrush(btn.ForeColor);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            resetR5_Button.Text = string.Empty;
            e.Graphics.DrawString("Reset Round 5", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void Save()
        {
            DateTime DateNow = DateTime.Now;
            string dateNow = Convert.ToString(DateNow);

            SaveFileDialog fileDialog = new SaveFileDialog();
            if (!string.IsNullOrEmpty(fighter1) && !string.IsNullOrEmpty(fighter2))
            {
                fileDialog.FileName = $"{fighter1} vs. {fighter2} ({DateNow.ToString("dd/MM/yyyy")})";
            }
            else
            {
                fileDialog.FileName = $"unnamed vs. unnamed ({DateNow.ToString("dd/MM/yyyy")})";
            }
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
                        sw.WriteLine("[ DATE: " + dateNow + " ]"); // [ DATE: 1.1.2020 18.00.00 ]
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >

                        sw.WriteLine("Rounds amount: " + rounds_amount);
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("---");
                        sw.WriteLine(""); // < Line feed >
                        sw.WriteLine("Red Corner: " + fighter1); // Red Corner: Conor McGregor
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

                        sw.WriteLine("Blue Corner: " + fighter2); // Blue Corner: Dustin Poirier
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
                        if (!string.IsNullOrEmpty(judge))
                        {
                            sw.WriteLine("Judge: " + judge);
                        }
                        else
                        {
                            sw.WriteLine("Judge: ");
                        }
                    }
                }
                else // If file already exists
                {
                    File.WriteAllText(@directoryPath, string.Empty); // Overwrite the old file

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
        #endregion

        #region PointsForerunnerAndPointsChecker
        /* 
         * Automatically corrects the maximum amount of points that can be given for the relative points box (for example: if the left box has 8 or 9,
         * the right box can't have 8 or 9, because MMA judging rules don't allow scoring with (8-8, 8-9, 9-8 or 9-9) so it must have 10)
         */
        private void PointsForerunner(ComboBox thisPointBox, ComboBox relativePointBox)
        {
            int thisPointBoxPoints = Convert.ToInt32(thisPointBox.Text);

            if (thisPointBoxPoints == 8 || thisPointBoxPoints == 9)
            {
                relativePointBox.Items.Clear(); // Clear all relative point box points
                relativePointBox.Items.Add(10); // Add "10" as an only option for the relative point box
            }
        }

        private void ResetPointBoxItems(ComboBox pointBox)
        {
            pointBox.Items.Clear();
            pointBox.Items.Add(10);
            pointBox.Items.Add(9);
            pointBox.Items.Add(8);
        }

        private bool PointsChecker(ComboBox pointBox) // Checks that inserted points are allowed
        {
            int thisPointBoxPoints = Convert.ToInt32(pointBox.Text);

            if (thisPointBoxPoints == 8 || thisPointBoxPoints == 9 || thisPointBoxPoints == 10)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Colors
        private void Color_Blue()
        {
            this.BackColor = Color.FromArgb(46, 68, 107);

            Label_Color_White();
        }

        private void Color_Pink()
        {
            this.BackColor = Color.FromArgb(156, 70, 70);

            Label_Color_White();
        }

        private void Color_White()
        {
            this.BackColor = Color.White;

            Label_Color_Black();
        }

        private void Color_Dark()
        {
            this.BackColor = Color.FromArgb(31, 33, 41);

            Label_Color_White();
        }

        // Change label text color to black and box background colors to greyish (FOR BRIGHT THEMES)
        private void Label_Color_Black()
        {
            label2.ForeColor = SystemColors.ControlText;
            label19.ForeColor = SystemColors.ControlText;
            label1.ForeColor = SystemColors.ControlText;
            label3.ForeColor = SystemColors.ControlText;
            label4.ForeColor = SystemColors.ControlText;
            label10.ForeColor = SystemColors.ControlText;
            label9.ForeColor = SystemColors.ControlText;
            label8.ForeColor = SystemColors.ControlText;
            label7.ForeColor = SystemColors.ControlText;
            label6.ForeColor = SystemColors.ControlText;
            label18.ForeColor = SystemColors.ControlText;
            label17.ForeColor = SystemColors.ControlText;
            label15.ForeColor = SystemColors.ControlText;
            label14.ForeColor = SystemColors.ControlText;
            label13.ForeColor = SystemColors.ControlText;
            label12.ForeColor = SystemColors.ControlText;
            label11.ForeColor = SystemColors.ControlText;
            label5.ForeColor = SystemColors.ControlText;
            label16.ForeColor = SystemColors.ControlText;
            label20.ForeColor = SystemColors.ControlText;

            textBox1.BackColor = Color.Gainsboro;
            panel1.BackColor = Color.Gainsboro;
            textBox4.BackColor = Color.Gainsboro;
            panel2.BackColor = Color.Gainsboro;
            judgeBox.BackColor = Color.Gainsboro;
            panel6.BackColor = Color.Gainsboro;

            comboBox11.BackColor = Color.Gainsboro;

            comboBox1.BackColor = Color.Gainsboro;
            comboBox3.BackColor = Color.Gainsboro;
            comboBox8.BackColor = Color.Gainsboro;
            comboBox6.BackColor = Color.Gainsboro;
            comboBox10.BackColor = Color.Gainsboro;

            comboBox21.BackColor = Color.Gainsboro;
            comboBox19.BackColor = Color.Gainsboro;
            comboBox17.BackColor = Color.Gainsboro;
            comboBox15.BackColor = Color.Gainsboro;
            comboBox13.BackColor = Color.Gainsboro;

            resetR1_Button.BackColor = Color.Gainsboro;
            resetR2_Button.BackColor = Color.Gainsboro;
            resetR3_Button.BackColor = Color.Gainsboro;
            resetR4_Button.BackColor = Color.Gainsboro;
            resetR5_Button.BackColor = Color.Gainsboro;

            textBox2.BackColor = Color.Gainsboro;
            panel3.BackColor = Color.Gainsboro;
            textBox3.BackColor = Color.Gainsboro;
            panel4.BackColor = Color.Gainsboro;

            saveButton.BackColor = Color.Gainsboro;
            clearButton.BackColor = Color.Gainsboro;
        }

        // Change label text color to white and box background colors to white (FOR DIM THEMES)
        private void Label_Color_White()
        {
            label2.ForeColor = Color.White;
            label19.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label18.ForeColor = Color.White;
            label17.ForeColor = Color.White;
            label15.ForeColor = Color.White;
            label14.ForeColor = Color.White;
            label13.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            label11.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label16.ForeColor = Color.White;
            label20.ForeColor = Color.White;

            textBox1.BackColor = Color.White;
            panel1.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            panel2.BackColor = Color.White;
            judgeBox.BackColor = Color.White;
            panel6.BackColor = Color.White;

            comboBox11.BackColor = Color.White;

            comboBox1.BackColor = Color.White;
            comboBox3.BackColor = Color.White;
            comboBox8.BackColor = Color.White;
            comboBox6.BackColor = Color.White;
            comboBox10.BackColor = Color.White;

            comboBox21.BackColor = Color.White;
            comboBox19.BackColor = Color.White;
            comboBox17.BackColor = Color.White;
            comboBox15.BackColor = Color.White;
            comboBox13.BackColor = Color.White;

            resetR1_Button.BackColor = Color.White;
            resetR2_Button.BackColor = Color.White;
            resetR3_Button.BackColor = Color.White;
            resetR4_Button.BackColor = Color.White;
            resetR5_Button.BackColor = Color.White;

            textBox2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            panel4.BackColor = Color.White;

            saveButton.BackColor = Color.White;
            clearButton.BackColor = Color.White;
        }
        #endregion

        #region Clearers
        void Clear_Round1()
        {
            int l_round1_value = l_points1 - l_cuts1;
            int r_round1_value = r_points1 - r_cuts1;

            l_points1 = 0;
            l_cuts1 = 0;

            r_points1 = 0;
            r_cuts1 = 0;

            box1_Set = false;
            comboBox1.Enabled = true;

            minus_box1_Set = false;
            comboBox2.Enabled = true;

            r_box1_Set = false;
            comboBox21.Enabled = true;

            r_minus_box1_Set = false;
            comboBox20.Enabled = true;

            comboBox1.Text = null;
            comboBox2.Text = null;

            comboBox21.Text = null;
            comboBox20.Text = null;

            count -= l_round1_value;
            count2 -= r_round1_value;

            if (count == 0)
            {
                textBox2.Text = null;
            }
            else
            {
                textBox2.Text = Convert.ToString(count);
            }

            if (count2 == 0)
            {
                textBox3.Text = null;
            }
            else
            {
                textBox3.Text = Convert.ToString(count2);
            }

            ResetPointBoxItems(comboBox1);
            ResetPointBoxItems(comboBox21);
        }

        void Clear_Round2()
        {
            int l_round2_value = l_points2 - l_cuts2;
            int r_round2_value = r_points2 - r_cuts2;

            l_points2 = 0;
            l_cuts2 = 0;

            r_points2 = 0;
            r_cuts2 = 0;

            box2_Set = false;
            comboBox3.Enabled = true;

            minus_box2_Set = false;
            comboBox4.Enabled = true;

            r_box2_Set = false;
            comboBox19.Enabled = true;

            r_minus_box2_Set = false;
            comboBox18.Enabled = true;

            comboBox3.Text = null;
            comboBox4.Text = null;

            comboBox19.Text = null;
            comboBox18.Text = null;

            count -= l_round2_value;
            count2 -= r_round2_value;

            if (count == 0)
            {
                textBox2.Text = null;
            }
            else
            {
                textBox2.Text = Convert.ToString(count);
            }

            if (count2 == 0)
            {
                textBox3.Text = null;
            }
            else
            {
                textBox3.Text = Convert.ToString(count2);
            }

            ResetPointBoxItems(comboBox3);
            ResetPointBoxItems(comboBox19);
        }

        void Clear_Round3()
        {
            int l_round3_value = l_points3 - l_cuts3;
            int r_round3_value = r_points3 - r_cuts3;

            l_points3 = 0;
            l_cuts3 = 0;

            r_points3 = 0;
            r_cuts3 = 0;

            box3_Set = false;
            comboBox8.Enabled = true;

            minus_box3_Set = false;
            comboBox7.Enabled = true;

            r_box3_Set = false;
            comboBox17.Enabled = true;

            r_minus_box3_Set = false;
            comboBox16.Enabled = true;

            comboBox8.Text = null;
            comboBox7.Text = null;

            comboBox17.Text = null;
            comboBox16.Text = null;

            count -= l_round3_value;
            count2 -= r_round3_value;

            if (count == 0)
            {
                textBox2.Text = null;
            }
            else
            {
                textBox2.Text = Convert.ToString(count);
            }

            if (count2 == 0)
            {
                textBox3.Text = null;
            }
            else
            {
                textBox3.Text = Convert.ToString(count2);
            }

            ResetPointBoxItems(comboBox8);
            ResetPointBoxItems(comboBox17);
        }

        void Clear_Round4()
        {
            int l_round4_value = l_points4 - l_cuts4;
            int r_round4_value = r_points4 - r_cuts4;

            l_points4 = 0;
            l_cuts4 = 0;

            r_points4 = 0;
            r_cuts4 = 0;

            box4_Set = false;
            comboBox6.Enabled = true;

            minus_box4_Set = false;
            comboBox5.Enabled = true;

            r_box4_Set = false;
            comboBox15.Enabled = true;

            r_minus_box4_Set = false;
            comboBox14.Enabled = true;

            comboBox6.Text = null;
            comboBox5.Text = null;

            comboBox15.Text = null;
            comboBox14.Text = null;

            count -= l_round4_value;
            count2 -= r_round4_value;

            if (count == 0)
            {
                textBox2.Text = null;
            }
            else
            {
                textBox2.Text = Convert.ToString(count);
            }

            if (count2 == 0)
            {
                textBox3.Text = null;
            }
            else
            {
                textBox3.Text = Convert.ToString(count2);
            }

            ResetPointBoxItems(comboBox6);
            ResetPointBoxItems(comboBox15);
        }

        void Clear_Round5()
        {
            int l_round5_value = l_points5 - l_cuts5;
            int r_round5_value = r_points5 - r_cuts5;

            l_points5 = 0;
            l_cuts5 = 0;

            r_points5 = 0;
            r_cuts5 = 0;

            box5_Set = false;
            comboBox10.Enabled = true;

            minus_box5_Set = false;
            comboBox9.Enabled = true;

            r_box5_Set = false;
            comboBox13.Enabled = true;

            r_minus_box5_Set = false;
            comboBox12.Enabled = true;

            comboBox10.Text = null;
            comboBox9.Text = null;

            comboBox13.Text = null;
            comboBox12.Text = null;

            count -= l_round5_value;
            count2 -= r_round5_value;

            if (count == 0)
            {
                textBox2.Text = null;
            }
            else
            {
                textBox2.Text = Convert.ToString(count);
            }

            if (count2 == 0)
            {
                textBox3.Text = null;
            }
            else
            {
                textBox3.Text = Convert.ToString(count2);
            }

            ResetPointBoxItems(comboBox10);
            ResetPointBoxItems(comboBox13);
        }

        private void Point_Box_Variables_Clear()
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
        }

        private void Minus_Point_Box_Variables_Clear()
        {
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
        }

        private void Counter_Variables_Clear()
        {
            count = 0;
            count2 = 0;
        }

        private void Text_Boxes_Clear()
        {
            // Fighters and total points
            textBox1.Text = null;
            textBox4.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;

            // Points
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
        }

        private void Box_Visibility_Clear()
        {
            // Re-disable round 4-5 stuff
            comboBox6.Enabled = false;
            comboBox10.Enabled = false;
            comboBox5.Enabled = false;
            comboBox9.Enabled = false;
            comboBox13.Enabled = false;
            comboBox15.Enabled = false;
            comboBox14.Enabled = false;
            comboBox12.Enabled = false;

            resetR4_Button.Enabled = false;
            resetR5_Button.Enabled = false;

            // Re-enable round 1-3 stuff
            comboBox1.Enabled = true;
            comboBox3.Enabled = true;
            comboBox8.Enabled = true;
            comboBox2.Enabled = true;
            comboBox4.Enabled = true;
            comboBox7.Enabled = true;

            comboBox21.Enabled = true;
            comboBox19.Enabled = true;
            comboBox17.Enabled = true;
            comboBox20.Enabled = true;
            comboBox18.Enabled = true;
            comboBox16.Enabled = true;
        }

        private void Other_Variables_Clear()
        {
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

        private void ResetAllPointBoxItems()
        {
            ResetPointBoxItems(comboBox1); // R1
            ResetPointBoxItems(comboBox21);

            ResetPointBoxItems(comboBox3); // R2
            ResetPointBoxItems(comboBox19);

            ResetPointBoxItems(comboBox8); // R3
            ResetPointBoxItems(comboBox17);

            ResetPointBoxItems(comboBox6); // R4
            ResetPointBoxItems(comboBox15);

            ResetPointBoxItems(comboBox10); // R5
            ResetPointBoxItems(comboBox13);

        }

        private void Clear_All()
        {
            // Rounds selector
            comboBox11.Text = "3";
            rounds_amount = 3;

            // Others
            Point_Box_Variables_Clear();
            Minus_Point_Box_Variables_Clear();
            Counter_Variables_Clear();
            Text_Boxes_Clear();
            Box_Visibility_Clear();
            Other_Variables_Clear();
            ResetAllPointBoxItems();
        }
        #endregion

        #region RoundAmount
        void Round_Amount_5()
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

            resetR4_Button.Enabled = true;
            resetR5_Button.Enabled = true;
        }

        void Round_Amount_3()
        {
            rounds_amount = 3;

            int l_round4_value = l_points4 - l_cuts4, l_round5_value = l_points5 - l_cuts5,
            r_round4_value = r_points4 - r_cuts4, r_round5_value = r_points5 - r_cuts5;

            comboBox6.Enabled = false;
            comboBox10.Enabled = false;
            comboBox5.Enabled = false;
            comboBox9.Enabled = false;
            comboBox6.Text = null;
            comboBox10.Text = null;
            comboBox5.Text = null;
            comboBox9.Text = null;

            comboBox13.Enabled = false;
            comboBox15.Enabled = false;
            comboBox14.Enabled = false;
            comboBox12.Enabled = false;
            comboBox13.Text = null;
            comboBox15.Text = null;
            comboBox14.Text = null;
            comboBox12.Text = null;

            box4_Set = false;
            box5_Set = false;
            r_box4_Set = false;
            r_box5_Set = false;
            minus_box4_Set = false;
            minus_box5_Set = false;
            r_minus_box4_Set = false;
            r_minus_box5_Set = false;

            l_points4 = 0;
            l_points5 = 0;
            l_cuts4 = 0;
            l_cuts5 = 0;
            r_points4 = 0;
            r_points5 = 0;
            r_cuts4 = 0;
            r_cuts5 = 0;

            resetR4_Button.Enabled = false;
            resetR5_Button.Enabled = false;

            if (count > 0)
            {
                count -= l_round4_value + l_round5_value;
                textBox2.Text = Convert.ToString(count);
            }
            if (count2 > 0)
            {
                count2 -= r_round4_value + r_round5_value;
                textBox3.Text = Convert.ToString(count2);
            }
        }
        #endregion

        #region Methods
        private void HandlePoints(ComboBox thisPointsBox, ComboBox relationPointsBox, TextBox totalPointsBox, ref bool boxIsSet, ref int totalPoints, ref int count, bool isMinus)
        {
            if (thisPointsBox.Text != null && thisPointsBox.Text != "")
            {
                if (boxIsSet == false)
                {
                    if (PointsChecker(thisPointsBox) || isMinus)
                    {
                        if (!isMinus)
                        {
                            PointsForerunner(thisPointsBox, relationPointsBox);
                        }

                        boxIsSet = true;
                        thisPointsBox.Enabled = false;

                        totalPoints = Convert.ToInt32(thisPointsBox.Text);

                        if (!isMinus)
                        {
                            count += Convert.ToInt32(thisPointsBox.Text);
                        }
                        else
                        {
                            count -= Convert.ToInt32(thisPointsBox.Text);
                        }

                        totalPointsBox.Text = Convert.ToString(count);
                    }
                }
            }
        }
        #endregion
    }
}
