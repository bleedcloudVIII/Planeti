using UnityEngine;
using SolarSystemObjects;

namespace SolarSystemObjects
{
    public class SolarSystemObjects
    {
        public SolarSystemObject Mercury = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.205631752,
            T = 87.96843362,
            a = 0.38709830982,
            i = 7.0049863889,
        };

        public SolarSystemObject Venus = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.006771882,
            T = 224.6954354,
            a = 0.72332981996,
            i = 3.3946619444,
        };

        public SolarSystemObject Earth = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.016708617,
            T = 365.24218985,
            a = 1.00000101778,
            i = 0.0,
        };

        public SolarSystemObject Mars = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.093400620,
            T = 686.92970957,
            a = 1.52367934191,
            i = 1.8497263889,
        };

        public SolarSystemObject Jupiter = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.048494851,
            T = 4330.5957654,
            a = 5.20260319132,
            i = 1.3032697222,
        };

        public SolarSystemObject Saturn = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.055508622,
            T = 10746.940442,
            a = 9.55490959574,
            i = 2.4888780556,
        };

        public SolarSystemObject Uranus = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.046295899,
            T = 30588.740354,
            a = 19.21844606178,
            i = 0.77319611,
        };

        public SolarSystemObject Neptune = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.008988095,
            T = 59799.900456,
            a = 30.11038686942,
            i = 1.7699522,
        };

        public SolarSystemObject Pluto = new SolarSystemObject()
        {
            start_x = 0,
            start_y = 0,
            start_z = 0,
            e = 0.2459387823,
            T = 90738.995,
            a = 39.5181761979,
            i = 17.1225991666,
        };
    }
}
