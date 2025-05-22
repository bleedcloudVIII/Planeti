using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using SolarSystem;
using System.Reflection;

public class Main : MonoBehaviour
{

    public Transform mercury;
    public Transform venus;
    public Transform earth;
    public Transform moon;
    public Transform mars;
    public Transform jupiter;
    public Transform saturn;
    public Transform uranus;
    public Transform neptune;
    public Transform pluto;
  
    private ulong days = 0;

    SolarSystem.BodyCoordsIterator mercury_coords_iterator = SolarSystem.SolarSystemObjects.MercuryCoordsIterator;
    SolarSystem.BodyCoordsIterator venus_coords_iterator = SolarSystem.SolarSystemObjects.VenusCoordsIterator;
    SolarSystem.BodyCoordsIterator earth_coords_iterator = SolarSystem.SolarSystemObjects.EarthCoordsIterator;
    SolarSystem.BodyCoordsIterator moon_coords_iterator = SolarSystem.SolarSystemObjects.MoonCoordsIterator;
    SolarSystem.BodyCoordsIterator mars_coords_iterator = SolarSystem.SolarSystemObjects.MarsCoordsIterator;
    SolarSystem.BodyCoordsIterator jupiter_coords_iterator = SolarSystem.SolarSystemObjects.JupiterCoordsIterator;
    SolarSystem.BodyCoordsIterator saturn_coords_iterator = SolarSystem.SolarSystemObjects.SaturnCoordsIterator;
    SolarSystem.BodyCoordsIterator uranus_coords_iterator = SolarSystem.SolarSystemObjects.UranusCoordsIterator;
    SolarSystem.BodyCoordsIterator neptune_coords_iterator = SolarSystem.SolarSystemObjects.NeptuneCoordsIterator;
    SolarSystem.BodyCoordsIterator pluto_coords_iterator = SolarSystem.SolarSystemObjects.PlutoCoordsIterator;
    

    // ������ �������
    List<SolarSystem.AppEvent> appEvents = new List<SolarSystem.AppEvent>();


    // ������� �������
    private Queue<SolarSystem.AppEvent> appEventsQueue = new Queue<SolarSystem.AppEvent>();

    private void updateEvents()
    {
        foreach (SolarSystem.AppEvent appEvent in appEvents)
        {
            if (appEvent.day == this.days) this.appEventsQueue.Enqueue(appEvent);
        }
    }

