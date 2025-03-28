using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using SolarSystemObjects;

public class Main : MonoBehaviour
{
    // ������ �� ������� ����� � ����
    public Transform earth;  // �����
    public Transform moon;   // ����
    public Transform venus;   // ����


    // ��������� ������� ����� � ����
    public Vector3 earthPosition = new Vector3(0, 0, 0);
    public Vector3 moonPosition = new Vector3(0, 0, 0);
    public Vector3 venusPosition = new Vector3(0, 0, 0);


    int day = 0;

    void Start()
    {
        SolarSystemObjects.SolarSystemObjects.Earth.T = 1500;
        SolarSystemObjects.SolarSystemObjects.Venus.T = 5000;
        SolarSystemObjects.SolarSystemObjects.Moon.T = 500;


        moon.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000);
        earth.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000);
        venus.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000);

        List<float> earth_coords = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        earth.position = new Vector3(earth_coords[0], earth_coords[1], earth_coords[2]);

        List<float> moon_coords = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(earth_coords[0], earth_coords[1], earth_coords[2], day);
        moon.position = new Vector3(moon_coords[0], moon_coords[1], moon_coords[2]);

        List<float> venus_coords = SolarSystemObjects.SolarSystemObjects.Venus.calculateCoordsByDay(0, 0, 0, day);
        venus.position = new Vector3(venus_coords[0], venus_coords[1], venus_coords[2]);

        day++;
    }

    void Update()
    {
        List<float> earth_coords = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        earth.position = new Vector3(earth_coords[0], earth_coords[1], earth_coords[2]);

        List<float> venus_coords = SolarSystemObjects.SolarSystemObjects.Venus.calculateCoordsByDay(0, 0, 0, day);
        venus.position = new Vector3(venus_coords[0], venus_coords[1], venus_coords[2]);

        List<float> moon_coords = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(earth_coords[0], earth_coords[1], earth_coords[2], day);
        moon.position = new Vector3(moon_coords[0], moon_coords[1], moon_coords[2]);

        day++;
    }
}
