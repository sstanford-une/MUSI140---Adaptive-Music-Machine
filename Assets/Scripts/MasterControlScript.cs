using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControlScript : MonoBehaviour
{
    public GameObject musicMenu, ambientMenu, musicSwitch, ambientSwitch;
    GameLogic gameLogic;
    CanvasGroup musicGroup, ambientGroup;
    public bool playBack;
    Toggle musicToggle, ambientToggle;
    public Button playButton, stopButton;
    public float[] musicVolumeList = new float[8];
    public float[] musicDensityList = new float[8];
    public float[] ambientVolumeList = new float[8];
    public float[] ambientDensityList = new float[8];
    public float masterMusicVolume, masterMusicDensity, masterAmbientVolume, masterAmbientDensity;

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
        playBack = false;
        gameLogic = gameLogic = FindObjectOfType<GameLogic>();
        musicGroup = musicMenu.GetComponent<CanvasGroup>();
        //ambientGroup = ambientMenu.GetComponent<CanvasGroup>();
        musicToggle = musicSwitch.GetComponent<Toggle>();
        ambientToggle = ambientSwitch.GetComponent<Toggle>();

        playButton.onClick.AddListener(StartPlayback);
        stopButton.onClick.AddListener(StopPlayback);
    }

    void StartPlayback()
    {
        playBack = true;
    }

    void StopPlayback()
    {
        playBack = false;
    }


}

