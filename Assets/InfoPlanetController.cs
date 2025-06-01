using UnityEngine;
using TMPro;
using SolarSystem;
using System.Collections.Generic;
public class InfoPlanetController : MonoBehaviour
{

    public Camera mainCamera;
    public float transitionSpeed = 3.0f; // �������� ����������� ������
    public Vector3 cameraOffset = new Vector3(0, 5, -10); // �������� ������ ������������ �������
    public GameObject infoPanel;
    public GameObject SolarSystem;
    // ������� ��� �������� ���������� � ��������.  ���� - ��� �������, �������� - ����������.
    public Dictionary<string, SolarSystemObjectInfo> planetInfo = new Dictionary<string, SolarSystemObjectInfo>();

    private bool isMoving = false;
    private Vector3 originalCameraPosition; // �������� ������� ������
    private Quaternion originalCameraRotation; // �������� ������� ������
    private Transform targetPlanet; //������� �������, � ������� ��������� ������
    private SolarSystemObjectInfo currentPlanetInfo; //���������� � ������� �������
    private Main SolarS;
    void Start()
    {
        SolarS = SolarSystem.GetComponent<Main>();
        planetInfo.Add("������", SSOInfos.Sun);
        planetInfo.Add("��������", SSOInfos.MercuryInfo);
        planetInfo.Add("������", SSOInfos.VenusInfo);
        planetInfo.Add("�����", SSOInfos.EarthInfo);
        planetInfo.Add("����", SSOInfos.MoonInfo);
        planetInfo.Add("����", SSOInfos.MarsInfo);
        planetInfo.Add("������", SSOInfos.JupiterInfo);
        planetInfo.Add("������", SSOInfos.SaturnInfo);
        planetInfo.Add("����", SSOInfos.UranusInfo);
        planetInfo.Add("������", SSOInfos.NetputeInfo);
        planetInfo.Add("������", SSOInfos.Pluto);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // ���� ������ ����� ������ ����
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // ������� ��� �� ������� ����
            RaycastHit hit; // ���������� ��� �������� ���������� � ������������ ���� � ��������
            if (Physics.Raycast(ray, out hit)) // ���� ��� ���������� � �����-���� ��������
            {
                
                string objectName = hit.collider.gameObject.name;

                
                if (planetInfo.ContainsKey(objectName))
                {
                   
                    currentPlanetInfo = planetInfo[objectName];
                  
                    targetPlanet = hit.transform;

                    originalCameraPosition = mainCamera.transform.position; // ���������� �������� ������� ������
                    originalCameraRotation = mainCamera.transform.rotation; // ���������� �������� ������� ������
                    MoveCameraToPlanet(targetPlanet); // ���������� ������ � �������
                    ShowPlanetInfo(currentPlanetInfo, objectName); 

                }
                else
                {
                    Debug.LogWarning("��� ���������� � �������: " + objectName); // ������� �������������� � �������, ���� ��� ����������
                }
            }
        }

        if (isMoving) // ���� ������ ������������
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPlanet.position + cameraOffset, transitionSpeed * Time.deltaTime); // ������ ���������� ������ � �������
            mainCamera.transform.LookAt(targetPlanet); // ������ ������� �� �������
        }

        if (Input.GetMouseButtonDown(1) && Input.GetMouseButtonDown(0)) // ���� ������ ������ ������ ����
        {
            ReturnCamera(); // ���������� ������ � �������� ���������
            HidePlanetInfo(); // �������� ���������� � �������

        }
    }

    void MoveCameraToPlanet(Transform planet)
    {
        isMoving = true; // �������� ����������� ������
    }

    void ReturnCamera()
    {
        isMoving = false; // ������������� ����������� ������
        StartCoroutine(AnimateCameraReturn()); // ��������� �������� ��� �������� �������� ������
    }

    System.Collections.IEnumerator AnimateCameraReturn()
    {
        float t = 0; // ���������� ��� ������������ ��������� ��������
        Vector3 startPosition = mainCamera.transform.position; // ��������� ������� ������
        Quaternion startRotation = mainCamera.transform.rotation; // ��������� ������� ������

        while (t < 1) // ���� �������� �� ���������
        {
            t += Time.deltaTime * transitionSpeed; // ����������� �������� ��������
            mainCamera.transform.position = Vector3.Lerp(startPosition, originalCameraPosition, t); // ������ ���������� ������ � �������� �������
            mainCamera.transform.rotation = Quaternion.Slerp(startRotation, originalCameraRotation, t); // ������ ������������ ������ � ��������� ���������
            yield return null; // ���� ��������� ����
        }

        mainCamera.transform.position = originalCameraPosition; // ������������� ������ � �������� ���������
        mainCamera.transform.rotation = originalCameraRotation; // ������������� ������ � �������� �������
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
                info += "���: " + infoText.body_type.GetDescription() + "\n";
                info += "���������� ���������: " + infoText.count_of_sputnik + "\n";
                info += "��������� ���������� �������: " + infoText.g + " �/�^2\n";
                info += "������ ����������� ��������: " + infoText.first_space_speed + " ��/�\n";
                info += "������ ����������� ��������: " + infoText.second_space_speed + " ��/�\n";
                info += "������: " + infoText.openear + "\n";
                info += "��� ������: " + infoText.openear_by + "\n";

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
