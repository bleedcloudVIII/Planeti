using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using SolarSystem;
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

    

    private ulong days = 0;

    SolarSystem.BodyCoordsIterator earth_coords_iterator;

    // Список событий
    List<SolarSystem.AppEvent> appEvents = new List<SolarSystem.AppEvent>();


    // Очередь событий
    private Queue<SolarSystem.AppEvent> appEventsQueue = new Queue<SolarSystem.AppEvent>();

    private void updateEvents()
    {
        foreach (SolarSystem.AppEvent appEvent in appEvents)
        {
            if (appEvent.day == this.days) this.appEventsQueue.Enqueue(appEvent);
        }
    }

    void Start()
    {
        this.earth_coords_iterator = new SolarSystem.BodyCoordsIterator { body = SolarSystem.SolarSystemObjects.Earth };

        
        //SolarSystemObjects.SolarSystemObjects.Venus.T = 5000;
        //SolarSystemObjects.SolarSystemObjects.Moon.T = 500;


        //moon.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000);
        earth.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Earth.R, (float)SolarSystem.SolarSystemObjects.Earth.R, (float)SolarSystem.SolarSystemObjects.Earth.R);
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
        this.updateEvents();

        SolarSystem.BodyCoords coords = this.earth_coords_iterator.Current;
        this.earth_coords_iterator.MoveNext();

        UnityEngine.Debug.Log($"({coords.x}; {coords.y}; {coords.z}), day={this.earth_coords_iterator.day} oboroti={this.earth_coords_iterator.revolutions_count}");
        //List<float> earth_coords = SolarSystemObjects.SolarSystemObjects.Mercury.calculateCoordsByDay(0, 0, 0, day);
        earth.position = new Vector3(coords.x, coords.z, coords.y);

        this.days++;

        //List<float> venus_coords = SolarSystemObjects.SolarSystemObjects.Venus.calculateCoordsByDay(0, 0, 0, day);
        //venus.position = new Vector3(venus_coords[0], venus_coords[1], venus_coords[2]);

        //List<float> moon_coords = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(earth_coords[0], earth_coords[1], earth_coords[2], day);
        //moon.position = new Vector3(moon_coords[0], moon_coords[1], moon_coords[2]);

        //UnityEngine.Debug.Log($"day {day} {earth_coords[1]}; {venus_coords[1]}");

        //day++;
    }
}
