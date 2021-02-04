using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1Lab
{
    enum Sign
    {
        Null,
        Plus,
        Minus,
        Del,
        Proch,        
        Multiply,
        ProchDel
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }
        Calculator calc = new Calculator();
        private void ButtonSign_Click(object sender, EventArgs e)
        {
            try
            {
                CheckNull();
                calc.Equally();
                textBox2.Text = calc.a.ToString();
                string strSign = (sender as Button).Text;
                calc.sign = calc.CheckSign(strSign);
                textBox1.Text = "0";
            }
            catch
            {
                textBox2.Text = "Error";
                textBox1.Text = "0";
            }            
        }
        private void ButtonNumber_Click(object sender, EventArgs e)
        {
            string strNumber = (sender as Button).Text;
            if (textBox1.Text == "0")
                textBox1.Text = strNumber;
            else if (textBox1.Text[textBox1.Text.Length - 1] == ',' && strNumber == ",");
            else
                textBox1.Text += strNumber;
        }
        /// <summary>
        /// проверка числа в ответе и знака
        /// </summary>
        void CheckNull()
        {
            if (calc.a == 0 && calc.sign == Sign.Null)
            {
                calc.a = float.Parse(textBox1.Text);
                textBox2.Text = textBox1.Text;
            }
            else if (textBox1.Text != "0" && calc.sign == Sign.Null)
            {
                calc.a = float.Parse(textBox1.Text);
            }
            else
                calc.b = float.Parse(textBox1.Text);
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 1)
                textBox1.Text = "0";
            else
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            calc.buf = 0;
            textBox3.Text = "0";
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            calc.a = 0;
            calc.b = 0;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            calc.buf = calc.a;
            textBox3.Text = calc.buf.ToString();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = calc.buf.ToString();
        }
    }
    class Calculator
    {
        public float a = 0;
        public float b = 0;
        public float buf = 0;
        public Sign sign = Sign.Null;
        /// <summary>
        /// Установление знака "+, - и т.д."
        /// </summary>
        /// <param name="strSign"></param>
        /// <returns></returns>
        public Sign CheckSign(string strSign)
        {            
            switch (strSign)
            {
                case "-":
                    sign = Sign.Minus;
                    break;
                case "+":
                    sign = Sign.Plus;
                        break;
                case "*":
                    sign = Sign.Multiply;
                        break;
                case "/":
                    sign = Sign.Del;
                        break;
                case "%":
                    sign = Sign.Proch;
                        break;
                case "/%":
                    sign = Sign.ProchDel; 
                        break;
                case "=":
                    sign = Sign.Null;
                    break;
            }
            return sign;
        }            
        /// <summary>
        /// Подсчёт ответа
        /// </summary>
        public void Equally()
        {
            switch (sign)
            {
                case (Sign.Plus):
                    a += b;
                    break;
                case (Sign.Minus):
                    a -= b;
                    break;
                case (Sign.Del):
                    a /= b;
                    break;
                case (Sign.Multiply):
                    a *= b;
                    break;
                case (Sign.Proch):
                    a = (int)a % (int)b;
                    break;
                case (Sign.ProchDel):
                    a = (int)a / (int)b;
                    break;
            }
        }
    }
    
}

