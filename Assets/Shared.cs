using System;
using UnityEngine;


namespace SSOShared
{
    public static class Converter
    {
        public static double degree_to_radians(double degree)
        {
            return degree * Math.PI / 180;
        }
    }
}