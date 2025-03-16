using System;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSystemObjects
{
    // Скорее всего потом удалится
    //public enum SolarSystemObjects
    //{
    //    Sun,
    //    Mercury,
    //    Venus,
    //    Earth,
    //    Mars,
    //    Jupiter,
    //    Saturn,
    //    Uranus,
    //    Neptune,
    //    Pluto
    //}

    public class SolarSystemObject
    {
        public double start_x { get; set; } // Начальные координаты объекта по оси x
        public double start_y { get; set; } // Начальные координаты объекта по оси y
        public double start_z { get; set; } // Начальные координаты объекта по оси z

        public double current_x { get; set; } // Текущие координаты объекта по оси x
        public double current_y { get; set; } // Текущие координаты объекта по оси y
        public double current_z { get; set; } // Текущие координаты объекта по оси z

        public double e { get; set; } = 0; // Эксцентриситет объекта

        public double T { get; set; } // Период обращения

        public double a { get; set; } // Большая полуось

        public double i { get; set; } // Наклон орбиты

        public double calculateT(double a) // Расчёт Периода обращения
        {
            this.T = Math.Pow(a, 3.0 / 2.0);
            return this.T;
        }

        public double calculateA(double x, double y, double z) // Расчёт Большой полуоси
        {
            this.a = Math.Abs(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            return this.a;
        }

        public List<float> calculateCoordsByDay(int day) // Расчёт Координат объекта в определённый день
        {
            double omega = 2 * Math.PI / this.T;
            double teta = omega * day;
            double x = this.a * Math.Cos(teta);
            double z = this.a * Math.Sin(teta);
            double y = z * Math.Sin(this.i * 0.0174533);
            return new List<float>() { (float)x, (float)y, (float)z };
        }
    }
}
