using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class InitialScaleSettings
{
    public Vector3 initialScale = Vector3.one;  //Задаем начальный масштаб
}
public class lol : MonoBehaviour
{
    public ParticleSystem ps;  // Ссылка на Particle System
    public List<Transform> centerPoints = new List<Transform>(); // Список объектов-центров притяжения
    public List<InitialScaleSettings> initialScales = new List<InitialScaleSettings>(); // Список INITIAL  масштабов для каждого объекта

    public float scalingDuration = 10.0f; // Время, за которое объект должен достичь целевого масштаба
    public float releaseDuration = 2f; // Время, за которое сила притяжения уменьшается до нуля после окончания масштабирования.

    public float stickDistance = 2.0f; // Расстояние, на котором частицы начинают "прилипать"
    public float maxStickSpeed = 5.0f; // Максимальная скорость прилипания
    public float minStickSpeed = 0.5f; // Минимальная скорость прилипания (при приближении к центру)


    private ParticleSystem.Particle[] particles;
    private List<Vector3> targetScales = new List<Vector3>(); // ЦЕЛЕВЫЕ  масштабы объектов
    private float scalingTimer = 0.0f; // Таймер для отслеживания прогресса масштабирования
    private float releaseTimer = 0f;
    private bool isReleasing = false;


    void Start()
    {
        // Проверяем, что указаны ссылки на объекты
        if (ps == null)
        {
            Debug.LogError("Particle System is not assigned!");
            enabled = false; // Отключаем скрипт, если не указан Particle System
            return;
        }

        if (centerPoints.Count == 0)
        {
            Debug.LogError("No Center Points assigned!");
            enabled = false; // Отключаем скрипт, если не указан ни один Center Point
            return;
        }

        // Проверяем, что количество целевых масштабов соответствует количеству центров
        if (centerPoints.Count != initialScales.Count)
        {
            Debug.LogError("Number of Initial Scales does not match Number of Center Points!");
            enabled = false;
            return;
        }

        // Сохраняем целевые  масштабы для каждого объекта, они же текущие
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

        // Получаем все частицы
        int numParticlesAlive = ps.particleCount;
        if (particles == null || particles.Length < numParticlesAlive)
        {
            particles = new ParticleSystem.Particle[numParticlesAlive];
        }
        ps.GetParticles(particles);

        // Перебираем частицы и применяем притяжение от всех центров
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

            //Применяем общее направление и скорость
            if (totalStickSpeed > 0)
            {
                Vector3 finalDirection = totalDirection.normalized;
                particles[i].position += finalDirection * (totalStickSpeed / centerPoints.Count) * Time.deltaTime; //Нормализуем скорость

                //  Проверка на полное прилипание к ближайшему центру
                Transform closestCenter = FindClosestCenter(particles[i].position);
                if (closestCenter != null && Vector3.Distance(particles[i].position, closestCenter.position) < 0.01f)
                {
                    particles[i].position = closestCenter.position;
                    particles[i].velocity = Vector3.zero;
                }
            }
        }

        // Применяем изменения к Particle System
        ps.SetParticles(particles, numParticlesAlive);

        // Увеличиваем таймер и масштабируем все объекты
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
        // Увеличиваем таймер
        scalingTimer += Time.deltaTime;

        // Вычисляем прогресс масштабирования (от 0 до 1)
        float scalingProgress = Mathf.Clamp01(scalingTimer / scalingDuration);

        for (int i = 0; i < centerPoints.Count; i++)
        {
            Transform center = centerPoints[i];

            // Вычисляем новый масштаб для каждой оси
            float newScaleX = Mathf.Lerp(initialScales[i].initialScale.x, targetScales[i].x, scalingProgress);
            float newScaleY = Mathf.Lerp(initialScales[i].initialScale.y, targetScales[i].y, scalingProgress);
            float newScaleZ = Mathf.Lerp(initialScales[i].initialScale.z, targetScales[i].z, scalingProgress);

            // Устанавливаем новый масштаб
            Vector3 newScale = new Vector3(newScaleX, newScaleY, newScaleZ);
            center.localScale = newScale; // Устанавливаем новый масштаб
        }
    }
}
