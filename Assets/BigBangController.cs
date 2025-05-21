using UnityEditor;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Experimental.VFX;
using System.Collections;
public class BigBangController : MonoBehaviour
{

    public GameObject childObject;
    private ParticleSystem.ColorOverLifetimeModule colorOverLifetime;
    public VisualEffect visualEffect;
    public ParticleSystem particle;
    public float scaleDuration = 6f;
    public float fadeDuration = 6f;
    public float endScaleMultiplier = 4f;

    private Vector3 _initialScale;  // Начальный масштаб Particle System
    private Vector3 _targetScale;   // Конечный масштаб Particle System
    private float _startTime;
    private enum State { Scaling, Fading, Idle }
    private State _currentState = State.Idle;
    public Material newSkyboxMaterial; 

    public void ChangeSkybox()
    {
        RenderSettings.skybox = newSkyboxMaterial;
    }
    void Start()
    {
        StartScaleAndFade();
    }

    public void StartScaleAndFade()
    {

        _initialScale = particle.transform.localScale; 
        _targetScale = _initialScale * endScaleMultiplier;   

        _startTime = Time.time;
        _currentState = State.Scaling;
        StartCoroutine(ScaleAndFadeCoroutine());
    }

    IEnumerator ScaleAndFadeCoroutine()
    {
        _currentState = State.Scaling;
        while (_currentState == State.Scaling)
        {
            float elapsedTime = Time.time - _startTime;
            float progress = Mathf.Clamp01(elapsedTime / scaleDuration); 
            particle.transform.localScale = Vector3.Lerp(_initialScale, _targetScale, progress); 

            if (progress >= 1f)
            {
                particle.transform.localScale = _targetScale;
                _currentState = State.Fading;
                _startTime = Time.time;
            }

            yield return null;
        }

        while (_currentState == State.Fading)
        {
            float elapsedTime = Time.time - _startTime;
            float alpha = Mathf.Lerp(0.23f, 0f, elapsedTime / fadeDuration);

            SetParticleAlpha(alpha);
   
            if (elapsedTime >= fadeDuration)
            {
                ChangeSkybox();
                SetParticleAlpha(0f); 
                _currentState = State.Idle;
            }

            yield return null;
        }

    }

    private void SetParticleAlpha(float alpha)
    {
        var colorOverLifetime = particle.colorOverLifetime;

        if (colorOverLifetime.enabled)
        {
            Gradient gradient = colorOverLifetime.color.gradient;
            GradientAlphaKey[] alphaKeys = gradient.alphaKeys;

            for (int i = 0; i < alphaKeys.Length; i++)
            {
                alphaKeys[i] = new GradientAlphaKey(alpha, alphaKeys[i].time);
            }

            gradient.alphaKeys = alphaKeys;
            colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient);
        }

    }
}
