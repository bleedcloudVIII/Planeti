using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using static GlobalVariables;

namespace SolarSystem
{
    public class BodyCoords
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }

    public class BodyCoordsIterator: IEnumerator<BodyCoords>
    {
        public SolarSystemObject body;

        // ����/������� ��� ���������
        public int day = 0;

        // ���������� �������� ����������� �� �� �����
        public ulong revolutions_count = 0;

        public bool MoveNext()
        {
            day++;
            if (this.day > this.body.T)
            {
                this.day = 0;
                this.revolutions_count++;
            }
            return true;
        }

        public BodyCoords Current => this.body.calculateCoordsByDay(this.day, this.revolutions_count);

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public void Reset()
        {
            day = -1;
        }
    }

    public class SolarSystemObject
    {
        // ����������� ����
        public SolarSystemObject central_body = null;

        // �������� ��������� ������������ ����
        public BodyCoordsIterator central_body_coords_iterator = null;

        // �������������� �������
        public double e = 0;

        // ������ ���������
        public double T;

        // ������� �������
        public double a;

        // ������ ������
        public double i;

        // ����������� ���������� ��� �������
        public double r_coeff = 1;

        // ������ ������� ��� ����������
        public double real_r;

        // ������ ������� � �����������
        public double R => this.r_coeff * this.real_r;

        // ��������� �������� ��������� ����������
        public double periapsis_argument_0;

        // ��������� �������� ������� ��������
        public double average_anomaly_0;

        // �������� ������� ����������� ����
        public double ascending_node_longitude;

        // �������� ��������� ��������� ����������
        public double changing_periapsis_argument => 24 * Math.Pow(Math.PI, 3) / Math.Pow(this.T, 2) / Math.Pow(GlobalVariables.light_speed_ae_day, 2) / (1 - Math.Pow(this.e, 2));

        // �������� �������� ��������
        public double average_movement => 2 * Math.PI / this.T;

        // ���������� ��������, ������� ����� ��������� � ������ ����������� ������� �� ������ �������
        public ulong N;

        // ������ ��������������� ��������
        public double eccentric_anomaly(int day)
        {
            double average_anomaly = this.average_anomaly_0 + this.average_movement * day;

            double calc_eccentric_anomaly(double E)
            {
                return E - (E - this.e * Math.Sin(E) - average_anomaly) / (1 - this.e * Math.Cos(E));
            };

            double E_0;
            double E_1 = average_anomaly;
            do
            {
                E_0 = E_1;
                E_1 = calc_eccentric_anomaly(E_0);
            } while (Math.Abs(E_1 - E_0) > GlobalVariables.accuracy);
            return E_1;
        }

        // ������� ������-�������
        public double r(double eccentric_anomaly)
        {
            return this.a * (1 - this.e * Math.Cos(eccentric_anomaly));
        }

        // ������� �������� ��������
        public double true_anomaly(double eccentric_anomaly)
        {
            return 2 * Math.Atan(Math.Sqrt((1 + this.e) / (1 - this.e)) * Math.Tan(eccentric_anomaly / 2));
        }

        // ������ ��������� ������� �� ������� ����
        public BodyCoords calculateCoordsByDay(int day, ulong revolutions_count)
        {
            double eccentric_anomaly = this.eccentric_anomaly(day);
            double true_anomaly = this.true_anomaly(eccentric_anomaly);
            double periapsis_argument = this.periapsis_argument_0 - this.changing_periapsis_argument * (this.N -  revolutions_count);
            double radius = this.r(eccentric_anomaly);
            double angle_sum = true_anomaly + periapsis_argument;
            BodyCoords central_body_position = new BodyCoords
            {
                x = 0,
                y = 0,
                z = 0,
            };

            if (this.central_body != null) central_body_position = this.central_body_coords_iterator.Current;

            double mult_sin_asdending_node_i_angle_sum = Math.Sin(angle_sum) * Math.Sin(this.ascending_node_longitude) * Math.Cos(this.i);
            double mult_cos_asdending_node_i_angle_sum = Math.Sin(angle_sum) * Math.Cos(this.ascending_node_longitude) * Math.Cos(this.i);

            double mult_angle_sum_cos_ascending_node = Math.Cos(angle_sum) * Math.Cos(this.ascending_node_longitude);
            double mult_angle_sum_sin_ascending_node = Math.Cos(angle_sum) * Math.Sin(this.ascending_node_longitude);

            double x = central_body_position.x + radius * (mult_angle_sum_cos_ascending_node - mult_sin_asdending_node_i_angle_sum);
            double y = central_body_position.y + radius * (mult_angle_sum_sin_ascending_node + mult_cos_asdending_node_i_angle_sum);
            double z = central_body_position.z + radius * Math.Sin(angle_sum) * Math.Sin(this.i);

            return new BodyCoords
            {
                x = (float)x,
                y = (float)y,
                z = (float)z
            };
        }



    }
}
