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
            title = "������ ����� ������������� ��������",
            description = "��������� �������� ���� �������� ������ �������",
            day = 95000 * 365
        };

        public static List<AppEvent> events_list = new List<AppEvent>() ;

    }
    public ScrollRect scrollView;
    public GameObject infoPanel;
    public bool isView = false;
    public string textToAdd = "This is a sample text.\n"; // ����� ��� ����������

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
        info += "��������: " + newText.description + "\n";
        info += "����: " + newText.day.ToString() + "\n";

        if (tmpText != null)
        {
            tmpText.text += info;
            LayoutRebuilder.ForceRebuildLayoutImmediate(scrollView.content);
        }
    }
    //// ���������� Scroll Bar ���� (�����������)
    //scrollView.verticalNormalizedPosition = 0;
    //public RectTransform contentTransform;
    //public TextMeshProUGUI eventTextPrefab; // ������ ��� ������ ���������� ����, ����������� ��� ����������
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
    //    info += "��������: " + appEvent.description + "\n";
    //    info += "����: " + appEvent.day.ToString() + "\n";

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
