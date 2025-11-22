using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_7
{
    internal class Ball: Sphere
    {
        public virtual void popav(bool je, ref int kilkist)
        {
            if (je) kilkist++;
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод popav(bool, ref int) класу Ball. kilkist=",
                kilkist);
            Form1.j++;
        }

        public virtual double letity(double t, double v, double f_tertja)
        {
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод letity(double, double, double ) класу Ball");
            Form1.j++;
            return t * v - f_tertja / masa * t * t / 2;
        }

        public double letityBase(double t, double v)
        {
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод letityBase(double, double) класу Ball");
            Form1.j++;
            return base.letity(t, v);
        }
    }
}
