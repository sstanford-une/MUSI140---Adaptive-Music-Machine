using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMOD;
using FMODUnity;

public class ControlLogic : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;
    [FMODUnity.EventRef] public string parameterName;
    [Range(0f, 10f)] public float volumeParameter, densityParameter;
    public GameObject nameObject, volumeObject, densityObject;
    public Button volumeUp, volumeDown, densityUp, densityDown, masterStart, masterStop;
    TextMeshProUGUI nameText, volumeText, densityText;
    MasterControlScript masterControlScript;
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
        instance.setParameterByName("LocalIntensity", volumeParameter);
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
        instance.setParameterByName("LocalIntensity", volumeParameter);
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
        instance.setParameterByName("LocalDensity", volumeParameter);
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
        instance.setParameterByName("LocalDensity", volumeParameter);
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
        instance.start();
    }

    void StopPlayback()
    {
        //instance.stop();
    }
}
