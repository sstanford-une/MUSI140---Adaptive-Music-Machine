using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSlider : MonoBehaviour
{
    public GameObject[] parameterObjects = new GameObject[8];
    public Slider masterParameterSlide;
    public GameLogic gameLogic;
    Vector3[] currentPositions = new Vector3[8];
    Vector3[] prescribedPath = new Vector3[8];
    Vector3[] directPath = new Vector3[8];
    Vector3[] smoothPath = new Vector3[8];
    Vector3 highTarget, lowTarget;
    float[] lowTargetDistance = new float[8];
    float[] highTargetDistance = new float[8];
    float[] totalDistance = new float[8];
    float[] percentageDistance = new float[8];
    float[] moveDistanceHigh = new float[8];
    float[] moveDistanceLow = new float[8];
    float lastValue, targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        masterParameterSlide.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        SetValues();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetValues()
    {
        highTarget = new Vector3(63, 05, 31);
        lowTarget = new Vector3(-31, 05, -31);
        targetDistance = Vector3.Distance(highTarget, lowTarget);
        lastValue = masterParameterSlide.normalizedValue;
    }

    public void ValueChangeCheck()
    {
        MasterDrag();
    }

    void PositionCheck()
    {
        for (int i = 0; i < parameterObjects.Length; i++)
        {
            currentPositions[i] = new Vector3((parameterObjects[i].transform.position.x), 05, (parameterObjects[i].transform.position.z));
        }
    }

    void DistanceChecks()
    {
        for (int p = 0; p < parameterObjects.Length; p++)
        {
            lowTargetDistance[p] = (Vector3.Distance(currentPositions[p], lowTarget));
            highTargetDistance[p] = (Vector3.Distance(currentPositions[p], highTarget));
            totalDistance[p] = (lowTargetDistance[p] + highTargetDistance[p]);
            percentageDistance[p] = (lowTargetDistance[p] / totalDistance[p]);
            moveDistanceHigh[p] = ((lowTargetDistance[p] / totalDistance[p]) * masterParameterSlide.normalizedValue);
            moveDistanceLow[p] = ((highTargetDistance[p] / totalDistance[p]) *  masterParameterSlide.normalizedValue);
        }
    }

    void MasterDrag()
    {
        if(lastValue < masterParameterSlide.normalizedValue)
        {
            PositionCheck();
            DistanceChecks();
            MoveParametersHigher();
            lastValue = masterParameterSlide.normalizedValue;
            Debug.Log(lastValue);
        }
        else if (lastValue > masterParameterSlide.normalizedValue)
        {
            PositionCheck();
            DistanceChecks();
            MoveParametesLower();
            lastValue = masterParameterSlide.normalizedValue;
            Debug.Log(lastValue);
        }
    }

    void MoveParametersHigher()
    {
        for(int p = 0; p < parameterObjects.Length; p++)
        {
            prescribedPath[p] = Vector3.Lerp(lowTarget, highTarget, masterParameterSlide.normalizedValue);
            directPath[p] = Vector3.Lerp(currentPositions[p], highTarget, masterParameterSlide.normalizedValue);
            smoothPath[p] = Vector3.Lerp(prescribedPath[p], directPath[p], masterParameterSlide.normalizedValue);
            parameterObjects[p].transform.position = Vector3.Lerp(currentPositions[p], smoothPath[p], masterParameterSlide.normalizedValue);
        }
    }

    void MoveParametesLower()
    {
        for (int p = 0; p < parameterObjects.Length; p++)
        {
            prescribedPath[p] = Vector3.Lerp(lowTarget, highTarget, masterParameterSlide.normalizedValue);
            directPath[p] = Vector3.Lerp(currentPositions[p], lowTarget, (1 - masterParameterSlide.normalizedValue));
            smoothPath[p] = Vector3.Lerp(prescribedPath[p], directPath[p], masterParameterSlide.normalizedValue);
            parameterObjects[p].transform.position = Vector3.Lerp(currentPositions[p], smoothPath[p], (1 - masterParameterSlide.normalizedValue));
        }
    }
}
