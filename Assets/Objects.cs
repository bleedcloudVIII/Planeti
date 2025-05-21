using UnityEngine;
using SolarSystem;
using System.Runtime.CompilerServices;

namespace SolarSystem
{
    public class SolarSystemObjects
    {
        // Данные на 2025-05-07 - 2025-05-08
        public static ulong D = 4600000000;

        public static SolarSystemObject Mercury = new SolarSystemObject()
        {
            e = 0.205631752,
            T = 87.96843362,
            a = 0.38709830982,
            i = 7.0049863889,
            real_r = 0.000016043,
            periapsis_argument_0 = 29.19850252136612,
            average_anomaly_0 = 263.6698727772198,
            ascending_node_longitude = 48.29940816606307,
            N = (ulong)(D / 87.96843362)
        };

        public static BodyCoordsIterator MercuryCoordsIterator = new BodyCoordsIterator { body = Mercury };

        public static SolarSystemObject Venus = new SolarSystemObject()
        {
            e = 0.006771882,
            T = 224.6954354,
            a = 0.72332981996,
            i = 3.3946619444,
            real_r = 0.0000401075,
            periapsis_argument_0 = 54.93887242128372,
            average_anomaly_0 = 123.7571797318931,
            ascending_node_longitude = 76.60743956137830,
            N = (ulong)(D / 224.6954354)

        };

        public static BodyCoordsIterator VenusCoordsIterator = new BodyCoordsIterator { body = Venus };

        public static SolarSystemObject Earth = new SolarSystemObject()
        {
            e = 0.016708617,
            T = 365.24218985,
            a = 1.00000101778,
            i = 0.0,
            r_coeff = 1000,
            real_r = 0.0000427814,
            periapsis_argument_0 = 266.9953325646608,
            average_anomaly_0 = 124.7635239251798,
            ascending_node_longitude = 194.0033954960434,
            N = (ulong)(D / 365.24218985)
        };

        public static BodyCoordsIterator EarthCoordsIterator = new BodyCoordsIterator { body = Earth };

        public static SolarSystemObject Mars = new SolarSystemObject()
        {
            e = 0.093400620,
            T = 686.92970957,
            a = 1.52367934191,
            i = 1.8497263889,
            real_r = 0.0000227276,
            periapsis_argument_0 = 286.6699317364874,
            average_anomaly_0 = 191.0489371642038,
            ascending_node_longitude = 49.48323060546368,
            N = (ulong)(D / 686.92970957)
        };

        public static BodyCoordsIterator MarsCoordsIterator = new BodyCoordsIterator { body = Mars };

        public static SolarSystemObject Jupiter = new SolarSystemObject()
        {
            e = 0.048494851,
            T = 4330.5957654,
            a = 5.20260319132,
            i = 1.3032697222,
            real_r = 0.0004746057,
            periapsis_argument_0 = 273.5810066573079,
            average_anomaly_0 = 69.56165064241159,
            ascending_node_longitude = 100.5183099167459,
            N = (ulong)(D / 4330.5957654)
        };

        public static BodyCoordsIterator JupiterCoordsIterator = new BodyCoordsIterator { body = Jupiter };

        public static SolarSystemObject Saturn = new SolarSystemObject()
        {
            e = 0.055508622,
            T = 10746.940442,
            a = 9.55490959574,
            i = 2.4888780556,
            real_r = 0.0004010752,
            periapsis_argument_0 = 337.6583436100631,
            average_anomaly_0 = 268.7436029396669,
            ascending_node_longitude = 113.5555784232812,
            N = (ulong)(D / 10746.940442)
        };

        public static BodyCoordsIterator SaturnCoordsIterator = new BodyCoordsIterator { body = Saturn };

        public static SolarSystemObject Uranus = new SolarSystemObject()
        {
            e = 0.046295899,
            T = 30588.740354,
            a = 19.21844606178,
            i = 0.77319611,
            real_r = 0.00001737993,
            periapsis_argument_0 = 90.77652108111427,
            average_anomaly_0 = 257.1045473770534,
            ascending_node_longitude = 74.02845806305437,
            N = (ulong)(D / 30588.740354)
        };

        public static BodyCoordsIterator UranusCoordsIterator = new BodyCoordsIterator { body = Uranus };

        public static SolarSystemObject Neptune = new SolarSystemObject()
        {
            e = 0.008988095,
            T = 59799.900456,
            a = 30.11038686942,
            i = 1.7699522,
            real_r = 0.0001671147,
            periapsis_argument_0 = 269.8974641765519,
            average_anomaly_0 = 318.9477116332534,
            ascending_node_longitude = 131.6636269739597,
            N = (ulong)(D / 59799.900456)
        };
    
