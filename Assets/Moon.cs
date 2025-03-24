using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public int day = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //List<float> earth = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        List<float> moon = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(SolarSystemObjects.SolarSystemObjects.Earth.current_x, SolarSystemObjects.SolarSystemObjects.Earth.current_y, SolarSystemObjects.SolarSystemObjects.Earth.current_z, day);

        transform.position = new Vector3(moon[0], moon[1], moon[2]);
        transform.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Moon.R * 5000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 5000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 5000);
        day++;
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log($"{day}");
        //List<float> earth = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        List<float> moon = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay(SolarSystemObjects.SolarSystemObjects.Earth.current_x, SolarSystemObjects.SolarSystemObjects.Earth.current_y, SolarSystemObjects.SolarSystemObjects.Earth.current_z, day);
        //UnityEngine.Debug.Log($"moon day {day} ({SolarSystemObjects.SolarSystemObjects.Moon.current_x}; {SolarSystemObjects.SolarSystemObjects.Moon.current_y}; {SolarSystemObjects.SolarSystemObjects.Moon.current_z})");
        UnityEngine.Debug.Log($"cur day {day} ({SolarSystemObjects.SolarSystemObjects.Earth.current_x}; {SolarSystemObjects.SolarSystemObjects.Earth.current_y}; {SolarSystemObjects.SolarSystemObjects.Earth.current_z})");

        transform.position = new Vector3(moon[0], moon[1], moon[2]);
        day++;
    }
}
