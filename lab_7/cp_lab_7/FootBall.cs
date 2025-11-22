using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_7
{
    internal class FootBall: Ball
    {
        stanBalla stanM;

        public stanBalla tstanBalla
        {
            get { return stanM; }
            set { stanM = value; }
        }

        public bool standout
        {
            get { return stanM == stanBalla.pozaGroju; }
        }

        public FootBall(stanBalla sm)
        {
            Form1.appendToLabel2(Form1.j,
                ". Виконано конструктор FootBall(stanBalla sm) ");
            Form1.j++;
            stanM = sm;
            masa = 0.5F;
            r_kuli = 0.1F;
        }

        public void popav(bool je, ref int kilkistA, ref int kilkistB)
        {
            if (je)
            {
                if (stanM == stanBalla.vGriA) kilkistA++;
                else if (stanM == stanBalla.vGriB) kilkistB++;
            }

            Form1.appendToLabel2(Form1.j,
                ". Виконано метод popav класу FootBall з сигнатурою (bool, ref int, ref int)" );
            Form1.j++;
        }

        public void popavBase(bool b, ref int i)
        {
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод popavBase(bool b, ref int i) класу FootBall, який викликає метод popav(b, ref i) класу Ball )" );
            Form1.j++;
            base.popav(b, ref i);
        }

        public override void popav(bool je, ref int kilkist)
        {
            if (je) kilkist++;
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод popav(bool je, ref int kilkist) (override) класу FootBall " );
            Form1.j++;
        }

        public override double letity(double t, double v, double ftertja)
        {
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод letity(double t, double v, double ftertja) ( override) класу FootBall ");
            Form1.j++;
            return t * v - ftertja / masa * t * t / 2;
        }
    }
}
