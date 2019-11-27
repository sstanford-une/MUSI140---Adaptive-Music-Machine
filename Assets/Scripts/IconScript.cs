using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconScript : MonoBehaviour
{
    ParamLogic paramLogic;

    //Active parameter settings
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
        fadeScale = paramLogic.fadeScale;
        fadeSpeed = 0.025f;
    }

    void ActiveSwitch()
    {
        if (paramLogic.currentlyActive)
        {
            StartCoroutine(Activation(1f));
        }
        else if (!paramLogic.currentlyActive)
        {
            StartCoroutine(Deactivation(1f));
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
                StopCoroutine(Activation(1f));
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
                StopCoroutine(Deactivation(1f));
            }
            yield return new WaitForSeconds(fadeTime);
        }
    }
}
