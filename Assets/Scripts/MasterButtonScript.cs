using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButtonScript : MonoBehaviour
{
    public GameObject masterObject, gameController;
    MasterScript masterScript;
    GameLogic gameLogic;
    float parameterX, positionValueX, parameterZ, positionValueZ, maxScaleValue, scaleSpeed, scaleTime, scaleValue;
    Vector3 minScale, maxScale;

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckParameters();
        RotateAndResize();
    }

    void SetValues()
    {
        masterScript = masterObject.GetComponent<MasterScript>();
        gameLogic = gameController.GetComponent<GameLogic>();
        minScale = new Vector3(6, 6, 1);
        scaleSpeed = 2f;
        scaleTime = 1f;
    }

    void CheckParameters()
    {
        
    }

    void RotateAndResize()
    {
        //Scaling
        scaleValue = (masterScript.masterPositionValueX * 10f);
        gameObject.transform.Rotate(scaleValue * Vector3.back * Time.deltaTime);

        //Resizing
        maxScaleValue = (masterScript.masterPositionValueZ / 100 * 4 + 6);
        maxScale = new Vector3(maxScaleValue, maxScaleValue, 1);
        StartCoroutine(ButtonResize());
    }

    IEnumerator ButtonResize()
    {
        while (masterScript.playback)
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
