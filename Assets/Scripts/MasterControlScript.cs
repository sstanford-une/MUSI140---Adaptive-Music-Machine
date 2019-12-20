using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControlScript : MonoBehaviour
{
    public GameObject musicMenu, ambientMenu, musicSwitch, ambientSwitch;
    GameLogic gameLogic;
    CanvasGroup musicGroup, ambientGroup, fadeInTarget, fadeOutTarget;
    public bool playBack;
    public string disabledParameter;
    Toggle musicToggle, ambientToggle;
    public Button playButton, stopButton;
    public float masterMusicVolume, masterMusicDensity, masterAmbientVolume, masterAmbientDensity;
    List<Button> parameterButtons = new List<Button>();
    List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    List<GameObject> objectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
        //GatherButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetValues()
    {
        playBack = false;
        disabledParameter = "None";
        gameLogic = gameLogic = FindObjectOfType<GameLogic>();
        musicGroup = musicMenu.GetComponent<CanvasGroup>();
        ambientGroup = ambientMenu.GetComponent<CanvasGroup>();
        musicToggle = musicSwitch.GetComponent<Toggle>();
        ambientToggle = ambientSwitch.GetComponent<Toggle>();

        playButton.onClick.AddListener(StartPlayback);
        stopButton.onClick.AddListener(StopPlayback);
        musicToggle.onValueChanged.AddListener(delegate { ViewToggle(); });
        ambientToggle.onValueChanged.AddListener(delegate { ViewToggle(); });
    }

    void StartPlayback()
    {
        playBack = true;
    }

    void StopPlayback()
    {
        playBack = false;
        StopAllCoroutines();
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

    void GatherButtons()
    {
        foreach (Button paramButton in GameObject.FindObjectsOfType(typeof(Button)))
        {
            switch(paramButton.tag)
            {
                case "Music":
                    parameterButtons.Add(paramButton);
                    break;
                case "Ambient":
                    parameterButtons.Add(paramButton);
                    break;
                case "Menu":
                    break;
            }
        }
        Debug.Log(parameterButtons.Count);
    }

    void GatherObjects()
    {
        foreach (CanvasGroup canvasGroup in GameObject.FindObjectsOfType(typeof(CanvasGroup)))
        {
            canvasGroups.Add(canvasGroup);
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
}

