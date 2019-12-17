using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    public GameObject gameController;
    public GameObject[] paramObjects = new GameObject[8];
    ParamLogic[] paramData = new ParamLogic[8];
    GameLogic gameLogic;
    public string parameterType;
    public float masterParameterX, masterParameterZ, masterPositionValueX, masterPositionValueZ;
    public bool playback;

    // Start is called before the first frame update
    void Start()
    {
        SetValues();
    }

    // Update is called once per frame
    void Update()
    {
        //MasterParameterCheck();
    }

    void SetValues()
    {
        gameLogic = gameController.GetComponent<GameLogic>();
        //SetParamSource();
        playback = true;
    }
    /*
    void SetParamSource()
    {
        for(int i = 0; i < paramObjects.Length; i++)
        {
            paramData[i] = paramObjects[i].GetComponent<ParamLogic>();
        }
    }
    */
    void OnMouseDown()
    {
        gameLogic.activeParameter = parameterType;
    }
    
    /*
    void MasterParameterCheck()
    {
        masterParameterX = (((paramData[0].parameterX) + (paramData[1].parameterX) + (paramData[2].parameterX) + (paramData[3].parameterX) + (paramData[4].parameterX) + (paramData[5].parameterX) + (paramData[6].parameterX) + (paramData[7].parameterX)) / 8);
        masterPositionValueX = (((paramData[0].positionValueX) + (paramData[1].positionValueX) + (paramData[2].positionValueX) + (paramData[3].positionValueX) + (paramData[4].positionValueX) + (paramData[5].positionValueX) + (paramData[6].positionValueX) + (paramData[7].positionValueX)) / 8);
        masterParameterZ = (((paramData[0].parameterZ) + (paramData[1].parameterZ) + (paramData[2].parameterZ) + (paramData[3].parameterZ) + (paramData[4].parameterZ) + (paramData[5].parameterZ) + (paramData[6].parameterZ) + (paramData[7].parameterZ)) / 8);
        masterPositionValueZ = (((paramData[0].positionValueZ) + (paramData[1].positionValueZ) + (paramData[2].positionValueZ) + (paramData[3].positionValueZ) + (paramData[4].positionValueZ) + (paramData[5].positionValueZ) + (paramData[6].positionValueZ) + (paramData[7].positionValueZ)) / 8);
    }
    */
}
