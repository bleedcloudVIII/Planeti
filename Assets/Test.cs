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
        transform.localScale = new Vector3((float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000, (float)SolarSystemObjects.SolarSystemObjects.Earth.R * 1000);
        day++;
        //UnityEngine.Debug.Log("I am alive!");
        //for (int i = 1; i <= SolarSystemObjects.SolarSystemObjects.Mars.T; i++)
        //{
        //    List<double> a = SolarSystemObjects.SolarSystemObjects.Mars.calculateCoordsByDay(i);
        //    UnityEngine.Debug.Log($"day {i} ({a[0]}; {a[1]}; {a[2]})");

        //}
        //List<double> a = SolarSystemObjects.SolarSystemObjects.Mars.calculateCoordsByDay(1);
        //UnityEngine.Debug.Log(a[0]);
        //UnityEngine.Debug.Log(a[1]);
        //UnityEngine.Debug.Log(a[2]);


        //List<double> b = SolarSystemObjects.SolarSystemObjects.Mars.calculateCoordsByDay(2);
        //UnityEngine.Debug.Log(b[0]);
        //UnityEngine.Debug.Log(b[1]);
        //UnityEngine.Debug.Log(b[2]);
        //UnityEngine.Debug.Log(SolarSystemObjects.SolarSystemObjects.Mars.calculateCoordsByDay(2));
        //UnityEngine.Debug.Log(SolarSystemObjects.SolarSystemObjects.Mars.calculateCoordsByDay(3));
        //UnityEngine.Debug.Log(SolarSystemObjects.SolarSystemObjects.Mars.calculateCoordsByDay(4));

        //SolarSystemObjects.Mars
    }

    // Update is called once per frame
    void Update()
    {
        List<float> a = SolarSystemObjects.SolarSystemObjects.Earth.calculateCoordsByDay(0, 0, 0, day);
        UnityEngine.Debug.Log($"day {day} ({a[0]}; {a[1]}; {a[2]})");
        transform.position = new Vector3(a[0], a[1], a[2]);
        day++;
    }
}
