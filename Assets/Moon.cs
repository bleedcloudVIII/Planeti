using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public int day = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<float> earth = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        List<float> moon = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay((double)earth[0], (double)earth[1], (double)earth[2], day);

        transform.position = new Vector3(moon[0], moon[1], moon[2]);
        transform.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Moon.R * 1000);
        day++;
    }

    // Update is called once per frame
    void Update()
    {
        //UnityEngine.Debug.Log($"{day}");
        List<float> earth = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        List<float> moon = SolarSystemObjects.SolarSystemObjects.Moon.calculateCoordsByDay((double)earth[0], (double)earth[1], (double)earth[2], day);
        //UnityEngine.Debug.Log($"day {day} ({a[0]}; {a[1]}; {a[2]})");
        transform.position = new Vector3(moon[0], moon[1], moon[2]);
        day++;
    }
}
