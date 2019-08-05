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

            // TODO: Fix the display of the array list  
            // displaying the data
            if (workingSet.Length == 0)
            {
                workingSet = "0";
            }

            if (wholeEquation.Count > 0)
            {
                display.Text = wholeEquation + "\r\n" + workingSet;
            }
            else
            {
                display.Text = workingSet;
            }
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
            if (workingSet != "0") {
                wholeEquation.Add(workingSet);
            }

            // TODO: Add code for operational buttons
            MessageBox.Show((String)wholeEquation[0]);

            //if ("/*-+".Contains(wholeEquation[wholeEquation.Count - 1].ToString())) {
            //    wholeEquation[wholeEquation.Count - 1] = input;
            //} else {
            //    wholeEquation.Add(input);
            //}
        }
    }
}
