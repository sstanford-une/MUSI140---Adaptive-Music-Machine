using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD;
using FMODUnity;

public class ControlLogic : MonoBehaviour
{
    public string parameterName;
    [Range(0f, 10f)] public float volumeParameter, densityParameter;
    public GameObject nameObject, volumeObject, densityObject;
    public Button volumeUp, volumeDown, densityUp, densityDown, masterStart, masterStop;
    TextMeshProUGUI nameText, volumeText, densityText;
    MasterControlScript masterControlScript;
    SoundControl soundControl;
    int paramTotal;

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
        masterControlScript = FindObjectOfType<MasterControlScript>();
        soundControl = FindObjectOfType<SoundControl>();

        volumeUp.onClick.AddListener(IncreaseVolume);
        volumeDown.onClick.AddListener(DecreaseVolume);
        densityUp.onClick.AddListener(IncreaseDensity);
        densityDown.onClick.AddListener(DecreaseDensity);
        masterStart.onClick.AddListener(StartPlayback);
        masterStop.onClick.AddListener(StopPlayback);

        nameText = nameObject.GetComponent<TextMeshProUGUI>();
        volumeText = volumeObject.GetComponent<TextMeshProUGUI>();
        densityText = densityObject.GetComponent<TextMeshProUGUI>();
        nameText.text = parameterName;

        volumeParameter = 0;
        densityParameter = 0;
    }

    void IncreaseVolume()
    {
        volumeParameter = Mathf.Clamp((volumeParameter += 1), 0f, 10f);
        volumeText.text = (volumeParameter * 10) + "%";
        ParameterUpdate();
        switch (gameObject.tag)
        {
            case "Music":
                masterControlScript.masterMusicVolume += 1;
                break;
            case "Ambient":
                masterControlScript.masterAmbientVolume += 1;
                break;
        }
    }

    void DecreaseVolume()
    {
        volumeParameter = Mathf.Clamp((volumeParameter -= 1), 0f, 10f);
        volumeText.text = (volumeParameter * 10) + "%";
        ParameterUpdate();
        switch (gameObject.tag)
        {
            case "Music":
                masterControlScript.masterMusicVolume -= 1;
                break;
            case "Ambient":
                masterControlScript.masterAmbientVolume -= 1;
                break;
        }
    }

    void IncreaseDensity()
    {
        densityParameter = Mathf.Clamp((densityParameter += 1), 0f, 10f);
        densityText.text = (densityParameter * 10) + "%";
        ParameterUpdate();
        switch (gameObject.tag)
        {
            case "Music":
                masterControlScript.masterMusicDensity += 1;
                break;
            case "Ambient":
                masterControlScript.masterAmbientDensity += 1;
                break;
        }
    }

    void DecreaseDensity()
    {
        densityParameter = Mathf.Clamp((densityParameter -= 1), 0f, 10f);
        densityText.text = (densityParameter * 10) + "%";
        ParameterUpdate();
        switch (gameObject.tag)
        {
            case "Music":
                masterControlScript.masterMusicDensity -= 1;
                break;
            case "Ambient":
                masterControlScript.masterAmbientDensity -= 1;
                break;
        }
    }

    void StartPlayback()
    {
        //instance.start();
    }

    void StopPlayback()
    {
        //instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    void ParameterUpdate()
    {
        switch (parameterName)
        {
            case "Melody":
                soundControl.Melody.setParameterByName("localDensity", densityParameter);
                soundControl.Melody.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Counterpoint":
                soundControl.Counterpoint.setParameterByName("localDensity", densityParameter);
                soundControl.Counterpoint.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Harmony":
                soundControl.Harmony.setParameterByName("localDensity", densityParameter);
                soundControl.Harmony.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Bass":
                soundControl.Bass.setParameterByName("localDensity", densityParameter);
                soundControl.Bass.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Percussion 1":
                soundControl.PercussionOne.setParameterByName("localDensity", densityParameter);
                soundControl.PercussionOne.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Percussion 2":
                soundControl.PercussionTwo.setParameterByName("localDensity", densityParameter);
                soundControl.PercussionTwo.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Traffic":
                soundControl.AmbienceOne.setParameterByName("localDensity", densityParameter);
                soundControl.AmbienceOne.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Speakers":
                soundControl.AmbienceTwo.setParameterByName("localDensity", densityParameter);
                soundControl.AmbienceTwo.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Droids":
                soundControl.AmbienceThree.setParameterByName("localDensity", densityParameter);
                soundControl.AmbienceThree.setParameterByName("localIntensity", volumeParameter);
                break;
            case "Combat":
                soundControl.AmbienceFour.setParameterByName("localDensity", densityParameter);
                soundControl.AmbienceFour.setParameterByName("localIntensity", volumeParameter);
                break;
        }
    }
}
