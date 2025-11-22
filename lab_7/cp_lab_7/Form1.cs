using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace cp_lab_7
{
    public enum stanBalla // це перелічуваний тип (нумератор)
    {
        vGriA, // м'яч у грі у команди А
        vGriB, // м'яч у грі у команди В
        pozaGroju, // м'яч поза грою
        vCentri, // м'яч в центрі поля
        vVorotahA, // м'яч у воротах команди А
        vVorotahB // м'яч у воротах команди В
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            appendToLabel1 = SetOutputStream(label1);
            appendToLabel2 = SetOutputStream(label2);
        }

        public delegate void LabelWriter(params object[] entries);
        /* Програма ілюструє такі поняття ООП, як поліморфізм і успадкування. 
         * На основі базового класу Sphere створено класи-нащадки Ball i povitrjana_kulja
         * На основі класу Ball створено клас FootBall. 
         * Клас Sphere має методи: kotytys, letity, udar. 
         * Клас Ball має методи: popav, letity, letityBase. 
         * Клас FootBall має методи: popav - з сигнатурою, такою, як у класі Ball, 
         * i, тому, з модифікатором override, 
         * popav - з сигнатурою, відмінною від сигнатури цього методу у класі Ball, i 
         * popavBase - метод, для викликання методу popav базового класу Ball, 
         * а також метод letity з сигнатурою такою, як у класу Sphere, 
         * і тому з модифікатором override. 
         * Крім того, цей клас має конструктор з параметром. 
         * Усі методи поміщають у рядок sumText повідомлення про свою роботу. 
         * Цей рядок ми виводимо у текст мітки Label2 на формі. 
         * У текст мітки Label1 помістимо план нашої роботи - який метод, на нашу думку, буде викликатись. 
         * Потім порівняємо з результатами роботи. */
        public static string newline = "\r"; // Змінна для переходу на новий рядок у повідомленнях методів.
        public static LabelWriter appendToLabel1 = null;
        public static LabelWriter appendToLabel2 = null;
        public static int j = 1;


        public LabelWriter SetOutputStream(Label dest)
        {
            if (dest == null) throw new ArgumentNullException(nameof(dest));

            return entries =>
            {
                // Build the text entry from provided objects
                string entry = "";
                if (entries != null && entries.Length > 0)
                {
                    for (int k = 0; k < entries.Length; k++)
                    {
                        var o = entries[k];
                        entry += o?.ToString() ?? "null";
                    }
                }

                if (string.IsNullOrEmpty(dest.Text))
                    dest.Text = entry;
                else
                    dest.Text += newline + entry;
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";

            appendToLabel1("Планується зробити:");
            appendToLabel2("Початок роботи");
            int i = 1;

            appendToLabel1(i, ". Плануємо створите екземпляр класу FootBall, викликавши конструктор з параметром ");
            i++;
            FootBall fm = new FootBall(stanBalla.vCentri);

            int GolA = 0, GolB = 0;
            fm.masa = 0.6F;
            fm.r_kuli = 0.12F;
            fm.tstanBalla = stanBalla.vGriA;

            appendToLabel1(i, ". Плануємо викликати метод popav(true, ref GolA);, що перевизначений у класі FootBall(override)");
            i++;
            fm.popav(true, ref GolA);

            appendToLabel1(i, ". Плануємо викликати метод popav(true, ref GolA, ref GolB) перевизначений у класі FootBall з сигнатурою, інакшою ніж у базовому класі ");
            i++;
            fm.popav(true, ref GolA, ref GolB);

            appendToLabel1(i, ", ", i + 1, ". Плануємо, за посередністю методу popavBase(true, ref GolA) класу FootBall викликати метод popav класу Ball");
            i++; i++;
            fm.popavBase(true, ref GolA);

            double s, v;
            appendToLabel1(i, ". Плануємо викликати метод udar(2, out v, 200, 0.1)класу Sphere iз класу FootBall ");
            i++;
            s = fm.udar(2, out v, 200, 0.1);

            appendToLabel1(i, ". Плануємо викликати метод kotytys(5, 1) класу Sphere iз класу FootBall ");
            i++;
            s = fm.kotytys(5, 1);

            appendToLabel1(i, ". Плануємо викликати метод letity(20, 30) класу Sphere iз класу FootBall");
            i++;
            s = fm.letity(20, 30);

            appendToLabel1(i, ". Плануємо викликати перевизначений метод letity(20, 30, 5) класу FootBall");
            i++;
            s = fm.letity(20, 30, 5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}