using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimpleMMAScoreboard
{
    public enum PointSide
    {
        Left,
        Right
    };

    public partial class Form1 : Form
    {
        public string AppName { get { return appName; } }
        private readonly string appName = "Simple MMA Scoreboard";

        public string AppCreator { get { return appCreator; } }
        private readonly string appCreator = "Kim19003";

        #region Variables
        // Fighter and judge names
        string fighter1, fighter2, judge;

        // Round amount
        int rounds_amount = 3;

        // Points
        int l_points1 = 0, l_points2 = 0, l_points3 = 0, l_points4 = 0, l_points5 = 0, l_cuts1 = 0, l_cuts2 = 0, l_cuts3 = 0,
        l_cuts4 = 0, l_cuts5 = 0, r_points1 = 0, r_points2 = 0, r_points3 = 0, r_points4 = 0, r_points5 = 0, r_cuts1 = 0,
        r_cuts2 = 0, r_cuts3 = 0, r_cuts4 = 0, r_cuts5 = 0;
        // ---
        #endregion

        #region FormDependencies
        public Form1()
        {
            InitializeComponent();

            MaximizeBox = false;

            comboBox11.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (comboBox11.Text == "3")
            {
                RoundAmount3();
                ClearAll();
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

        private void PointsComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ComboBox comboBox = sender as ComboBox;
                comboBox.Text = string.Empty;
                ResetPointBoxItems(comboBox);
                CalculateSidePoints(GetSide(comboBox));
            }
        }

        #region LeftPointBoxes
        // -- Left side --
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox1, comboBox21, ref l_points1, false, PointSide.Left);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox3, comboBox19, ref l_points2, false, PointSide.Left);
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox8, comboBox17, ref l_points3, false, PointSide.Left);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox6, comboBox15, ref l_points4, false, PointSide.Left);
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox10, comboBox13, ref l_points5, false, PointSide.Left);
        }

        #region LeftMinus
        // - Left minus -
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox2, null, ref l_cuts1, true, PointSide.Left);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox4, null, ref l_cuts2, true, PointSide.Left);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox7, null, ref l_cuts3, true, PointSide.Left);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox5, null, ref l_cuts4, true, PointSide.Left);
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox9, null, ref l_cuts5, true, PointSide.Left);
        }
        #endregion

        #endregion

        #region RightPointBoxes
        // -- Right side --
        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox21, comboBox1, ref r_points1, false, PointSide.Right);
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox19, comboBox3, ref r_points2, false, PointSide.Right);
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox17, comboBox8, ref r_points3, false, PointSide.Right);
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox15, comboBox6, ref r_points4, false, PointSide.Right);
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox13, comboBox10, ref r_points5, false, PointSide.Right);
        }

        #region RightMinus
        // - Right minus -
        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox20, null, ref r_cuts1, true, PointSide.Right);
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox18, null, ref r_cuts2, true, PointSide.Right);
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox16, null, ref r_cuts3, true, PointSide.Right);
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox14, null, ref r_cuts4, true, PointSide.Right);
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandlePoints(comboBox12, null, ref r_cuts5, true, PointSide.Right);
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
                RoundAmount5();
            }
            else
            {
                RoundAmount3();
            }
        }

        // Clear-button
        private void clearButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to reset the scoreboard?", appName, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                ClearAll();
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
            ClearRound1();
        }

        private void resetR2_Button_Click(object sender, EventArgs e)
        {
            ClearRound2();
        }

        private void resetR3_Button_Click(object sender, EventArgs e)
        {
            ClearRound3();
        }

        private void resetR4_Button_Click(object sender, EventArgs e)
        {
            ClearRound4();
        }

        private void resetR5_Button_Click(object sender, EventArgs e)
        {
            ClearRound5();
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
            DateTime DateTimeNow = DateTime.Now;

            SaveFileDialog fileDialog = new SaveFileDialog();
            if (!string.IsNullOrEmpty(fighter1) && !string.IsNullOrEmpty(fighter2))
            {
                fileDialog.FileName = $"{fighter1} vs. {fighter2} ({DateTimeNow.ToString("dd/MM/yyyy")})";
            }
            else
            {
                fileDialog.FileName = $"unnamed vs. unnamed ({DateTimeNow.ToString("dd/MM/yyyy")})";
            }
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            fileDialog.RestoreDirectory = true;

            int l_totalPoints = !string.IsNullOrEmpty(textBox2.Text) ? Convert.ToInt32(textBox2.Text) : 0;
            int r_totalPoints = !string.IsNullOrEmpty(textBox3.Text) ? Convert.ToInt32(textBox3.Text) : 0;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = fileDialog.InitialDirectory + fileDialog.FileName;

                if (!File.Exists(fileDialog.FileName))
                {
                    File.Create(fileDialog.FileName).Close();

                    using (StreamWriter sw = File.AppendText(fileDialog.FileName))
                    {
                        sw.WriteLine("[ DATE: " + DateTimeNow.ToString() + " ]"); // [ DATE: 1.1.2020 18.00.00 ]
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
                else
                {
                    File.WriteAllText(@directoryPath, string.Empty); // Overwrite the old file

                    using (StreamWriter sw = File.AppendText(fileDialog.FileName))
                    {
                        sw.WriteLine("[ SAVED: " + DateTimeNow.ToString() + " ]"); // [ SAVED: 1.1.2020 18.00.00 ]
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

            if (thisPointBoxPoints == 7 || thisPointBoxPoints == 8 || thisPointBoxPoints == 9)
            {
                relativePointBox.Items.Clear();
                relativePointBox.Items.Add(10);
                relativePointBox.SelectedIndex = 0;
            }
        }

        private void ResetPointBoxItems(ComboBox pointBox)
        {
            pointBox.Items.Clear();
            pointBox.Items.Add("-");
            pointBox.Items.Add(10);
            pointBox.Items.Add(9);
            pointBox.Items.Add(8);
            pointBox.Items.Add(7);
            pointBox.SelectedIndex = 0;
        }

        private bool PointsAllowed(ComboBox pointBox)
        {
            int thisPointBoxPoints = Convert.ToInt32(pointBox.Text);

            return thisPointBoxPoints == 7 || thisPointBoxPoints == 8 || thisPointBoxPoints == 9 || thisPointBoxPoints == 10;
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
        void ClearRound1()
        {
            l_points1 = 0;
            l_cuts1 = 0;

            r_points1 = 0;
            r_cuts1 = 0;

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox21.Enabled = true;
            comboBox20.Enabled = true;

            comboBox1.Text = null;
            comboBox1.SelectedIndex = 0;
            comboBox2.Text = null;
            comboBox2.SelectedIndex = 0;
            comboBox21.Text = null;
            comboBox21.SelectedIndex = 0;
            comboBox20.Text = null;
            comboBox20.SelectedIndex = 0;

            ResetPointBoxItems(comboBox1);
            ResetPointBoxItems(comboBox21);
        }

        void ClearRound2()
        {
            l_points2 = 0;
            l_cuts2 = 0;

            r_points2 = 0;
            r_cuts2 = 0;

            comboBox3.Enabled = true;
            comboBox4.Enabled = true;
            comboBox19.Enabled = true;
            comboBox18.Enabled = true;

            comboBox3.Text = null;
            comboBox3.SelectedIndex = 0;
            comboBox4.Text = null;
            comboBox4.SelectedIndex = 0;
            comboBox19.Text = null;
            comboBox19.SelectedIndex = 0;
            comboBox18.Text = null;
            comboBox18.SelectedIndex = 0;

            ResetPointBoxItems(comboBox3);
            ResetPointBoxItems(comboBox19);
        }

        void ClearRound3()
        {
            l_points3 = 0;
            l_cuts3 = 0;

            r_points3 = 0;
            r_cuts3 = 0;

            comboBox8.Enabled = true;
            comboBox7.Enabled = true;
            comboBox17.Enabled = true;
            comboBox16.Enabled = true;

            comboBox8.Text = null;
            comboBox8.SelectedIndex = 0;
            comboBox7.Text = null;
            comboBox7.SelectedIndex = 0;
            comboBox17.Text = null;
            comboBox17.SelectedIndex = 0;
            comboBox16.Text = null;
            comboBox16.SelectedIndex = 0;

            ResetPointBoxItems(comboBox8);
            ResetPointBoxItems(comboBox17);
        }

        void ClearRound4()
        {
            l_points4 = 0;
            l_cuts4 = 0;

            r_points4 = 0;
            r_cuts4 = 0;

            comboBox6.Enabled = true;
            comboBox5.Enabled = true;
            comboBox15.Enabled = true;
            comboBox14.Enabled = true;

            comboBox6.Text = null;
            comboBox6.SelectedIndex = 0;
            comboBox5.Text = null;
            comboBox5.SelectedIndex = 0;
            comboBox15.Text = null;
            comboBox15.SelectedIndex = 0;
            comboBox14.Text = null;
            comboBox14.SelectedIndex = 0;

            ResetPointBoxItems(comboBox6);
            ResetPointBoxItems(comboBox15);
        }

        void ClearRound5()
        {
            l_points5 = 0;
            l_cuts5 = 0;

            r_points5 = 0;
            r_cuts5 = 0;

            comboBox10.Enabled = true;
            comboBox9.Enabled = true;
            comboBox13.Enabled = true;
            comboBox12.Enabled = true;

            comboBox10.Text = null;
            comboBox10.SelectedIndex = 0;
            comboBox9.Text = null;
            comboBox9.SelectedIndex = 0;
            comboBox13.Text = null;
            comboBox13.SelectedIndex = 0;
            comboBox12.Text = null;
            comboBox12.SelectedIndex = 0;

            ResetPointBoxItems(comboBox10);
            ResetPointBoxItems(comboBox13);
        }

        private void TextBoxesClear()
        {
            // Fighters and total points
            textBox1.Text = null;
            textBox4.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;

            // Points
            comboBox1.Text = null;
            comboBox1.SelectedIndex = 0;
            comboBox2.Text = null;
            comboBox2.SelectedIndex = 0;
            comboBox3.Text = null;
            comboBox3.SelectedIndex = 0;
            comboBox4.Text = null;
            comboBox4.SelectedIndex = 0;
            comboBox5.Text = null;
            comboBox5.SelectedIndex = 0;
            comboBox6.Text = null;
            comboBox6.SelectedIndex = 0;
            comboBox7.Text = null;
            comboBox7.SelectedIndex = 0;
            comboBox8.Text = null;
            comboBox8.SelectedIndex = 0;
            comboBox9.Text = null;
            comboBox9.SelectedIndex = 0;
            comboBox10.Text = null;
            comboBox10.SelectedIndex = 0;
            comboBox12.Text = null;
            comboBox12.SelectedIndex = 0;
            comboBox13.Text = null;
            comboBox13.SelectedIndex = 0;
            comboBox14.Text = null;
            comboBox14.SelectedIndex = 0;
            comboBox15.Text = null;
            comboBox15.SelectedIndex = 0;
            comboBox16.Text = null;
            comboBox16.SelectedIndex = 0;
            comboBox17.Text = null;
            comboBox17.SelectedIndex = 0;
            comboBox18.Text = null;
            comboBox18.SelectedIndex = 0;
            comboBox19.Text = null;
            comboBox19.SelectedIndex = 0;
            comboBox20.Text = null;
            comboBox20.SelectedIndex = 0;
            comboBox21.Text = null;
            comboBox21.SelectedIndex = 0;
        }

        private void BoxVisibilityClear()
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

        private void OtherVariablesClear()
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

        private void ClearAll()
        {
            // Rounds selector
            comboBox11.Text = "3";
            comboBox11.SelectedIndex = 0;
            rounds_amount = 3;

            // Others
            TextBoxesClear();
            BoxVisibilityClear();
            OtherVariablesClear();
            ResetAllPointBoxItems();
        }
        #endregion

        #region RoundAmount
        void RoundAmount5()
        {
            rounds_amount = 5;

            if (!comboBox6.Enabled)
            {
                comboBox6.Enabled = true;
                comboBox6.Text = null;
                comboBox6.SelectedIndex = 0;
            }
            if (!comboBox10.Enabled)
            {
                comboBox10.Enabled = true;
                comboBox10.Text = null;
                comboBox10.SelectedIndex = 0;
            }
            if (!comboBox5.Enabled)
            {
                comboBox5.Enabled = true;
                comboBox5.Text = null;
                comboBox5.SelectedIndex = 0;
            }
            if (!comboBox9.Enabled)
            {
                comboBox9.Enabled = true;
                comboBox9.Text = null;
                comboBox9.SelectedIndex = 0;
            }
            if (!comboBox13.Enabled)
            {
                comboBox13.Enabled = true;
                comboBox13.Text = null;
                comboBox13.SelectedIndex = 0;
            }
            if (!comboBox15.Enabled)
            {
                comboBox15.Enabled = true;
                comboBox15.Text = null;
                comboBox15.SelectedIndex = 0;
            }
            if (!comboBox14.Enabled)
                {
                comboBox14.Enabled = true;
                comboBox14.Text = null;
                comboBox14.SelectedIndex = 0;
            }
            if (!comboBox12.Enabled)
            {
                comboBox12.Enabled = true;
                comboBox12.Text = null;
                comboBox12.SelectedIndex = 0;
            }

            resetR4_Button.Enabled = true;
            resetR5_Button.Enabled = true;

            CalculateSidePoints(PointSide.Left);
            CalculateSidePoints(PointSide.Right);
        }

        void RoundAmount3()
        {
            rounds_amount = 3;

            comboBox6.Enabled = false;
            comboBox10.Enabled = false;
            comboBox5.Enabled = false;
            comboBox9.Enabled = false;
            comboBox6.Text = null;
            comboBox6.SelectedIndex = 0;
            comboBox10.Text = null;
            comboBox10.SelectedIndex = 0;
            comboBox5.Text = null;
            comboBox5.SelectedIndex = 0;
            comboBox9.Text = null;
            comboBox9.SelectedIndex = 0;

            comboBox13.Enabled = false;
            comboBox15.Enabled = false;
            comboBox14.Enabled = false;
            comboBox12.Enabled = false;
            comboBox13.Text = null;
            comboBox13.SelectedIndex = 0;
            comboBox15.Text = null;
            comboBox15.SelectedIndex = 0;
            comboBox14.Text = null;
            comboBox14.SelectedIndex = 0;
            comboBox12.Text = null;
            comboBox12.SelectedIndex = 0;

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

            CalculateSidePoints(PointSide.Left);
            CalculateSidePoints(PointSide.Right);
        }
        #endregion

        #region Methods
        private void HandlePoints(ComboBox thisPointsBox, ComboBox relationPointsBox, ref int thisPoints, bool isMinus, PointSide pointSide)
        {
            if (!string.IsNullOrEmpty(thisPointsBox.Text))
            {
                if (thisPointsBox.Text == "-")
                {
                    thisPoints = 0;
                    CalculateSidePoints(pointSide);
                }
                else if (PointsAllowed(thisPointsBox) || isMinus)
                {
                    if (!isMinus)
                    {
                        PointsForerunner(thisPointsBox, relationPointsBox);
                    }

                    thisPoints = Convert.ToInt32(thisPointsBox.Text);
                    CalculateSidePoints(pointSide);
                }
            }
        }

        private void CalculateSidePoints(PointSide pointSide)
        {
            int totalPoints;
            switch (pointSide)
            {
                case PointSide.Left:
                    totalPoints = (l_points1 + l_points2 + l_points3 + l_points4 + l_points5) - (l_cuts1 + l_cuts2 + l_cuts3 + l_cuts4 + l_cuts5);
                    textBox2.Text = totalPoints > 0 ? Convert.ToString(totalPoints) : string.Empty;
                    break;
                case PointSide.Right:
                    totalPoints = (r_points1 + r_points2 + r_points3 + r_points4 + r_points5) - (r_cuts1 + r_cuts2 + r_cuts3 + r_cuts4 + r_cuts5);
                    textBox3.Text = totalPoints > 0 ? Convert.ToString(totalPoints) : string.Empty;
                    break;
            }
        }

        private PointSide GetSide(ComboBox comboBox)
        {
            if (comboBox == comboBox1 || comboBox == comboBox3 || comboBox == comboBox8 || comboBox == comboBox6 || comboBox == comboBox10
                || comboBox == comboBox2 || comboBox == comboBox4 || comboBox == comboBox7 || comboBox == comboBox5 || comboBox == comboBox9)
            {
                return PointSide.Left;
            }
            else if (comboBox == comboBox21 || comboBox == comboBox19 || comboBox == comboBox17 || comboBox == comboBox15 || comboBox == comboBox13
                || comboBox == comboBox20 || comboBox == comboBox18 || comboBox == comboBox16 || comboBox == comboBox14 || comboBox == comboBox12)
            {
                return PointSide.Right;
            }

            throw new ArgumentException("comboBox not recognized");
        }
        #endregion
    }
}