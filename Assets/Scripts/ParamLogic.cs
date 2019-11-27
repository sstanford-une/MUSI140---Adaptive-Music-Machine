using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamLogic : MonoBehaviour
{
    GameLogic gameLogic;
    public string parameterType;
    string activeParameter;
    public bool currentlyActive;
    public float fadeScale, fadeSpeed, positionValueX, positionValueZ, parameterX, parameterZ;
    float lengthX, lengthZ, clampUp, clampDown, clampLeft, clampRight;
    private Vector3 screenPoint, offset, startMarkerX, endMarkerX, startMarkerZ, endMarkerZ, positionCalculatorX, positionCalculatorZ;


    void Start()
    {
        SetValues();
    }

    void Update()
    {
        ActiveCheck();
        CheckParameters();
    }

    void SetValues()
    {
        gameLogic = FindObjectOfType<GameLogic>();

        //Active Parameter values
        activeParameter = gameLogic.activeParameter;
        currentlyActive = false;
        fadeScale = 0.0f;
        fadeSpeed = 0.1f;

        //Clamp Values
        clampUp = 31;
        clampDown = -31;
        clampLeft = -31;
        clampRight = 63;

        //Parameter and Position Values
        startMarkerX = new Vector3(-31, 05, 00);
        endMarkerX = new Vector3(63, 05, 00);
        startMarkerZ = new Vector3(00, 05, -31);
        endMarkerZ = new Vector3(00, 05, 31);
        lengthX = Vector3.Distance(startMarkerX, endMarkerX);
        lengthZ = Vector3.Distance(startMarkerZ, endMarkerZ);
    }

    void OnMouseDown()
    {
        if (currentlyActive)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (currentlyActive)
        {
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 before_clamp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
            transform.position = new Vector3(Mathf.Clamp(before_clamp.x, clampLeft, clampRight), before_clamp.y, Mathf.Clamp(before_clamp.z, clampDown, clampUp));
        }
    }

    void OnMouseUp()
    {
        if (currentlyActive)
        {
            Debug.Log("Parameter X = " + (parameterX));
            Debug.Log("Parameter Z = " + (parameterZ));
        }
    }

    void CheckParameters()
    {
        //Calculate 'parameterX'
        positionCalculatorX = new Vector3((gameObject.transform.position.x), 05, 00);
        positionValueX = Vector3.Distance(positionCalculatorX, startMarkerX);
        parameterX = ((positionValueX / lengthX) * 10);

        //Calculate 'parameterZ'
        positionCalculatorZ = new Vector3(00, 05, (gameObject.transform.position.z));
        positionValueZ = Vector3.Distance(positionCalculatorZ, startMarkerZ);
        parameterZ = ((positionValueZ / lengthZ) * 10);
    }

    void ActiveCheck()
    {
        if(parameterType == gameLogic.activeParameter)
        {
            currentlyActive = true;
        }
        else
        {
            currentlyActive = false;
        }
    }
}
