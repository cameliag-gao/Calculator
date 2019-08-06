using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        // Public Variables
        public string workingSet = "";
        public ArrayList wholeEquation = new ArrayList();


        private void onClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            switch(btn.Text)
            {
                case "CE":
                    if (wholeEquation.Count > 0) {
                        wholeEquation.Clear();
                    }
                    workingSet = "";
                    break;
                case "C":
                    workingSet = "";
                    break;
                case "DEL":
                    if (workingSet.Length > 0)
                    {
                        workingSet = workingSet.Substring(0, workingSet.Length - 1);
                    }
                    break;
                case "=":
                    break;
                case "+/-":
                    break;
                default:
                    if ("0123456789.".Contains(btn.Text)) {
                        buildWorkingSet(btn.Text);
                    } else if ("/*-+".Contains(btn.Text)) {
                        buildEquation(btn.Text);
                    } else {
                        MessageBox.Show("Warning! Invalid button " + btn.Text);
                    }
                    break;
            }

            // always show 0 for the input number
            if (workingSet.Length == 0)
            {
                workingSet = "0";
            }

            // display the historical input data
            if (wholeEquation.Count > 0)
            {
                equation.Text = "";

                foreach (String s in wholeEquation) {
                    equation.Text += s + " ";
                }

                display.Text = "";
            }

            display.Text = workingSet;
        }

        private void buildWorkingSet (String input)
        {
            /* if the first number is 0 (zero) replace it with the next input number unless it is a dot (.)
             * if it is a dot (.) add it behind the zero instead */
            if (workingSet == "0") {
                if (input == ".") {
                    workingSet += input;
                } else {
                    workingSet = input;
                }
            } else if (!(input == "." && workingSet.Contains(input))) { //if decimal already exist do not add another one
                workingSet += input;
            }
        }

        private void buildEquation (string input)
        {
            int wholeEquationLastIndex;

            if (workingSet.Last().ToString() == ".") {
                workingSet = workingSet.Substring(0, workingSet.Length - 1);
            }

            wholeEquation.Add(workingSet);
            workingSet = "";

            wholeEquationLastIndex = wholeEquation.Count - 1;

            if ("/*-+".Contains((String)wholeEquation[wholeEquationLastIndex].ToString())) {
                wholeEquation[wholeEquationLastIndex] = input;
            } else {
                wholeEquation.Add(input);
            }
        }
    }
}
