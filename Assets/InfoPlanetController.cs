using UnityEngine;
using TMPro;
using SolarSystem;
using System.Collections.Generic;
public class InfoPlanetController : MonoBehaviour
{

    public Camera mainCamera;
    public float transitionSpeed = 3.0f; // Скорость перемещения камеры
    public Vector3 cameraOffset = new Vector3(0, 5, -10); // Смещение камеры относительно объекта
    public GameObject infoPanel;
    public GameObject SolarSystem;
    // Словарь для хранения информации о планетах.  Ключ - имя планеты, значение - информация.
    public Dictionary<string, SolarSystemObjectInfo> planetInfo = new Dictionary<string, SolarSystemObjectInfo>();

    private bool isMoving = false;
    private Vector3 originalCameraPosition; // Исходная позиция камеры
    private Quaternion originalCameraRotation; // Исходный поворот камеры
    private Transform targetPlanet; //Текущая планета, к которой двигается камера
    private SolarSystemObjectInfo currentPlanetInfo; //Информация о текущей планете
    private Main SolarS;
    void Start()
    {
        SolarS = SolarSystem.GetComponent<Main>();
        planetInfo.Add("Солнце", SSOInfos.Sun);
        planetInfo.Add("Меркурий", SSOInfos.MercuryInfo);
        planetInfo.Add("Венера", SSOInfos.VenusInfo);
        planetInfo.Add("Земля", SSOInfos.EarthInfo);
        planetInfo.Add("Луна", SSOInfos.MoonInfo);
        planetInfo.Add("Марс", SSOInfos.MarsInfo);
        planetInfo.Add("Юпитер", SSOInfos.JupiterInfo);
        planetInfo.Add("Сатурн", SSOInfos.SaturnInfo);
        planetInfo.Add("Уран", SSOInfos.UranusInfo);
        planetInfo.Add("Нептун", SSOInfos.NetputeInfo);
        planetInfo.Add("Плутон", SSOInfos.Pluto);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Если нажата левая кнопка мыши
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // Создаем луч из позиции мыши
            RaycastHit hit; // Переменная для хранения информации о столкновении луча с объектом
            if (Physics.Raycast(ray, out hit)) // Если луч столкнулся с каким-либо объектом
            {
                
                string objectName = hit.collider.gameObject.name;

                
                if (planetInfo.ContainsKey(objectName))
                {
                   
                    currentPlanetInfo = planetInfo[objectName];
                  
                    targetPlanet = hit.transform;

                    originalCameraPosition = mainCamera.transform.position; // Запоминаем исходную позицию камеры
                    originalCameraRotation = mainCamera.transform.rotation; // Запоминаем исходный поворот камеры
                    MoveCameraToPlanet(targetPlanet); // Перемещаем камеру к планете
                    ShowPlanetInfo(currentPlanetInfo, objectName); 

                }
                else
                {
                    Debug.LogWarning("Нет информации о планете: " + objectName); // Выводим предупреждение в консоль, если нет информации
                }
            }
        }

        if (isMoving) // Если камера перемещается
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPlanet.position + cameraOffset, transitionSpeed * Time.deltaTime); // Плавно перемещаем камеру к планете
            mainCamera.transform.LookAt(targetPlanet); // Камера смотрит на планету
        }

        if (Input.GetMouseButtonDown(1) && Input.GetMouseButtonDown(0)) // Если нажата правая кнопка мыши
        {
            ReturnCamera(); // Возвращаем камеру в исходное положение
            HidePlanetInfo(); // Скрываем информацию о планете

        }
    }

    void MoveCameraToPlanet(Transform planet)
    {
        isMoving = true; // Начинаем перемещение камеры
    }

    void ReturnCamera()
    {
        isMoving = false; // Останавливаем перемещение камеры
        StartCoroutine(AnimateCameraReturn()); // Запускаем корутину для плавного возврата камеры
    }

    System.Collections.IEnumerator AnimateCameraReturn()
    {
        float t = 0; // Переменная для отслеживания прогресса анимации
        Vector3 startPosition = mainCamera.transform.position; // Начальная позиция камеры
        Quaternion startRotation = mainCamera.transform.rotation; // Начальный поворот камеры

        while (t < 1) // Пока анимация не завершена
        {
            t += Time.deltaTime * transitionSpeed; // Увеличиваем прогресс анимации
            mainCamera.transform.position = Vector3.Lerp(startPosition, originalCameraPosition, t); // Плавно перемещаем камеру к исходной позиции
            mainCamera.transform.rotation = Quaternion.Slerp(startRotation, originalCameraRotation, t); // Плавно поворачиваем камеру к исходному положению
            yield return null; // Ждем следующий кадр
        }

        mainCamera.transform.position = originalCameraPosition; // Устанавливаем камеру в исходное положение
        mainCamera.transform.rotation = originalCameraRotation; // Устанавливаем камеру в исходный поворот
    }

    void ShowPlanetInfo(SolarSystemObjectInfo infoText, string objectName)
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true); 
            TextMeshProUGUI textComponent = infoPanel.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null) 
            {
                
                string info = "<b>" + objectName + "</b>\n"; 
                info += "Тип: " + infoText.body_type.GetDescription() + "\n";
                info += "Количество спутников: " + infoText.count_of_sputnik + "\n";
                info += "Ускорение свободного падения: " + infoText.g + " м/с^2\n";
                info += "Первая космическая скорость: " + infoText.first_space_speed + " км/с\n";
                info += "Вторая космическая скорость: " + infoText.second_space_speed + " км/с\n";
                info += "Открыт: " + infoText.openear + "\n";
                info += "Кем открыт: " + infoText.openear_by + "\n";

                textComponent.text = info;

                SolarS.isPaused = true;

            }

        }
    }

    void HidePlanetInfo()
    {
        if (infoPanel != null) 
        {
            infoPanel.SetActive(false); 
            SolarS.isPaused = false;

        }
    }
}
