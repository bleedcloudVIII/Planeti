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
    

    List<SolarSystem.AppEvent> appEvents = SolarSystem.appEvents.events_list;

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

    private double one_year_value = 365.24218985;

    public void skipTime(ulong years, ulong days)
    {
        double all_days = (double)(years * this.one_year_value  + days);
        this.days += years*365 + days;
        foreach (SolarSystem.BodyCoordsIterator iterator in SolarSystem.SolarSystemObjects.SpaceBodiesIteratos)
        {
            ulong passed_revolutions_count = (ulong)(all_days / iterator.body.T);
            int remaining_days = (int)(all_days - passed_revolutions_count * iterator.body.T);

            int current_days = iterator.day;
            int sum_of_days = current_days + remaining_days;
            if (sum_of_days >= iterator.body.T)
            {
                passed_revolutions_count += (ulong)(sum_of_days / iterator.body.T);
                remaining_days = (int)(sum_of_days % iterator.body.T);

                iterator.day = remaining_days;
                iterator.revolutions_count += passed_revolutions_count;
            }
            else 
            {
                iterator.day = sum_of_days;
                iterator.revolutions_count += passed_revolutions_count;
            }
        }
    }

    void Update()
    {
        // this.mars_coords_iterator.day = 127;
        // if (this.days <= 100 /*|| this.days > 111*/)
        // {
        if (this.days == 0) this.skipTime(94998, 0);
        Debug.Log($"День {this.days}. Кол-во событий в очереди: {this.appEventsQueue.Count}");
        this.updateEvents();
        this.updatePositions();
        //Debug.Log($"Кординаты день {this.days}:({this.mars_coords_iterator.Current.x};{this.mars_coords_iterator.Current.y};{this.mars_coords_iterator.Current.z})");
            
        // }
        // else if (this.days == 111)
        // {
        //     this.skipTime(100, 180);
        //     Debug.Log($"После пропуска. Кординаты:({this.earth_coords_iterator.Current.x};{this.earth_coords_iterator.Current.y};{this.earth_coords_iterator.Current.z})");
        //     Debug.Log($"После пропуска. День итератора: {this.earth_coords_iterator.day}; Количество совершённых оборотов:{this.earth_coords_iterator.revolutions_count}");
        // }
        this.days++;
    }

    
}
