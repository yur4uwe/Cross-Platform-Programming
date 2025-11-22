using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_7
{
    internal class Sphere
    {
        public const double Pi = Math.PI;
        double r, l, v, s, m; // поля для зберігання властивостей

        public double r_kuli
        {
            get { return r; }
            set
            {
                r = value;
                l = 2 * Pi * r;
                v = 4 * Pi * r * r * r;
                s = 4 * Pi * r * r;
            }
        }

        public double l_kola
        {
            get { return l; }
        }

        public double v_kuli
        {
            get { return v; }
        }

        public double s_kuli
        {
            get { return s; }
        }

        public double masa
        {
            get { return m; }
            set { m = value; }
        }

        public virtual double kotytys(double t, double v)
        {
            Form1.appendToLabel2(Form1.j, ". Виконано метод kotytys(double, double) класу Sphere");
            Form1.j++;
            return 2 * Pi * r * t * v;
        }

        public virtual double letity(double t, double v)
        {
            Form1.appendToLabel2(Form1.j, ". Виконано метод letity(double,double) класу Sphere");
            Form1.j++;
            return t * v;
        }

        public virtual double udar(double t, out double v, double f, double t1)
        {
            v = f * t1 / m;
            Form1.appendToLabel2(Form1.j, 
                ". Виконано метод udar(double, out double,double,double) класу Sphere, ",
                " s = v * t= ",
                t * v);
            Form1.j++;
            return t * v;
        }
    }
}
