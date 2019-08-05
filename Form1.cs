using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        public string prevEquation = "";
        public string prevOperation = "";
        public string operation = "";

        private void onClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch(btn.Text)
            {
                case "0":
                    display.Text += "0";
                    break;
                case "1":
                    display.Text += "1";
                    break;
                case "2":
                    display.Text += "2";
                    break;
                case "3":
                    display.Text += "3";
                    break;
                case "4":
                    display.Text += "4";
                    break;
                case "5":
                    display.Text += "5";
                    break;
                case "6":
                    display.Text += "6";
                    break;
                case "7":
                    display.Text += "7";
                    break;
                case "8":
                    display.Text += "8";
                    break;
                case "9":
                    display.Text += "9";
                    break;
                case "CE":
                    if (display.Text.Length > 0)
                    {
                        display.Text = "";
                    }
                    break;
                case "C":
                    break;
                case "DEL":
                    if (display.Text.Length > 0)
                    {
                        display.Text = display.Text.Substring(0, display.Text.Length - 1);
                    }
                    break;
                case "/":
                    break;
                case "X":
                    break;
                case "-":
                    break;
                case "+":
                    break;
                case "=":
                    break;
                case "+/-":
                    break;
                case ".":
                    break;
            }
        }
    }
}
