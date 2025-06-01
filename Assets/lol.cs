using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class InitialScaleSettings
{
    public Vector3 initialScale = Vector3.one;  //������ ��������� �������
}
public class lol : MonoBehaviour
{
    public ParticleSystem ps;  // ������ �� Particle System
    public List<Transform> centerPoints = new List<Transform>(); // ������ ��������-������� ����������
    public List<InitialScaleSettings> initialScales = new List<InitialScaleSettings>(); // ������ INITIAL  ��������� ��� ������� �������

    public float scalingDuration = 10.0f; // �����, �� ������� ������ ������ ������� �������� ��������
    public float releaseDuration = 2f; // �����, �� ������� ���� ���������� ����������� �� ���� ����� ��������� ���������������.

    public float stickDistance = 2.0f; // ����������, �� ������� ������� �������� "���������"
    public float maxStickSpeed = 5.0f; // ������������ �������� ����������
    public float minStickSpeed = 0.5f; // ����������� �������� ���������� (��� ����������� � ������)


    private ParticleSystem.Particle[] particles;
    private List<Vector3> targetScales = new List<Vector3>(); // �������  �������� ��������
    private float scalingTimer = 0.0f; // ������ ��� ������������ ��������� ���������������
    private float releaseTimer = 0f;
    private bool isReleasing = false;


    void Start()
    {
        // ���������, ��� ������� ������ �� �������
        if (ps == null)
        {
            Debug.LogError("Particle System is not assigned!");
            enabled = false; // ��������� ������, ���� �� ������ Particle System
            return;
        }

        if (centerPoints.Count == 0)
        {
            Debug.LogError("No Center Points assigned!");
            enabled = false; // ��������� ������, ���� �� ������ �� ���� Center Point
            return;
        }

        // ���������, ��� ���������� ������� ��������� ������������� ���������� �������
        if (centerPoints.Count != initialScales.Count)
        {
            Debug.LogError("Number of Initial Scales does not match Number of Center Points!");
            enabled = false;
            return;
        }

        // ��������� �������  �������� ��� ������� �������, ��� �� �������
        foreach (Transform center in centerPoints)
        {
            targetScales.Add(center.localScale);
        }
    }

    void LateUpdate()
    {
        if (scalingTimer >= scalingDuration)
        {
            isReleasing = true;
        }

        // �������� ��� �������
        int numParticlesAlive = ps.particleCount;
        if (particles == null || particles.Length < numParticlesAlive)
        {
            particles = new ParticleSystem.Particle[numParticlesAlive];
        }
        ps.GetParticles(particles);

        // ���������� ������� � ��������� ���������� �� ���� �������
        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 totalDirection = Vector3.zero;
            float totalStickSpeed = 0f;

            foreach (Transform center in centerPoints)
            {
                float distance = Vector3.Distance(particles[i].position, center.position);

                if (distance <= stickDistance)
                {
                    float stickSpeed = maxStickSpeed;

                    if (isReleasing)
                    {
                        releaseTimer += Time.deltaTime;
                        float releaseProgress = Mathf.Clamp01(releaseTimer / releaseDuration);
                        stickSpeed = Mathf.Lerp(maxStickSpeed, 0f, releaseProgress);
                    }
                    else
                    {
                        stickSpeed = Mathf.Lerp(minStickSpeed, maxStickSpeed, distance / stickDistance);
                    }

                    Vector3 direction = (center.position - particles[i].position).normalized;
                    totalDirection += direction * stickSpeed;
                    totalStickSpeed += stickSpeed;
                }
            }

            //��������� ����� ����������� � ��������
            if (totalStickSpeed > 0)
            {
                Vector3 finalDirection = totalDirection.normalized;
                particles[i].position += finalDirection * (totalStickSpeed / centerPoints.Count) * Time.deltaTime; //����������� ��������

                //  �������� �� ������ ���������� � ���������� ������
                Transform closestCenter = FindClosestCenter(particles[i].position);
                if (closestCenter != null && Vector3.Distance(particles[i].position, closestCenter.position) < 0.01f)
                {
                    particles[i].position = closestCenter.position;
                    particles[i].velocity = Vector3.zero;
                }
            }
        }

        // ��������� ��������� � Particle System
        ps.SetParticles(particles, numParticlesAlive);

        // ����������� ������ � ������������ ��� �������
        UpdateScales();
    }

    private Transform FindClosestCenter(Vector3 position)
    {
        Transform closestCenter = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform center in centerPoints)
        {
            float distance = Vector3.Distance(position, center.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCenter = center;
            }
        }
        return closestCenter;
    }


    void UpdateScales()
    {
        // ����������� ������
        scalingTimer += Time.deltaTime;

        // ��������� �������� ��������������� (�� 0 �� 1)
        float scalingProgress = Mathf.Clamp01(scalingTimer / scalingDuration);

        for (int i = 0; i < centerPoints.Count; i++)
        {
            Transform center = centerPoints[i];

            // ��������� ����� ������� ��� ������ ���
            float newScaleX = Mathf.Lerp(initialScales[i].initialScale.x, targetScales[i].x, scalingProgress);
            float newScaleY = Mathf.Lerp(initialScales[i].initialScale.y, targetScales[i].y, scalingProgress);
            float newScaleZ = Mathf.Lerp(initialScales[i].initialScale.z, targetScales[i].z, scalingProgress);

            // ������������� ����� �������
            Vector3 newScale = new Vector3(newScaleX, newScaleY, newScaleZ);
            center.localScale = newScale; // ������������� ����� �������
        }
    }
}