    private void setScale()
    {
        mercury.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Mercury.R, (float)SolarSystem.SolarSystemObjects.Mercury.R, (float)SolarSystem.SolarSystemObjects.Mercury.R);
        venus.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Venus.R, (float)SolarSystem.SolarSystemObjects.Venus.R, (float)SolarSystem.SolarSystemObjects.Venus.R);
        earth.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Earth.R, (float)SolarSystem.SolarSystemObjects.Earth.R, (float)SolarSystem.SolarSystemObjects.Earth.R);
        moon.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Moon.R, (float)SolarSystem.SolarSystemObjects.Moon.R, (float)SolarSystem.SolarSystemObjects.Moon.R);
        mars.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Mars.R, (float)SolarSystem.SolarSystemObjects.Mars.R, (float)SolarSystem.SolarSystemObjects.Mars.R);
        jupiter.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Jupiter.R, (float)SolarSystem.SolarSystemObjects.Jupiter.R, (float)SolarSystem.SolarSystemObjects.Jupiter.R);
        saturn.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Saturn.R, (float)SolarSystem.SolarSystemObjects.Saturn.R, (float)SolarSystem.SolarSystemObjects.Saturn.R);
        uranus.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Uranus.R, (float)SolarSystem.SolarSystemObjects.Uranus.R, (float)SolarSystem.SolarSystemObjects.Uranus.R);
        neptune.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Neptune.R, (float)SolarSystem.SolarSystemObjects.Neptune.R, (float)SolarSystem.SolarSystemObjects.Neptune.R);
        pluto.localScale = new Vector3((float)SolarSystem.SolarSystemObjects.Pluto.R, (float)SolarSystem.SolarSystemObjects.Pluto.R, (float)SolarSystem.SolarSystemObjects.Pluto.R);
    }

    void Start()
    {

       this.setScale();
        //SolarSystemObjects.SolarSystemObjects.Venus.T = 5000;
        //SolarSystemObjects.SolarSystemObjects.Moon.T = 500;


        //moon.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000);
        //venus.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Venus.R * 1000);

        //List<float> earth_coords = SolarSystemObjects.SolarSystemObjects.Mercury.calculateCoordsByDay(0, 0, 0, day);
        //earth.position = new Vector3(earth_coords[0], earth_coords[1], earth_coords[2]);

        //List<float> moon_coords = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(earth_coords[0], earth_coords[1], earth_coords[2], day);
        //moon.position = new Vector3(moon_coords[0], moon_coords[1], moon_coords[2]);

        //List<float> venus_coords = SolarSystemObjects.SolarSystemObjects.Venus.calculateCoordsByDay(0, 0, 0, day);
        //venus.position = new Vector3(venus_coords[0], venus_coords[1], venus_coords[2]);

        //day++;
    }

    private void updatePositions()
    {
        SolarSystem.BodyCoords mercury_coords = this.mercury_coords_iterator.Current;
        mercury.position = new Vector3(mercury_coords.x, mercury_coords.z, mercury_coords.y);
        this.mercury_coords_iterator.MoveNext();
        
        SolarSystem.BodyCoords venus_coords = this.venus_coords_iterator.Current;
        venus.position = new Vector3(venus_coords.x, venus_coords.z, venus_coords.y);
        this.venus_coords_iterator.MoveNext();

        SolarSystem.BodyCoords earth_coords = this.earth_coords_iterator.Current;
        earth.position = new Vector3(earth_coords.x, earth_coords.z, earth_coords.y);
        this.earth_coords_iterator.MoveNext();

        SolarSystem.BodyCoords moon_coords = this.moon_coords_iterator.Current;
        moon.position = new Vector3(moon_coords.x, moon_coords.z, moon_coords.y);
        this.moon_coords_iterator.MoveNext();

        SolarSystem.BodyCoords mars_coords = this.mars_coords_iterator.Current;
        mars.position = new Vector3(mars_coords.x, mars_coords.z, mars_coords.y);
        this.mars_coords_iterator.MoveNext();

        SolarSystem.BodyCoords jupiter_coords = this.jupiter_coords_iterator.Current;
        jupiter.position = new Vector3(jupiter_coords.x, jupiter_coords.z, jupiter_coords.y);
        this.jupiter_coords_iterator.MoveNext();

        SolarSystem.BodyCoords saturn_coords = this.saturn_coords_iterator.Current;
        saturn.position = new Vector3(saturn_coords.x, saturn_coords.z, saturn_coords.y);
        this.saturn_coords_iterator.MoveNext();

        SolarSystem.BodyCoords uranus_coords = this.uranus_coords_iterator.Current;
        uranus.position = new Vector3(uranus_coords.x, uranus_coords.z, uranus_coords.y);
        this.uranus_coords_iterator.MoveNext();

        SolarSystem.BodyCoords neptune_coords = this.neptune_coords_iterator.Current;
        neptune.position = new Vector3(neptune_coords.x, neptune_coords.z, neptune_coords.y);
        this.neptune_coords_iterator.MoveNext();

        SolarSystem.BodyCoords pluto_coords = this.pluto_coords_iterator.Current;
        pluto.position = new Vector3(pluto_coords.x, pluto_coords.z, pluto_coords.y);
        this.pluto_coords_iterator.MoveNext();
    }

    void Update()
    {
        this.updateEvents();
        this.updatePositions();

        // SolarSystem.BodyCoords coords = this.earth_coords_iterator.Current;
        // this.earth_coords_iterator.MoveNext();

        // UnityEngine.Debug.Log($"({coords.x}; {coords.y}; {coords.z}), day={this.earth_coords_iterator.day} oboroti={this.earth_coords_iterator.revolutions_count}, {SolarSystem.SolarSystemObjects.Earth.R}");
        //List<float> earth_coords = SolarSystemObjects.SolarSystemObjects.Mercury.calculateCoordsByDay(0, 0, 0, day);
        // earth.position = new Vector3(coords.x, coords.z, coords.y);

        this.days++;

        //List<float> venus_coords = SolarSystemObjects.SolarSystemObjects.Venus.calculateCoordsByDay(0, 0, 0, day);
        //venus.position = new Vector3(venus_coords[0], venus_coords[1], venus_coords[2]);

        //List<float> moon_coords = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(earth_coords[0], earth_coords[1], earth_coords[2], day);
        //moon.position = new Vector3(moon_coords[0], moon_coords[1], moon_coords[2]);

        //UnityEngine.Debug.Log($"day {day} {earth_coords[1]}; {venus_coords[1]}");

        //day++;
    }
}
