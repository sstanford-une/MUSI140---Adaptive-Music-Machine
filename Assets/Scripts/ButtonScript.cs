﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    ParamLogic paramLogic;
    SpriteRenderer spriteRenderer;
    float fadeScale, fadeSpeed, fadeScaleValue, scaleSpeed, scaleTime, maxScaleValue, positionValueX, positionValueZ;
    bool currentlyActive;
    string parameterType;
    private Vector3 screenPoint, offset, minScale, maxScale;

    void Start()
    {
        SetValues();
    }

    void Update()
    {
        CheckParameters();
        RotateAndResize();
        ActiveSwitch();
    }

    void SetValues()
    {
        paramLogic = gameObject.GetComponentInParent<ParamLogic>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        fadeScale = paramLogic.fadeScale;
        parameterType = paramLogic.parameterType;
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        fadeSpeed = 0.1f;
        scaleSpeed = 2f;
        scaleTime = 1f;
        minScale = new Vector3(6, 6, 1);
    }

    void RotateAndResize()
    {
        if (fadeScale > 0)
        {
            //Scaling
            fadeScaleValue = (positionValueX * fadeScale * 10f);
            transform.Rotate(fadeScaleValue * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = (positionValueZ /100 * 4 + 6);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
            StartCoroutine(ButtonResize());
        }
    }

    void CheckParameters()
    {
        if (fadeScale > 0)
        {
            //Update Parmeters from ParamLogic
            positionValueX = paramLogic.positionValueX;
            positionValueZ = paramLogic.positionValueZ;
        }
    }

    void ActiveSwitch()
    {
        currentlyActive = paramLogic.currentlyActive;
        if (currentlyActive)
        {
            StartCoroutine(ButtonFadeIn(0.1f));
        }
        else if(!currentlyActive)
        {
            StartCoroutine(ButtonFadeOut(0.1f));
        }
    }


    IEnumerator ButtonFadeIn(float fadeTime)
    {
        while(fadeScale < 1)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, fadeScale);
            fadeScale += fadeSpeed;
            if(fadeScale >= 1)
            {
                StopCoroutine(ButtonFadeIn(0.01f));
            }
            yield return new WaitForSeconds(fadeTime);
        }
    }

    IEnumerator ButtonFadeOut(float fadeTime)
    {
        while (fadeScale > 0)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, fadeScale);
            fadeScale -= fadeSpeed;
            if (fadeScale <= 0)
            {
                StopCoroutine(ButtonFadeOut(0.1f));
            }
            yield return new WaitForSeconds(fadeTime);
        }
    }

    IEnumerator ButtonResize()
    {
        while (fadeScale > 0)
        {
            yield return ResizeScale(minScale, maxScale, scaleTime);
            yield return ResizeScale(maxScale, minScale, scaleTime);

            //lerp down scale
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