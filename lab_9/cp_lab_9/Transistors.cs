using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_9
{
    internal class CaseTransistors
    {
        public string TransType { get; set; } // тип транзистора
        public string TransName { get; set; } // назва транзистора
        public string TransModelName { get; set; } // назва математичної моделі транзистора
        TransPrefixName[] Prefixs; // масив для зберігання правильних префіксів імен транзисторів
        CaseTransistors[] transistors; // масив для зберігання транзисторів із модифікатором 
                                        // доступу private (за замовчуванням)
        public int Length; // кількість транзисторів у масиві
        public int ErrorKod; // код завершення операції записування або читання
                             // 0 - все добре, 1 - поганий індекс, 2 - поганий префікс імені
                             // Конструктор класу CaseTransistors, у якому створюємо масив для зберігання транзисторів - екземплярів 
                             // класу CaseTransistors
        public CaseTransistors(int size, string type, string tname, string modelName)
        {
            transistors = new CaseTransistors[size]; // створюємо масив розміру,який задано у параметрі size
            Length = size;
            SetPrefixName(); // заповнюємо масив структур префіксів імен транзисторів можливими значеннями
            TransType = type;
            TransName = tname;
            TransModelName = modelName;
        } // завершення тіла конструктора

        // Структура transPrefixName, яка призначена для оголошення префіксів імен транзисторів
        struct TransPrefixName
        {
            public string PrefixName; // ім'я префіксу
            public string PrefixText; // пояснення значення префіксу
        }

        public override string ToString() // перевизначений метод для видачі інформації про транзистор
        {
            return " Транзистор " + TransName + " Тип- " + TransType + " модель- " + TransModelName;
        }

        void SetPrefixName()
        {
            // Масив структур для зберігання правильних префіксів імен транзисторів
            Prefixs = new TransPrefixName[14];
            // Ця довідкова інформація є реальною. Див. http://en.wikipedia.org/wiki/Transistor
            Prefixs[0].PrefixName = "AC"; Prefixs[0].PrefixText = "Germanium small-signal AF transistor AC126";
            Prefixs[1].PrefixName = "AD"; Prefixs[1].PrefixText = "Germanium AF power transistor AD133";
            Prefixs[2].PrefixName = "AF"; Prefixs[2].PrefixText = "Germanium small-signal RF transistor AF117";
            Prefixs[3].PrefixName = "AL"; Prefixs[3].PrefixText = "Germanium RF power transistor ALZ10";
            Prefixs[4].PrefixName = "AS"; Prefixs[4].PrefixText = "Germanium switching transistor ASY28";
            Prefixs[5].PrefixName = "AU"; Prefixs[5].PrefixText = "Germanium power switching transistor AU103";
            Prefixs[6].PrefixName = "BC"; Prefixs[6].PrefixText = "Silicon, small signal transistor BC548B";
            Prefixs[7].PrefixName = "BD"; Prefixs[7].PrefixText = "Silicon, power transistor BD139";
            Prefixs[8].PrefixName = "BF"; Prefixs[8].PrefixText = "Silicon, RF (high frequency) BJT or FET BF245";
            Prefixs[9].PrefixName = "BS"; Prefixs[9].PrefixText = "Silicon, switching transistor (BJT or MOSFET) BS170";
            Prefixs[10].PrefixName = "BL"; Prefixs[10].PrefixText = "Silicon, high frequency, high power (for transmitters) BLW34";
            Prefixs[11].PrefixName = "BU"; Prefixs[11].PrefixText = "Silicon, high voltage (for CRT horizontal deflection circuits) BU508";
            Prefixs[12].PrefixName = "CF"; Prefixs[12].PrefixText = "Gallium Arsenide small-signal Microwave transistor(MESFET) CF300";
            Prefixs[13].PrefixName = "CL"; Prefixs[13].PrefixText = "Gallium Arsenide Microwave power transistor (FET) CLY10";
        }

        bool OkPrefixName(string prefix) // метод для визначення правильності префіксу в імені транзистора
        {
            for (int i = 0; i < 14; i++)
            {
                if (Prefixs[i].PrefixName == prefix) return true;
            }
            return false;
        }

        bool OkIndex(int i) // метод для визначення правильності індексу
        {
            if (i >= 0 && i < Length) return true;
            else return false;
        }

        public CaseTransistors this[int index] // індексатор для класу CaseTransistors по полю transistors
        {
            get // вибрати об'єкт типу транзистор з індексом index
            {
                if (OkIndex(index)) // якщо правильний індекс, то повертаємо елемент масиву і код завершення 0
                {
                    ErrorKod = 0;
                    return transistors[index];
                }
                else
                {
                    ErrorKod = 1; // якщо індекс не правильний, то повертаємо null і код завершення 1
                    return null;
                }
            }
            set // записати транзистор у масив транзисторів у елемент з індексом index
            {
                // Перед записом транзистора у масив перевіряємо індекс,
                if (!OkIndex(index))
                {
                    ErrorKod = 1;
                    return;
                }
                // а також перевіряємо, чи належать 2 перших символи імені до таблиці префіксів імен транзисторів
                // Якщо префікс не правильний, то повертаємо код завершення 2 і транзистор у бібліотеку не записуємо
                if (!OkPrefixName(value.TransName.Substring(0, 2)))
                {
                    ErrorKod = 2;
                    return;
                }
                transistors[index] = value; // Якщо індекс та ім'я правильні, то записуємо транзистор, який 
                                            // передано у змінній value у масив транзисторів
                ErrorKod = 0; // і встановлюємо код завершення 0
            }
        }
    }
}
