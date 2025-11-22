using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cp_lab_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            // Створюємо екземпляри класу CaseTransistors з допомогою конструктора з параметрами
            // (Тут типи транзисторів обрано навмання, вони не відповідають своїм іменам)
            CaseTransistors MyTr = new CaseTransistors(5, "Bipolar", "AC126", "EbbersMoll");
            CaseTransistors MyTr1 = new CaseTransistors(1, "Field-effet", "AC126", "Gummel-Poon");
            CaseTransistors MyTr2 = new CaseTransistors(1, "Field-effet", "AD133", "Gummel-Poon");
            CaseTransistors MyTr3 = new CaseTransistors(1, "Schottky", "BD139", "Gummel-Poon");
            CaseTransistors MyTr4 = new CaseTransistors(1, "Avalanche", "OO117", "EbbersMoll");
            CaseTransistors MyTr5 = new CaseTransistors(1, "Darlington", "BLW34", "EbbersMoll");
            CaseTransistors MyTr6 = new CaseTransistors(1, "Photo", "BU508", "EbbersMoll");
            CaseTransistors MyTr7 = new CaseTransistors(1, "Bipolar", "CLY10", "EbbersMoll");
            // Поміщаємо створені транзистори у масив транзисторів з допомогою індексатора. 
            // Перевіряємо код завершення після кожної операції
            // Накопичуємо інформацію про хід роботи програми у змінній sMessage
            string sMessage = " ";
            MyTr[0] = MyTr1;
            if (MyTr.ErrorKod > 0) sMessage += "\n 1 Транзистор не додано " + MyTr1.TransName + " код помилки - " + MyTr.ErrorKod.ToString(); 
            else sMessage += "\n 1 Транзистор додано " + MyTr1.TransName + " ";
            MyTr[1] = MyTr2;
            if (MyTr.ErrorKod > 0) sMessage += "\n 2 Транзистор не додано " + MyTr2.TransName + " код помилки - " + MyTr.ErrorKod.ToString(); 
            else sMessage += "\n 2 Транзистор додано " + MyTr2.TransName + " ";
            MyTr[2] = MyTr3;
            if (MyTr.ErrorKod > 0) sMessage += "\n 3 Транзистор не додано " + MyTr3.TransName + " код помилки - " + MyTr.ErrorKod.ToString(); 
            else sMessage += "\n 3 Транзистор додано " + MyTr3.TransName + " ";
            MyTr[3] = MyTr4;
            if (MyTr.ErrorKod > 0) sMessage += "\n 4 Транзистор не додано " + MyTr4.TransName + " код помилки - " + MyTr.ErrorKod.ToString(); 
            else sMessage += "\n 4 Транзистор додано " + MyTr4.TransName + " ";
            MyTr[4] = MyTr5;
            if (MyTr.ErrorKod > 0) sMessage += "\n 5 Транзистор не додано " + MyTr5.TransName + " код помилки - " + MyTr.ErrorKod.ToString(); 
            else sMessage += "\n 5 Транзистор додано " + MyTr5.TransName + " ";
            MyTr[5] = MyTr6;
            if (MyTr.ErrorKod > 0) sMessage += "\n 6 Транзистор не додано " + MyTr6.TransName + " код помилки - " + MyTr.ErrorKod.ToString(); 
            else sMessage += "\n 6 Транзистор додано " + MyTr6.TransName + " ";
            MyTr[6] = MyTr7;
            if (MyTr.ErrorKod > 0) sMessage += "\n 7 Транзистор не додано " + MyTr7.TransName + " кодпомилки - " + MyTr.ErrorKod.ToString(); 
            else sMessage += "\n 7 Транзистор додано " + MyTr7.TransName + " ";
            label1.Text = sMessage;
            // Виведемо інформацію про додані (чи не додані) транзистори у мітку label1
            // Сформуємо інформацію про записані транзистори з допомогою перевизначеного нами методу ToString у
            // змінній sMessage
            sMessage = "";
            for (int i = 0; i < MyTr.Length; i++)
            {
                if (MyTr[i] != null) sMessage += "\n " + MyTr[i].ToString();
            }
            label2.Text = sMessage;
        }

    }
}
