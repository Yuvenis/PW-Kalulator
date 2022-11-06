using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Dodawanie tekstu w przycisku do stringa kalkulacji
            currentCalculation += (sender as Button).Text;

            // Wyświetlanie kodu w okienku
            WynikBox.Text = currentCalculation;
        }

        private void button_Rowna(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString().Replace("X", "*").ToString().Replace("÷", "/");

            try
            {
                WynikBox.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = WynikBox.Text;
            }
            catch (Exception ex)
            {
                WynikBox.Text = "0";
                currentCalculation = "";
            }
        }

        private void button_czysc(object sender, EventArgs e)
        {
            WynikBox.Text = "0";
            currentCalculation = "";
        }

        private void button_czysc_ostatnie(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            WynikBox.Text = currentCalculation;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
