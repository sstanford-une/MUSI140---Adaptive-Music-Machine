using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD;
using FMODUnity;


public class MasterControlScript : MonoBehaviour
{
    public GameObject musicMenu, ambientMenu, musicSwitch, ambientSwitch;
    CanvasGroup musicGroup, ambientGroup, fadeInTarget, fadeOutTarget;
    public bool playBack;
    public string disabledParameter;
    Toggle musicToggle, ambientToggle;
    public Button playButton, stopButton;
    public float masterMusicVolume, masterMusicDensity, masterAmbientVolume, masterAmbientDensity;
    SoundControl soundControl;
    FMOD.Studio.Bus masterSwitchBus;
    public GameObject[] presetControl = new GameObject[6];
    ControlLogic[] controlLogicArray = new ControlLogic[6];
    int[] volumePreset = new int[6];
    int[] densityPreset = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetValues()
    {
        soundControl = FindObjectOfType<SoundControl>();
        SetPresets();

        playBack = false;
        disabledParameter = "None";
        musicGroup = musicMenu.GetComponent<CanvasGroup>();
        ambientGroup = ambientMenu.GetComponent<CanvasGroup>();
        musicToggle = musicSwitch.GetComponent<Toggle>();
        ambientToggle = ambientSwitch.GetComponent<Toggle>();

        masterSwitchBus = FMODUnity.RuntimeManager.GetBus("Bus:/MasterSwitch");
        masterSwitchBus.setMute(true);
        playButton.onClick.AddListener(StartPlayback);
        stopButton.onClick.AddListener(StopPlayback);
        musicToggle.onValueChanged.AddListener(delegate { ViewToggle(); });
        ambientToggle.onValueChanged.AddListener(delegate { ViewToggle(); });
    }

    void StartPlayback()
    {
        playBack = true;
        masterSwitchBus.setMute(false);
    }

    void StopPlayback()
    {
        playBack = false;
        masterSwitchBus.setMute(true);
    }

    void ViewToggle()
    {
        if(musicToggle.isOn)
        {
            disabledParameter = "Ambient";
            fadeInTarget = musicGroup;
            fadeOutTarget = ambientGroup;
            ambientGroup.blocksRaycasts = false;
            musicGroup.blocksRaycasts = true;
            ActiveSwitch();
        }
        else if(ambientToggle.isOn)
        {
            disabledParameter = "Music";
            fadeInTarget = ambientGroup;
            fadeOutTarget = musicGroup;
            musicGroup.blocksRaycasts = false;
            ambientGroup.blocksRaycasts = true;
            ActiveSwitch();
        }
    }

    void ActiveSwitch()
    {
        StartCoroutine(FadeIn());
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        while(fadeInTarget.alpha < 1)
        {
            fadeInTarget.alpha += Time.deltaTime * 0.9f;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        while (fadeOutTarget.alpha > 0)
        {
            fadeOutTarget.alpha -= Time.deltaTime * 0.9f;
            yield return null;
        }
    }

    void SetPresets()
    {
        for (int p = 0; p < presetControl.Length; p++)
        {
            controlLogicArray[p] = presetControl[p].GetComponent<ControlLogic>();
        }
    }

    void ActivatePresets(string preset)
    {
        for (int p = 0; p < controlLogicArray.Length; p++)
        {
            controlLogicArray[p].volumeParameter = 1;
            controlLogicArray[p].densityParameter = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

