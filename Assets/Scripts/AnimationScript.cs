using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    public GameObject parameterObject;
    RectTransform rectTransform;
    ControlLogic controlLogic;
    MasterControlScript masterControlScript;
    float scaleSpeed, scaleTime, maxScaleValue;
    private Vector3 minScale, maxScale;
    public string primaryDesignation, secondaryDesignation;
    bool playBack;

    void Start()
    {
        SetValues();
    }

    void Update()
    {
        RotateAndResize();
        ParamCheck();
    }

    void SetValues()
    {
        masterControlScript = FindObjectOfType<MasterControlScript>();
        controlLogic = parameterObject.GetComponent<ControlLogic>();
        rectTransform = GetComponent<RectTransform>();
        scaleSpeed = 2f;
        scaleTime = 1f;
        minScale = new Vector3(1, 1, 1);
        playBack = false;
    }

    void ParamCheck()
    {
        playBack = masterControlScript.playBack;
    }

    void RotateAndResize()
    {
        switch (primaryDesignation)
        {
            case "Music Menu":
                if(playBack)
                {
                    MenuAnimate();
                }
                break;
            case "Ambient Menu":
                if (playBack)
                {
                    MenuAnimate();
                }
                break;
            case "Master Switch":

                break;
            case "Playback":
                PlayBackAnimate();
                break;
        }
    }

    void MenuAnimate()
    {
        if (controlLogic.currentlyActive && controlLogic.fadeScale > 0)
        {
            //Rotating
            rectTransform.Rotate((controlLogic.densityParameter * controlLogic.fadeScale * 50) * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = ((controlLogic.volumeParameter / 20) + 1);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
            StartCoroutine(ButtonResize());
        }
    }

    void MasterAnimate()
    {
        if(secondaryDesignation == "Music Master")
        {
            //Rotation
            rectTransform.Rotate(masterControlScript.masterMusicDensity * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = ((masterControlScript.masterMusicVolume / 20) + 1);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
            StartCoroutine(ButtonResize());
        }
        else if(secondaryDesignation == "Ambient Master")
        {
            //Rotation
            rectTransform.Rotate(masterControlScript.masterAmbientDensity * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = ((masterControlScript.masterAmbientVolume / 20) + 1);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
            StartCoroutine(ButtonResize());
        }
    }

    void PlayBackAnimate()
    {
        if (playBack && secondaryDesignation == "Play")
        {
            rectTransform.Rotate(50 * Vector3.back * Time.deltaTime);
        }
        else if (!playBack && secondaryDesignation == "Stop")
        {
            rectTransform.Rotate(50 * Vector3.back * Time.deltaTime);
        }
    }

    IEnumerator ButtonResize()
    {
        while (controlLogic.fadeScale > 0)
        {
            yield return ResizeScale(minScale, maxScale, scaleTime);
            yield return ResizeScale(maxScale, minScale, scaleTime);
        }
    } 

    IEnumerator ResizeScale(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * scaleSpeed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
