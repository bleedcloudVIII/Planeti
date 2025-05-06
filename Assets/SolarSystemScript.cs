using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using SolarSystemObjects;
using System.Reflection;

public class Main : MonoBehaviour
{
    // Ссылки на объекты Земли и Луны
    public Transform earth;  // Земля
    public Transform moon;   // Луна
    public Transform venus;   // Луна


    // Начальные позиции Земли и Луны
    public Vector3 earthPosition = new Vector3(0, 0, 0);
    public Vector3 moonPosition = new Vector3(0, 0, 0);
    public Vector3 venusPosition = new Vector3(0, 0, 0);

    SolarSystemObjects.BodyCoordsIterator earth_coords_iterator;

    void Start()
    {
        this.earth_coords_iterator = new SolarSystemObjects.BodyCoordsIterator { body = SolarSystemObjects.SolarSystemObjects.Mercury };

        
        //SolarSystemObjects.SolarSystemObjects.Venus.T = 5000;
        //SolarSystemObjects.SolarSystemObjects.Moon.T = 500;


        //moon.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000);
        earth.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000);
        //venus.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000);

        //List<float> earth_coords = SolarSystemObjects.SolarSystemObjects.Mercury.calculateCoordsByDay(0, 0, 0, day);
        //earth.position = new Vector3(earth_coords[0], earth_coords[1], earth_coords[2]);

        //List<float> moon_coords = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(earth_coords[0], earth_coords[1], earth_coords[2], day);
        //moon.position = new Vector3(moon_coords[0], moon_coords[1], moon_coords[2]);

        //List<float> venus_coords = SolarSystemObjects.SolarSystemObjects.Venus.calculateCoordsByDay(0, 0, 0, day);
        //venus.position = new Vector3(venus_coords[0], venus_coords[1], venus_coords[2]);

        //day++;
    }

    void Update()
    {
        SolarSystemObjects.BodyCoords coords = this.earth_coords_iterator.Current;
        UnityEngine.Debug.Log($"({coords.x}; {coords.y}; {coords.z}), day={this.earth_coords_iterator.day} oboroti={this.earth_coords_iterator.revolutions_count}");
        this.earth_coords_iterator.MoveNext();

        //List<float> earth_coords = SolarSystemObjects.SolarSystemObjects.Mercury.calculateCoordsByDay(0, 0, 0, day);
        earth.position = new Vector3(coords.x, coords.z, coords.y);

        //List<float> venus_coords = SolarSystemObjects.SolarSystemObjects.Venus.calculateCoordsByDay(0, 0, 0, day);
        //venus.position = new Vector3(venus_coords[0], venus_coords[1], venus_coords[2]);

        //List<float> moon_coords = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(earth_coords[0], earth_coords[1], earth_coords[2], day);
        //moon.position = new Vector3(moon_coords[0], moon_coords[1], moon_coords[2]);

        //UnityEngine.Debug.Log($"day {day} {earth_coords[1]}; {venus_coords[1]}");

        //day++;
    }
}
