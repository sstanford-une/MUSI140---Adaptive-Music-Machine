using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlLogic : MonoBehaviour
{
    public string parameterType, parameterName;
    public Button volumeUp, volumeDown, densityUp, densityDown;
    public GameObject nameObject, volumeObject, densityObject;
    TextMeshProUGUI nameText, volumeText, densityText;
    MasterControlScript masterControlScript;
    CanvasGroup canvasGroup;
    public float fadeScale, fadeSpeed, volumeParameter, densityParameter;
    public bool currentlyActive;
    public int listPosition;
    string activeParameter;
    int paramTotal;

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveCheck();
    }

    void SetValues()
    {
        masterControlScript = FindObjectOfType<MasterControlScript>();
        currentlyActive = false;

        volumeUp.onClick.AddListener(IncreaseVolume);
        volumeDown.onClick.AddListener(DecreaseVolume);
        densityUp.onClick.AddListener(IncreaseDensity);
        densityDown.onClick.AddListener(DecreaseDensity);

        nameText = nameObject.GetComponent<TextMeshProUGUI>();
        volumeText = volumeObject.GetComponent<TextMeshProUGUI>();
        densityText = densityObject.GetComponent<TextMeshProUGUI>();

        volumeParameter = 0;
        densityParameter = 0;

        //Active Parameter values
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        fadeScale = 0.0f;
        fadeSpeed = 0.025f;
    }

    void ActiveCheck()
    {
        if (parameterType == null) /*== masterControlScript.activeParameter*/
        {
            volumeUp.interactable = true;
            volumeDown.interactable = true;
            densityUp.interactable = true;
            densityDown.interactable = true;
        }
        else
        {
            volumeUp.interactable = false;
            volumeDown.interactable = false;
            densityUp.interactable = false;
            densityDown.interactable = false;
        }
    }

    void IncreaseVolume()
    {
        volumeParameter = Mathf.Clamp((volumeParameter += 1), 0f, 10f);
        volumeText.text = (volumeParameter * 10) + "%";
        switch (parameterType)
        {
            case "Music":
                masterControlScript.musicVolumeList[listPosition] = volumeParameter;
                paramTotal = 0;
                for(int i = 0; i < masterControlScript.musicVolumeList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.musicVolumeList[i];
                }
                masterControlScript.masterMusicVolume = (paramTotal / masterControlScript.musicVolumeList.Length);
                break;
            case "Ambient":
                masterControlScript.ambientVolumeList[listPosition] = volumeParameter;
                paramTotal = 0;
                for (int i = 0; i < masterControlScript.ambientVolumeList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.ambientVolumeList[i];
                }
                masterControlScript.masterAmbientVolume = (paramTotal / masterControlScript.ambientVolumeList.Length);
                break;
        }
    }

    void DecreaseVolume()
    {
        volumeParameter = Mathf.Clamp((volumeParameter -= 1), 0f, 10f);
        volumeText.text = (volumeParameter * 10) + "%";
        switch (parameterType)
        {
            case "Music":
                masterControlScript.musicVolumeList[listPosition] = volumeParameter;
                paramTotal = 0;
                for (int i = 0; i < masterControlScript.musicVolumeList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.musicVolumeList[i];
                }
                masterControlScript.masterMusicVolume = (paramTotal / masterControlScript.musicVolumeList.Length);
                break;
            case "Ambient":
                masterControlScript.ambientVolumeList[listPosition] = volumeParameter;
                paramTotal = 0;
                for (int i = 0; i < masterControlScript.ambientVolumeList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.ambientVolumeList[i];
                }
                masterControlScript.masterAmbientVolume = (paramTotal / masterControlScript.ambientVolumeList.Length);
                break;
        }
    }

    void IncreaseDensity()
    {
        densityParameter = Mathf.Clamp((densityParameter += 1), 0f, 10f);
        densityText.text = (densityParameter * 10) + "%";
        switch (parameterType)
        {
            case "Music":
                masterControlScript.musicDensityList[listPosition] = densityParameter;
                paramTotal = 0;
                for (int i = 0; i < masterControlScript.musicDensityList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.musicDensityList[i];
                }
                masterControlScript.masterMusicDensity = (paramTotal / masterControlScript.musicDensityList.Length);
                break;
            case "Ambient":
                masterControlScript.ambientDensityList[listPosition] = densityParameter;
                paramTotal = 0;
                for (int i = 0; i < masterControlScript.ambientDensityList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.ambientDensityList[i];
                }
                masterControlScript.masterAmbientDensity = (paramTotal / masterControlScript.ambientDensityList.Length);
                break;
        }
    }

    void DecreaseDensity()
    {
        densityParameter = Mathf.Clamp((densityParameter -= 1), 0f, 10f);
        densityText.text = (densityParameter * 10) + "%";
        switch (parameterType)
        {
            case "Music":
                masterControlScript.musicDensityList[listPosition] = densityParameter;
                paramTotal = 0;
                for (int i = 0; i < masterControlScript.musicDensityList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.musicDensityList[i];
                }
                masterControlScript.masterMusicDensity = (paramTotal / masterControlScript.musicDensityList.Length);
                break;
            case "Ambient":
                masterControlScript.ambientDensityList[listPosition] = densityParameter;
                paramTotal = 0;
                for (int i = 0; i < masterControlScript.ambientDensityList.Length; i++)
                {
                    paramTotal += (int)masterControlScript.ambientDensityList[i];
                }
                masterControlScript.masterAmbientDensity = (paramTotal / masterControlScript.ambientDensityList.Length);
                break;
        }
    }
}
