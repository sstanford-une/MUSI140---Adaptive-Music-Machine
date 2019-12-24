using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    public GameObject parameterObject, canvasObject;
    CanvasGroup menuCanvas;
    RectTransform rectTransform;
    ControlLogic controlLogic;
    MasterControlScript masterControlScript;
    float scaleSpeed, scaleTime, maxScaleValue, minScaleX, minScaleY, minScaleZ;
    private Vector3 minScale, maxScale;
    public string playBackType;

    void Start()
    {
        SetValues();
    }

    void Update()
    {
        RotateAndResize();
    }

    void SetValues()
    {
        masterControlScript = FindObjectOfType<MasterControlScript>();
        controlLogic = parameterObject.GetComponent<ControlLogic>();
        rectTransform = GetComponent<RectTransform>();
        menuCanvas = canvasObject.GetComponent<CanvasGroup>();
        scaleSpeed = 2f;
        scaleTime = 1f;
        minScaleX = rectTransform.localScale.x;
        minScaleY = rectTransform.localScale.y;
        minScaleZ = rectTransform.localScale.z;
        minScale = new Vector3(minScaleX, minScaleY, minScaleZ);
    }

    void RotateAndResize()
    {
        switch (gameObject.tag)
        {
            case "Music":
                MenuAnimate();
                break;
            case "Ambient":
                MenuAnimate();
                break;
            case "Master":
                MasterAnimate();
                break;
            case "Menu":
                PlayBackAnimate();
                break;
        }
    }

    void MenuAnimate()
    {
        if (masterControlScript.playBack && menuCanvas.alpha > 0)
        {
            //Rotating
            rectTransform.Rotate((controlLogic.densityParameter * menuCanvas.alpha * 50) * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = ((controlLogic.volumeParameter / 20) + minScaleX);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, minScaleZ);
            StartCoroutine(ButtonResize());
        }
        else if (!masterControlScript.playBack)
        {
            StopCoroutine(ButtonResize());
        }
    }

    void MasterAnimate()
    {
        if(playBackType == "Music")
        {
            //Rotation
            rectTransform.Rotate(masterControlScript.masterMusicDensity * 5 * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = ((masterControlScript.masterMusicVolume / 10) + minScaleX);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
            StartCoroutine(ButtonResize());
        }
        else if(playBackType == "Ambient")
        {
            //Rotation
            rectTransform.Rotate(masterControlScript.masterAmbientDensity * 5 * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = ((masterControlScript.masterAmbientVolume / 10) + minScaleX);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
            StartCoroutine(ButtonResize());
        }
    }

    void PlayBackAnimate()
    {
        if (masterControlScript.playBack && playBackType == "Play")
        {
            rectTransform.Rotate(50 * Vector3.back * Time.deltaTime);
        }
        else if (!masterControlScript.playBack && playBackType == "Stop")
        {
            rectTransform.Rotate(50 * Vector3.back * Time.deltaTime);
        }
    }

    IEnumerator ButtonResize()
    {
        while (menuCanvas.alpha > 0)
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
