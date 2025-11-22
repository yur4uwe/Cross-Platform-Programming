using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void OnCarEngineEvent1(string msg)
        {
            label1.Text += msg + "\n";
        }

        public void OnCarEngineEvent2(string _)
        {
            label2.Text += "Пробіг:" + Car.distance.ToString() + "км. \n";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            // Створюємо об'єкт типу Car 
            Car myCar = new Car("Старенький Запорожець", 100, 0);
            // Створюємо метод, адресу якого будемо передавати делегату 
            // Створимо змінну типу делегат і зашлемо в неї адресу методу, який буде викликатись через цю змінну 
            // Змінено 
            Car.CarEngineHandler myDelegat1 = new Car.CarEngineHandler(OnCarEngineEvent1);
            Car.CarEngineHandler myDelegat2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            /* Звернемось до методу RegisterWithCarEngine, щоб вказати метод, який повинен викликатись 
            (зареєструвати) */
            myCar.RegisterWithCarEngine(myDelegat1);
            myCar.RegisterWithCarEngine(myDelegat2);
            // Ми можемо викликати метод OnCarEngineEvent і поза делегатом 
            OnCarEngineEvent1("Стартуємо");
            // Змінюємо швидкість автомобіля і відслідковуємо, що буде 
            for (int i = 0; i < 11; i++)
                myCar.Accelerate(10);
        }
    }
}
