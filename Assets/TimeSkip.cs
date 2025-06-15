using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class TimeSkip : MonoBehaviour
{
    public GameObject solar;
    private Main main;
    public TMP_InputField tmpInputField1; 
    public TMP_InputField tmpInputField2; 
    private List <TMP_InputField> prevInputField = new List <TMP_InputField>();
    void Start()
    {
        main = solar.GetComponent<Main>();
        prevInputField.Add(tmpInputField1);
        prevInputField.Add(tmpInputField2);
        tmpInputField1.onValueChanged.AddListener(delegate { OnValueChanged(tmpInputField1); });
        tmpInputField2.onValueChanged.AddListener(delegate { OnValueChanged(tmpInputField2); });
    }

    private void OnValueChanged(TMP_InputField inputField)
    {
        string text = inputField.text;
        string cleanedText = "";
        foreach (char c in text)
        {
            if (char.IsDigit(c))  // Разрешаем только цифры
            {
                cleanedText += c;
            }
        }

   
        inputField.text = cleanedText;

        //inputField.caretPosition = cleanedText.Length;
        //inputField.selectionAnchorPosition = cleanedText.Length;
    }
    public void ClearAllInputFields()
    {
        main.skipTime(ulong.Parse(tmpInputField1.text), ulong.Parse(tmpInputField2.text));
        if (prevInputField != null)
        {
            foreach (TMP_InputField inputField in prevInputField)
            {
                if (inputField != null)
                {
                    inputField.text = "";
                }
            }
        }
    }
}
