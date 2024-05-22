using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public InputActionReference pauseAction;
    public Slider soundEffectsSlider;
    public Slider musicSlider;
    public Slider brightnessSlider;
    public AudioSource soundEffectsSource;
    public AudioSource musicSource;
    public List<Light> environmentLights;

    private void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += OnPauseAction;
    }

    private void OnDisable()
    {
        pauseAction.action.Disable();
        pauseAction.action.performed -= OnPauseAction;
    }

    private void Start()
    {
        // Initialize sliders with current values
        soundEffectsSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume", 1.0f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness", 1.0f);

        soundEffectsSlider.onValueChanged.AddListener(OnSoundEffectsSliderChanged);
        musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);
        brightnessSlider.onValueChanged.AddListener(OnBrightnessSliderChanged);

        pauseMenuUI.SetActive(false);
    }

    private void OnPauseAction(InputAction.CallbackContext context)
    {
        Debug.Log("Pause action triggered");
        TogglePauseMenu();
    }

    private void TogglePauseMenu()
    {
        bool isActive = pauseMenuUI.activeSelf;
        pauseMenuUI.SetActive(!isActive);

        if (!isActive)
        {
            Debug.Log("Showing Pause Menu");
            // Position the pause menu in front of the user
            Vector3 cameraPosition = Camera.main.transform.position;
            Vector3 cameraForward = Camera.main.transform.forward;
            pauseMenuUI.transform.position = cameraPosition + cameraForward * 2.0f; // Adjust the distance as needed
            pauseMenuUI.transform.rotation = Quaternion.LookRotation(cameraForward);

            // Pause the game
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("Hiding Pause Menu");
            // Resume the game
            Time.timeScale = 1f;
        }
    }

    private void OnSoundEffectsSliderChanged(float value)
    {
        soundEffectsSource.volume = value;
        PlayerPrefs.SetFloat("SoundEffectsVolume", value);
    }

    private void OnMusicSliderChanged(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void OnBrightnessSliderChanged(float value)
    {
        foreach (Light light in environmentLights)
        {
            light.intensity = value;
        }
        PlayerPrefs.SetFloat("Brightness", value);
    }

    public void OnResumeButton()
    {
        TogglePauseMenu();
    }

    public void OnExitButton()
    {
        Time.timeScale = 1f; // Ensure time is running before changing scenes
        SceneManager.LoadScene(0);
    }
}