        public static BodyCoordsIterator NeptuneCoordsIterator = new BodyCoordsIterator { body = Neptune };

        public static SolarSystemObject Pluto = new SolarSystemObject()
        {
            e = 0.2459387823,
            T = 90738.995,
            a = 39.5181761979,
            i = 17.1225991666,
            real_r = 0.0000079433,
            periapsis_argument_0 = 111.9208736397519,
            average_anomaly_0 = 53.85468246363587,
            ascending_node_longitude = 110.2117816655034,
            N = (ulong)(D / 90738.995)
        };

        public static BodyCoordsIterator PlutoCoordsIterator = new BodyCoordsIterator { body = Pluto };

        public static SolarSystemObject Sun = new SolarSystemObject()
        {
            real_r = 0.0046547454,
        };

        // Спутник Земли
        public static SolarSystemObject Moon = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 128.7082725680752,
            average_anomaly_0 = 46.06944970848827,
            ascending_node_longitude = 48.14552293733552,
            central_body = Earth,
            central_body_coords_iterator = EarthCoordsIterator,
            N = (ulong)(D / 27.322)
        };


        // Спутники Марса
        public static SolarSystemObject Phobos = new SolarSystemObject()
        {
            e = 0.0151,
            T = 0.31875,
            a = 0,
            i = 1.093,
            real_r = 0,
            periapsis_argument_0 = 73.31198887975698,
            average_anomaly_0 = 5.218468920741705,
            ascending_node_longitude = 85.85659741885067,
        };

        public static SolarSystemObject Deimos = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 264.7423306543004,
            average_anomaly_0 = 242.1071576017125,
            ascending_node_longitude = 26.07390494553084,
        };

        // Спутники Юпитера (самые крупные/основные)
        public static SolarSystemObject Io = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 233.2260072660882,
            average_anomaly_0 = -57.52803193246076,
            ascending_node_longitude = 253.7095639868062,
        };

        public static SolarSystemObject Europa = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 179.9343670650059,
            average_anomaly_0 = 166.7522026739109,
            ascending_node_longitude = 88.70634611446324,
        };

        public static SolarSystemObject Ganymede = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 172.1611469759773,
            average_anomaly_0 = 226.2559994588334,
            ascending_node_longitude = 92.52313975535613,
        };

        public static SolarSystemObject Callisto = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 258.2974631333042,
            average_anomaly_0 = 24.12698746878317,
            ascending_node_longitude = 94.29306999365069,
        };

        // Спутники Сатурна (самые крупные/основные)
        public static SolarSystemObject Titan = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 202.9427888490757,
            average_anomaly_0 = -1.916830726451606,
            ascending_node_longitude = 162.5388072272737,
        };

        public static SolarSystemObject Enceladus = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 144.0044769787056,
            average_anomaly_0 = 49.82863788993586,
            ascending_node_longitude = 163.6574754529475,
        };

        // Спутники Урана (самые крупные/основные)
        public static SolarSystemObject Titania = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 181.5930264342271,
            average_anomaly_0 = 153.7866636102183,
            ascending_node_longitude = 60.73162930777730,
        };

        public static SolarSystemObject Oberon = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 200.1349626157420,
            average_anomaly_0 = 359.5766100188204,
            ascending_node_longitude = 235.5772633548385,
        };

        public static SolarSystemObject Ariel = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 352.6002784366734,
            average_anomaly_0 = 0.9270789859661920,
            ascending_node_longitude = 57.11860626035327,
        };

        public static SolarSystemObject Umbriel = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 12.07376399822548,
            average_anomaly_0 = -5.732646492776884,
            ascending_node_longitude = 59.39819633721409,
        };

        public static SolarSystemObject Miranda = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 335.8541807225466,
            average_anomaly_0 = 5.220865749125729,
            ascending_node_longitude = 57.02647500983746,
        };

        // Спутники Нептуна (самые крупные/основные)
        public static SolarSystemObject Triron = new SolarSystemObject()
        {
            e = 0.055,
            T = 27.322,
            a = 0.0025695553,
            i = 5.145,
            real_r = 0.000011613802,
            periapsis_argument_0 = 351.4439199899733,
            average_anomaly_0 = 221.7053706626781,
            ascending_node_longitude = 178.4908170994411,
        };
    }
}
