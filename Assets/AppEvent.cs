using UnityEngine;
using System.Collections.Generic;


namespace SolarSystem
{
    public class AppEvent
    {
        public string title;

        public string description;

        public ulong day;
    }

    public static class appEvents {

        public static AppEvent start_domination_of_substance = new AppEvent {
            title = "Начало эпохи доминирования вещества",
            description = "Излучение перестаёт быть основной формой энергии, уступив место материи",
            day = 95000 * 365
        };

        public static List<AppEvent> events_list = new List<AppEvent>() {start_domination_of_substance};

    }
    
}

