using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLogic : MonoBehaviour
{
    public string parameterType;
    public GameObject volumeUp, volumeDown, densityUp, densityDown;
    public GameObject[] volumeLevel = new GameObject[10];
    public GameObject[] densityLevel = new GameObject[10];
    SpriteRenderer[] childSprites;
    SpriteRenderer spriteRenderer;
    GameLogic gameLogic;
    CanvasGroup canvasGroup;
    public float fadeScale, fadeSpeed, volumeParameter, densityParameter;
    public bool currentlyActive;
    string activeParameter;

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
        GatherChildren();
        ChildFadeScale();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveCheck();
        ActiveSwitch();
    }

    void SetValues()
    {
        gameLogic = FindObjectOfType<GameLogic>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        currentlyActive = false;

        volumeParameter = 0;
        densityParameter = 0;

        //Active Parameter values
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        fadeScale = 0.0f;
        fadeSpeed = 0.025f;
    }

    void ActiveCheck()
    {
        if (parameterType == gameLogic.activeParameter)
        {
            currentlyActive = true;
        }
        else
        {
            currentlyActive = false;
        }
    }

    void ActiveSwitch()
    {
        if (currentlyActive)
        {
            StartCoroutine(Activation(1f));
        }
        else if (!currentlyActive)
        {
            StartCoroutine(Deactivation(1f));
        }
    }

    IEnumerator Activation(float fadeTime)
    {
        while (fadeScale < 1)
        {
            ChildFadeScale();
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
        while (fadeScale > 1)
        {
            ChildFadeScale();
            fadeScale -= fadeSpeed;
            if (fadeScale <= 0)
            {
                StopCoroutine(Deactivation(1f));
            }
            yield return new WaitForSeconds(fadeTime);
        }
    }

    void GatherChildren()
    {
        childSprites = new SpriteRenderer[transform.childCount];
        for (int childIndex = 0; childIndex < transform.childCount; childIndex++)
        {
            Transform child = gameObject.transform.GetChild(childIndex);
            childSprites[childIndex] = child.gameObject.GetComponent<SpriteRenderer>();
        }
    }

    void ChildFadeScale()
    {
        foreach (SpriteRenderer childRenderer in childSprites)
        {
            childRenderer.color = new Color(1f, 1f, 1f, fadeScale);
        }
    }
}
