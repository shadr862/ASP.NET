using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_calculator
{
    public partial class Form1 : Form
    {
        public double value=0,input=0;
        public char last_operation = ' ';
        public string coming_from = " ";
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("riaz", "Alert", MessageBoxButtons.YesNo);
            //textName.Text = "1";
             input = input * 10 + 1;
             textName.Text = input.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            value -= input;
            input = 0;
            last_operation = '-';
            textName.Text = value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (value == 0)
            {
                value = input;
            }
            else if(coming_from!="=")
            {
                value *= input;
            }
          
            input = 0;
            last_operation = 'x';
            coming_from = " ";
            textName.Text = value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(value == 0)
            {
                value = input;
            }
            else if(coming_from!="=")
            {
                value /= input;
            }
            Console.WriteLine(value);
            input = 0;
            last_operation = '%';
            coming_from = " ";
            textName.Text = value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(last_operation == '+')
            {
                value += input;
            }
            else if(last_operation=='-')
            {
                value -= input;
            }
            else if (last_operation == 'x')
            {
                value *= input;
            }
            else if (last_operation == '%')
            {
                value /= input;
                Console.WriteLine(value);
            }
            input = 0;
            last_operation = ' ';
            coming_from = "=";
            textName.Text = value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            input = 0;
            value = 0;
            last_operation = ' ';
            textName.Text = " ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            input = input * 10 + 2;
            textName.Text = input.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            input = input * 10 + 3;
            textName.Text = input.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            input = input * 10 + 4;
            textName.Text = input.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            input = input * 10 + 5;
            textName.Text = input.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            input = input * 10 + 6;
            textName.Text = input.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            input = input * 10 + 7;
            textName.Text = input.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            input = input * 10 + 8;
            textName.Text = input.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            input = input * 10 + 9;
            textName.Text = input.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            input = input * 10 + 0;
            textName.Text = input.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            value += input;
            input = 0;
            last_operation = '+';
            textName.Text = value.ToString();
        }
    }
}
