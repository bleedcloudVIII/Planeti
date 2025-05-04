using System;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

namespace SolarSystemObjects
{
    public class SolarSystemObject
    {
        //public double start_x { get; set; } // Начальные координаты объекта по оси x
        //public double start_y { get; set; } // Начальные координаты объекта по оси y
        //public double start_z { get; set; } // Начальные координаты объекта по оси z

        //public double current_x { get; set; } // Текущие координаты объекта по оси x
        //public double current_y { get; set; } // Текущие координаты объекта по оси y
        //public double current_z { get; set; } // Текущие координаты объекта по оси z

        // Эксцентриситет объекта
        public double e { get; set; } = 0;

        // Период обращения
        public double T { get; set; }

        // Большая полуось
        public double a { get; set; }

        // Наклон орбиты
        public double i { get; set; }

        // Радиус объекта
        public double R { get; set; }

        // Начальное значение аргумента перицентра
        public double periapsis_argument_0 { get; set; }

        // Начальное значение средней аномалии
        public double average_anomaly_0 { get; set; }

        // Значение узла восходящего узла
        public double ascending_node_longitude { get; set; }

        // Значение изменения аргумента перицентра
        public double changing_periapsis_argument => 24 * Math.Pow(Math.PI, 3) / Math.Pow(this.T, 2) / Math.Pow(GlobalVariables.light_speed_ae_day, 2) / (1 - Math.Pow(this.e, 2));

        // Значение среднего движения
        public double average_movement => 2 * Math.PI / this.T;

        // Расчёт эксцентрической аномалии
        public double eccentric_anomaly(int day)
        {
            double average_anomaly = this.average_anomaly_0 + this.average_movement * day;

            double calc_eccentric_anomaly(double E)
            {
                return E - (E - this.e * Math.Sin(E) - average_anomaly) / (1 - this.e * Math.Cos(E));
            };

            // TODO ограничение на кол-во операций
            double E_0;
            double E_1 = average_anomaly;
            do
            {
                E_0 = E_1;
                E_1 = calc_eccentric_anomaly(E_0);
            } while (Math.Abs(E_1 - E_0) > GlobalVariables.accuracy);
            return E_1;
        }

        // Расчёта радиус-вектора
        public double r(double eccentric_anomaly)
        {
            return this.a * (1 - this.e * Math.Cos(eccentric_anomaly));
        }

        public double true_anomaly(double eccentric_anomaly)
        {
            return 2 * Math.Atan(Math.Sqrt((1 + this.e) / (1 - this.e)) * Math.Tan(eccentric_anomaly / 2));
        }

        // middle точки это точка, вокруг которой происходит вращение
        public List<float> calculateCoordsByDay(double middle_x, double middle_y, double middle_z, ulong past_days) // Расчёт Координат объекта в определённый день
        {
            int days = (int)(past_days % this.T);
            double eccentric_anomaly = this.eccentric_anomaly(days);

            double true_anomaly = this.true_anomaly(eccentric_anomaly);
            // TODO Сделать
            int n = 0;
            double periapsis_argument = this.periapsis_argument_0 + this.changing_periapsis_argument * n;
            double radius = this.r(eccentric_anomaly);

            double angle_sum = true_anomaly + periapsis_argument;

            double x = middle_x + radius * (Math.Cos(angle_sum) * Math.Cos(this.ascending_node_longitude) - Math.Sin(angle_sum) * Math.Sin(this.ascending_node_longitude) * Math.Cos(this.i));
            double y = middle_y + radius * (Math.Cos(angle_sum) * Math.Sin(this.ascending_node_longitude) + Math.Sin(angle_sum) * Math.Cos(this.ascending_node_longitude) * Math.Cos(this.i));
            double z = middle_z + radius * Math.Sin(angle_sum) * Math.Sin(this.i);

            return new List<float>() { (float)x, (float)y, (float)z };
            //int days = (int)(past_days % this.T);
            //double omega = 2 * Math.PI / this.T;
            //double teta = omega * days;
            //double x = middle_x + this.a * Math.Cos(teta);
            //double z = middle_z + this.a * Math.Sin(teta);
            //double y = middle_y;

            //double angle = this.i * 0.0174533;

            //double rot_x = x * Math.Cos(angle) - y * Math.Sin(angle);
            //double rot_y = x * Math.Sin(angle) + y * Math.Cos(angle);
            //double rot_z = z;

            //return new List<float>() { (float)rot_x, (float)rot_y, (float)rot_z };
        }
    }
}
