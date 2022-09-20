using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temperature_Converter
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();

        }

        //Events

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_units_input.Text = "Celsius";
            cmb_units_input.Items.Add("Celsius");
            cmb_units_input.Items.Add("Fahrenheit");
            cmb_units_input.Items.Add("Kelvin");

            cmb_units_output.Text = "Fahrenheit";
            cmb_units_output.Items.Add("Celsius");
            cmb_units_output.Items.Add("Fahrenheit");
            cmb_units_output.Items.Add("Kelvin");
        }

        private void btn_calc_clear_Click(object sender, EventArgs e)
        {
            lbl_temp_input.Text = "0"; //return input to 0 (default)
            UpdateOutput();
        }
      
        private void btn_calc_delete_Click(object sender, EventArgs e)
        {
            if (lbl_temp_input.Text != "0")
            {
                lbl_temp_input.Text = lbl_temp_input.Text.Remove(lbl_temp_input.Text.Length - 1); //remove last element of string
            }
            UpdateOutput();
        }

        private void btn_calc_plusMinus_Click(object sender, EventArgs e)
        {
            if (lbl_temp_input.Text.Contains("-")) //if number is negative
            {
                lbl_temp_input.Text = lbl_temp_input.Text.Remove(0, 1); //remove the - from the start
            }
            else
            {
                lbl_temp_input.Text = "-" + lbl_temp_input.Text; //add a - to the start
            }

            UpdateOutput();
        }

        private void number_calc(object sender, EventArgs e)
        {
            //fires when numerical buttons on the calculator are clicked

            Button temp_btn = (Button)sender; //get sender as button

            if (lbl_temp_input.Text == "0") //remove the 0 if we are set to the default value.
            {
                lbl_temp_input.Text = "";
            }

            if (temp_btn.Text == ".") // if button clicked is a decimal
            {
               

                if (lbl_temp_input.Text.Contains(".")) //if our text aready has a decimal
                {
                   lbl_temp_input.Text = lbl_temp_input.Text.Replace(".", ""); //removes the decimal point
                }
                else
                {
                    Console.WriteLine("dec");
                    lbl_temp_input.Text += ".";//adds the decimal point
                }
                //#TODO FIX THSI
            }
            else
            {
                lbl_temp_input.Text += temp_btn.Text;//adds the clicked button to our input
            }

            UpdateOutput();
           
        }
        private void UpdateOutputHelper(object sender, EventArgs e)
        {
            UpdateOutput();
        }

        //Functions
        private double calculateTemp()
        {
            double inputTemp = double.Parse(lbl_temp_input.Text);
            if (cmb_units_input.Text == "Celsius")
            {
                if (cmb_units_output.Text == "Celsius")
                {
                    return inputTemp; //converting celsius to celsius, just return.
                }
                else if (cmb_units_output.Text == "Fahrenheit")
                {
                    //Formula
                    //(0°C × 9 / 5) +32 = 32°F

                    return (inputTemp * 9 / 5) + 32;

                }
                else if (cmb_units_output.Text == "Kelvin")
                {
                    //Formula
                    //0°C + 273.15 = 273.15K

                    return inputTemp + 273.15;

                }
            }
            else if (cmb_units_input.Text == "Fahrenheit")
            {
                if (cmb_units_output.Text == "Celsius")
                {

                    //Formula
                    //(32°F − 32) × 5 / 9 = 0°C
                    return (inputTemp-32)*5 / 9;
                }
                else if (cmb_units_output.Text == "Fahrenheit")
                {
                    return inputTemp; //converting fahr to fahr, just return.
                }
                else if (cmb_units_output.Text == "Kelvin")  //#TODO TEST this
                {

                    //  Formula
                    // (32°F − 32) × 5 / 9 + 273.15 = 273.15K

                    return (inputTemp-32)*5 / 9 + 273.15;

                }
            }
            else if (cmb_units_input.Text == "Kelvin")
            {
                if (cmb_units_output.Text == "Celsius")
                {
                    //Formula
                    //0K - 273.15 = 273.15°C

                    return inputTemp - 273.15;
                }
                else if (cmb_units_output.Text == "Fahrenheit")
                {
                    // Formula
                    //(0K − 273.15) × 9 / 5 + 32 = -459.7°F
                   return (inputTemp - 273.15) * 9 / 5 + 32;
                }
                else if (cmb_units_output.Text == "Kelvin")
                {
                    return inputTemp; //converting kelvin to kelvin, just return.
                }

            }
            
            
            Console.WriteLine("Error with temp unit input");
            return 0;
        }


        private void UpdateOutput()
        {

            lbl_convert_output.Text = calculateTemp().ToString();
        }
        
    }
}
