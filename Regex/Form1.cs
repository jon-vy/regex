using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Regular_Expression
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region

        string r_1 = ".";
        string r_2;
        string text_Box_2;
        string text_Box_3;
        string text_Box_4;
        string text_Box_5;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                r_1 = "[\\w\\W]";
            }
            else
            {
                r_1 = ".";
            }
            textBox7.Text = "";
            textBox1.Text = text_Box_2 + text_Box_3 + r_1 + "*" + r_2 + text_Box_4 + text_Box_5;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                r_2 = "?";
            }
            else
            {
                r_2 = "";
            }
            textBox7.Text = "";
            
            textBox1.Text = text_Box_2 + text_Box_3 + r_1 + "*" + r_2 + text_Box_4 + text_Box_5;
            
        }

        //Перед искомым выражением всегда есть: (?<=1)
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                text_Box_2 = "(?<=" + Regex.Escape(textBox2.Text) + ")";
            }
            else
                text_Box_2 = "";

            textBox7.Text = "";
            
            textBox1.Text = text_Box_2 + text_Box_3 + r_1 + "*" + r_2 + text_Box_4 + text_Box_5;
        }

        //Искомый текст начинается с: 
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = "";
            
            text_Box_3 = Regex.Escape(textBox3.Text);
            textBox1.Text = text_Box_2 + text_Box_3 + r_1 + "*" + r_2 + text_Box_4 + text_Box_5;
        }

        //Это идёт после искомого текста: (?=4)
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                text_Box_4 = "(?=" + Regex.Escape(textBox4.Text) + ")";
            }
            else text_Box_4 = "";
            {
                textBox1.Text = text_Box_2 + text_Box_3 + r_1 + "*" + r_2 + text_Box_4 + text_Box_5;
            }
            textBox7.Text = "";
            
        }

        //Этим заканчивается искомый текст:
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            text_Box_5 = Regex.Escape(textBox5.Text);
            textBox1.Text = text_Box_2 + text_Box_3 + r_1 + "*" + r_2 + text_Box_4 + text_Box_5;
            textBox7.Text = "";
            
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            string text =textBox6.Text.ToString();
            string pattern = textBox1.Text.ToString();
            Regex rezult = new Regex(pattern);
            MatchCollection rez = rezult.Matches(text);
            int count = 0;
            textBox7.Text = "№" + "|" + "совпадения" + "\r\n";
            textBox7.Text += "------------------------------------------------------------------" + "\r\n";
            foreach (Match match in rez)
            {
                textBox7.Text += count + "  |  " + (match.ToString() + "\r\n");
                textBox7.Text += "------------------------------------------------------------------" + "\r\n";
                count++;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("jon_vy@mail.ru");
        }
    }
}
