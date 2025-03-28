using System;
using System.Collections.Generic;
using UnityEngine;

namespace SolarSystemObjects
{
    public class SolarSystemObject
    {
        public double start_x { get; set; } // ��������� ���������� ������� �� ��� x
        public double start_y { get; set; } // ��������� ���������� ������� �� ��� y
        public double start_z { get; set; } // ��������� ���������� ������� �� ��� z

        public double current_x { get; set; } // ������� ���������� ������� �� ��� x
        public double current_y { get; set; } // ������� ���������� ������� �� ��� y
        public double current_z { get; set; } // ������� ���������� ������� �� ��� z

        public double e { get; set; } = 0; // �������������� �������

        public double T { get; set; } // ������ ���������

        public double a { get; set; } // ������� �������

        public double i { get; set; } // ������ ������

        public double R { get; set; } // ������ �������

        public double calculateT(double a) // ������ ������� ���������
        {
            this.T = Math.Pow(a, 3.0 / 2.0);
            return this.T;
        }

        public double calculateA(double x, double y, double z) // ������ ������� �������
        {
            this.a = Math.Abs(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            return this.a;
        }

        // middle ����� ��� �����, ������ ������� ���������� ��������
        public List<float> calculateCoordsByDay(double middle_x, double middle_y, double middle_z, int day) // ������ ��������� ������� � ����������� ����
        {
            double omega = 2 * Math.PI / this.T;
            double teta = omega * day;
            double x = middle_x + this.a * Math.Cos(teta);
            double z = middle_z + this.a * Math.Sin(teta);
            double y = middle_y + z * Math.Sin(this.i * 0.0174533);
            return new List<float>() { (float)x, (float)y, (float)z };
        }
    }
}
