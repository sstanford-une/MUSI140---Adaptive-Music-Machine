using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    ParamLogic paramLogic;

    //Active parameter settings
    bool currentlyActive;
    SpriteRenderer spriteRenderer;
    float fadeScale, fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveSwitch();
    }

    void SetValues()
    {
        paramLogic = gameObject.GetComponentInParent<ParamLogic>();

        //Active Parameter values
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        currentlyActive = false;
        fadeScale = paramLogic.fadeScale;
        fadeSpeed = 0.1f;
    }

    void ActiveSwitch()
    {
        currentlyActive = paramLogic.currentlyActive;
        if (currentlyActive)
        {
            StartCoroutine(Activation(0.1f));
        }
        else if (!currentlyActive)
        {
            StartCoroutine(Deactivation(0.1f));
        }
    }

    IEnumerator Activation(float fadeTime)
    {
        while (fadeScale < 1)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, fadeScale);
            fadeScale += fadeSpeed;
            if (fadeScale >= 1)
            {
                StopCoroutine(Activation(0.01f));
            }
            yield return new WaitForSeconds(fadeTime);
        }
    }

    IEnumerator Deactivation(float fadeTime)
    {
        while (fadeScale > 0)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, fadeScale);
            fadeScale -= fadeSpeed;
            if (fadeScale <= 0)
            {
                StopCoroutine(Deactivation(0.1f));
            }
            yield return new WaitForSeconds(fadeTime);
        }
    }
}
