using System.Diagnostics;
using UnityEngine;
using SolarSystemObjects;
using System.Collections.Generic;
using System.Globalization;

public class Test : MonoBehaviour
{
    public int day = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SolarSystemObjects.SolarSystemObjects.Earth.T = 7000;
        List<float> a = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        transform.position = new Vector3(a[0], a[1], a[2]);
        SolarSystemObjects.SolarSystemObjects.Earth.current_x = (double)a[0];
        SolarSystemObjects.SolarSystemObjects.Earth.current_x = (double)a[1];
        SolarSystemObjects.SolarSystemObjects.Earth.current_x = (double)a[2];

        transform.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000);
        day++;
    }

    // Update is called once per frame
    void Update()
    {
        List<float> a = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        //UnityEngine.Debug.Log($"day {day} ({a[0]}; {a[1]}; {a[2]})");
        transform.position = new Vector3(a[0], a[1], a[2]);
        UnityEngine.Debug.Log($"earth day {day} ({a[0]}; {a[1]}; {a[2]})");
        SolarSystemObjects.SolarSystemObjects.Earth.current_x = (double)a[0];
        SolarSystemObjects.SolarSystemObjects.Earth.current_y = (double)a[1];
        SolarSystemObjects.SolarSystemObjects.Earth.current_z = (double)a[2];
        day++;
    }
}
