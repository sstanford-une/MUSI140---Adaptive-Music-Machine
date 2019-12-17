using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject parameterObject;
    ControlLogic controlLogic;
    float fadeScale, fadeSpeed, fadeScaleValue, scaleSpeed, scaleTime, maxScaleValue, positionValueX, positionValueZ;
    private Vector3 minScale, maxScale;

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
        controlLogic = parameterObject.GetComponentInParent<ControlLogic>();
        fadeSpeed = 0.025f;
        scaleSpeed = 2f;
        scaleTime = 1f;
        minScale = new Vector3(6, 6, 1);
    }

    void RotateAndResize()
    {
        if (controlLogic.currentlyActive && controlLogic.fadeScale > 0)
        {
            //Rotating
            transform.Rotate((controlLogic.densityParameter * controlLogic.fadeScale * 50) * Vector3.back * Time.deltaTime);

            //Resizing
            maxScaleValue = (controlLogic.volumeParameter /10 * 4 + 6);
            maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
            StartCoroutine(ButtonResize());
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
