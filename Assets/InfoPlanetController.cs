using UnityEngine;
using TMPro;
public class InfoPlanetController : MonoBehaviour
{

    public Camera mainCamera;
    public Transform planetPosition;
    public GameObject infoPanel;
    public float transitionSpeed = 3.0f; // Скорость перемещения камеры
    public Vector3 cameraOffset = new Vector3(0, 5, -10); // Смещение камеры относительно объекта
    public string sunInfoText = "Информация о Солнце: ..."; // Текст для панели

    private bool isMoving = false;
    private Vector3 originalCameraPosition; // Исходная позиция камеры
    private Quaternion originalCameraRotation; // Исходный поворот камеры

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                originalCameraPosition = mainCamera.transform.position;
                originalCameraRotation = mainCamera.transform.rotation;
                MoveCameraToSun();
                ShowSunInfo();
            }
            else
            {
                Debug.Log("Raycast ничего не обнаружил");
            }
        }

        if (isMoving)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, planetPosition.position + cameraOffset, transitionSpeed * Time.deltaTime);
            mainCamera.transform.LookAt(planetPosition);
        }

        if (Input.GetMouseButtonDown(1) && Input.GetMouseButtonDown(0))
        {
            ReturnCamera();
            HideSunInfo();
        }
    }

    void MoveCameraToSun()
    {
        isMoving = true;
    }

    void ReturnCamera()
    {
        isMoving = false;
        StartCoroutine(AnimateCameraReturn());
    }

    System.Collections.IEnumerator AnimateCameraReturn()
    {
        float t = 0;
        Vector3 startPosition = mainCamera.transform.position;
        Quaternion startRotation = mainCamera.transform.rotation;

        while (t < 1)
        {
            t += Time.deltaTime * transitionSpeed;
            mainCamera.transform.position = Vector3.Lerp(startPosition, originalCameraPosition, t);
            mainCamera.transform.rotation = Quaternion.Slerp(startRotation, originalCameraRotation, t);
            yield return null;
        }

        mainCamera.transform.position = originalCameraPosition;
        mainCamera.transform.rotation = originalCameraRotation;
    }

    void ShowSunInfo()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
            TextMeshProUGUI textComponent = infoPanel.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null)
            {
                textComponent.text = sunInfoText;
            }

        }
    }

    void HideSunInfo()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
