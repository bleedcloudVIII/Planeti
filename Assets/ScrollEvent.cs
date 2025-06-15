using SolarSystem;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollEvent : MonoBehaviour
{
    public static class appEvents
    {

        public static AppEvent start_domination_of_substance = new AppEvent
        {
            title = "Начало эпохи доминирования вещества",
            description = "Излучение перестаёт быть основной формой энергии",
            day = 95000 * 365
        };

        public static List<AppEvent> events_list = new List<AppEvent>() ;

    }
    public ScrollRect scrollView;
    public GameObject infoPanel;
    public bool isView = false;
    public string textToAdd = "This is a sample text.\n"; // Текст для добавления

    void Start()
    {
        appEvents.events_list.Add(appEvents.start_domination_of_substance);
    }
    public void ButPress()
    {
        foreach (AppEvent appEvent in appEvents.events_list)
        {
            AddTextToScrollView(appEvent);
        }
        infoPanel.SetActive(!isView);
        isView=!isView;

    }
    public void AddTextToScrollView(AppEvent newText)
    {
        TextMeshProUGUI tmpText = scrollView.content.GetComponentInChildren<TextMeshProUGUI>();
        string info = "<b>" + newText.title + "</b>\n";
        info += "Описание: " + newText.description + "\n";
        info += "День: " + newText.day.ToString() + "\n";

        if (tmpText != null)
        {
            tmpText.text += info;
            LayoutRebuilder.ForceRebuildLayoutImmediate(scrollView.content);
        }
    }
    //// Перемещаем Scroll Bar вниз (Опционально)
    //scrollView.verticalNormalizedPosition = 0;
    //public RectTransform contentTransform;
    //public TextMeshProUGUI eventTextPrefab; // Префаб для одного текстового поля, содержащего всю информацию
    //public TextMeshProUGUI placeholderText;
    //public GameObject infoPanel;
    //private bool isView = false;
    //void Start()
    //{
    //    appEvents.events_list.Add(appEvents.start_domination_of_substance);

    //}
    //public void ButPress()
    //{

    //    infoPanel.SetActive(!isView);
    //    foreach (AppEvent appEvent in appEvents.events_list)
    //    {
    //        AddEventToScrollView(appEvent);
    //    }

    //    UpdateContentHeight();
    //}
    //public void AddEventToScrollView(AppEvent appEvent)
    //{
    //    TextMeshProUGUI newText = Instantiate(eventTextPrefab, contentTransform);
    //    string info = "<b>" + appEvent.title + "</b>\n";
    //    info += "Описание: " + appEvent.description + "\n";
    //    info += "День: " + appEvent.day.ToString() + "\n";

    //    newText.text = info;
    //    LayoutRebuilder.ForceRebuildLayoutImmediate(contentTransform);
    //}

    //void UpdateContentHeight()
    //{
    //    float totalHeight = 0;
    //    foreach (Transform child in contentTransform)
    //    {
    //        if (child.TryGetComponent(out RectTransform rectTransform))
    //        {
    //            totalHeight += rectTransform.sizeDelta.y; 
    //            totalHeight += 5; 
    //        }
    //    }

    //    contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, totalHeight);
    //}
}
