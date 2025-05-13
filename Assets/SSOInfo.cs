using UnityEngine;

namespace SolarSystem
{
    public enum SolarSystemObjectType
    {
        EARTH_GROUP_PLANET,
        DWARF_PLANET,
        GAS_GIANT,
        STAR,
        SPUTNIK,
        NULL,
        PLANET
    }

    public class SolarSystemObjectInfo
    {
        // ���� ����
        public SolarSystemObject body;

        // ��� ������������ ����
        public SolarSystemObjectType body_type;

        // ���������� ���������
        public int count_of_sputnik;

        // ��������� ���������� ������� (�/�^2)
        public double g;

        // ������ ����������� (��/�)
        public double first_space_speed;

        // ������ �����������
        public double second_space_speed;

        // ����� ������ ������
        public string openear;

        // ��� ������
        public string openear_by;
    }

    public class SSOInfos
    {
        public static SolarSystemObjectInfo MercuryInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Mercury,
            body_type = SolarSystemObjectType.EARTH_GROUP_PLANET,
            count_of_sputnik = 0,
            g = 3.7,
            first_space_speed = 3.1,
            second_space_speed = 4.25,
            openear = "������ XVII ����",
            openear_by = "������� �������"
        };

        public static SolarSystemObjectInfo VenusInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Venus,
            body_type = SolarSystemObjectType.EARTH_GROUP_PLANET,
            count_of_sputnik = 0,
            g = 8.87,
            first_space_speed = 7.328,
            second_space_speed = 10.363,
            openear = "1610 ��� ����� ���",
            openear_by = "������� �������"
        };

        public static SolarSystemObjectInfo EarthInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Earth,
            body_type = SolarSystemObjectType.EARTH_GROUP_PLANET,
            count_of_sputnik = 1,
            g = 9.8,
            first_space_speed = 7.91,
            second_space_speed = 11.2,
            openear = "-",
            openear_by = "-"
        };

        public static SolarSystemObjectInfo MarsInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Mars,
            body_type = SolarSystemObjectType.EARTH_GROUP_PLANET,
            count_of_sputnik = 2,
            g = 3.73,
            first_space_speed = 3.6,
            second_space_speed = 5.0,
            openear = "1610 ��� ����� ���",
            openear_by = "������� �������"
        };

        public static SolarSystemObjectInfo JupiterInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Jupiter,
            body_type = SolarSystemObjectType.GAS_GIANT,
            count_of_sputnik = 95,
            g = 24.79,
            first_space_speed = 42.58,
            second_space_speed = 59.5,
            openear = "1610 ��� ����� ���",
            openear_by = "������� �������"
        };

        public static SolarSystemObjectInfo SaturnInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Saturn,
            body_type = SolarSystemObjectType.GAS_GIANT,
            count_of_sputnik = 274,
            g = 24.79,
            first_space_speed = 25.535,
            second_space_speed = 35.5,
            openear = "1610 ��� ����� ���",
            openear_by = "������� �������"
        };

        public static SolarSystemObjectInfo UranusInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Uranus,
            body_type = SolarSystemObjectType.GAS_GIANT,
            count_of_sputnik = 28,
            g = 24.79,
            first_space_speed = 15.6,
            second_space_speed = 21.3,
            openear = "13 ����� 1781 ���� ����� ���",
            openear_by = "������ �������"
        };

        public static SolarSystemObjectInfo NetputeInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Neptune,
            body_type = SolarSystemObjectType.GAS_GIANT,
            count_of_sputnik = 28,
            g = 24.79,
            first_space_speed = 15.6,
            second_space_speed = 21.3,
            openear = "23 �������� 1846 ���� ����� ���",
            openear_by = "����� ��� ����� �������, ���� ��� �����, ������ �������� ����� � ������ ��� �����"
        };

        public static SolarSystemObjectInfo MoonInfo = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Moon,
            body_type = SolarSystemObjectType.SPUTNIK,
            count_of_sputnik = 0,
            g = 1.62,
            first_space_speed = 1.68,
            second_space_speed = 2.38,
            openear = "-",
            openear_by = "-"
        };

        public static SolarSystemObjectInfo Sun = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Sun,
            body_type = SolarSystemObjectType.STAR,
            count_of_sputnik = 0,
            g = 274,
            first_space_speed = 437.047,
            second_space_speed = 617.7,
            openear = "-",
            openear_by = "-"
        };

        public static SolarSystemObjectInfo Pluto = new SolarSystemObjectInfo
        {
            body = SolarSystemObjects.Pluto,
            body_type = SolarSystemObjectType.DWARF_PLANET,
            count_of_sputnik = 5,
            g = 0.62,
            first_space_speed = 0.855,
            second_space_speed = 1.2,
            openear = "1930 ��� ����� ���",
            openear_by = "����� �����"
        };
    }
}