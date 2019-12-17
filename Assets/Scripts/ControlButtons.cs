using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButtons : MonoBehaviour
{
    public string valueType;
    public float valueChange;
    float valueMin = 0, valueMax = 10;
    public GameObject parameterObject;
    ControlLogic controlLogic;

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetValues()
    {
        controlLogic = parameterObject.GetComponent<ControlLogic>();
    }

    void OnMouseDown()
    {
        Debug.Log("I'm Clicked!");
        if (controlLogic.currentlyActive)
        {
            if (valueType == "Volume")
            {
                controlLogic.volumeParameter = Mathf.Clamp((controlLogic.volumeParameter += valueChange), valueMin, valueMax);
            }
            else if (valueType == "Density")
            {
                controlLogic.densityParameter = Mathf.Clamp((controlLogic.densityParameter += valueChange), valueMin, valueMax);
            }
        }
    }
}
