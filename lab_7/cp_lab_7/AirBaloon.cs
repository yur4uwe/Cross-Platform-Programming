using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_7
{
    internal class AirBaloon: Sphere
    {
        double tysk, maxTysk;

        public double tyskGazu
        {
            get { return tysk; }
            set { tysk = value; }
        }

        public double maxTyskGazu
        {
            get { return maxTysk; }
            set { maxTysk = value; }
        }

        public bool lopatys()
        {
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод lopatys(); класу povitrjana_kulja");
            Form1.j++;
            return tysk > maxTysk;
        }

        public double letity(double t, double v, double v_Vitru, double kutVitru)
        {
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод lletity(double t, double v, double v_Vitru, double kutVitru) класу povitrjana_kulja");
            Form1.j++;
            return t * v - v_Vitru * Math.Sin(kutVitru);
        }

        public new double letity(double t, double v)
        {
            double s = t * v;
            Form1.appendToLabel2(Form1.j,
                ". Виконано метод letity(double t, double v ) класу povitrjana_kulja. Ми пролетіли ",
                s,
                " метрів!" );
            Form1.j++;
            return s;
        }
    }
}
