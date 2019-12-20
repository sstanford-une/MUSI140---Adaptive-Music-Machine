using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlLogic : MonoBehaviour
{
    public Button volumeUp, volumeDown, densityUp, densityDown;
    public GameObject nameObject, volumeObject, densityObject;
    TextMeshProUGUI nameText, volumeText, densityText;
    MasterControlScript masterControlScript;
    public float volumeParameter, densityParameter;
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

        nameText = nameObject.GetComponent<TextMeshProUGUI>();
        volumeText = volumeObject.GetComponent<TextMeshProUGUI>();
        densityText = densityObject.GetComponent<TextMeshProUGUI>();

        volumeParameter = 0;
        densityParameter = 0;
    }

    void IncreaseVolume()
    {
        volumeParameter = Mathf.Clamp((volumeParameter += 1), 0f, 10f);
        volumeText.text = (volumeParameter * 10) + "%";
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
}
