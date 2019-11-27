using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSlider : MonoBehaviour
{
    public GameObject[] parameterObjects = new GameObject[8];
    //public Slider
    Vector3[] currentPositions = new Vector3[8];
    Vector3 highTarget, lowTarget;
    static int sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetValues()
    {
        highTarget = new Vector3(63, 05, 31);
        lowTarget = new Vector3(-31, 05, -31);
    }

    void PositionCheck()
    {
        for (int i = 0; i < parameterObjects.Length; i++)
        {
            currentPositions[i] = new Vector3((parameterObjects[i].transform.position.x), 05, (parameterObjects[i].transform.position.z));
        }
    }

    IEnumerator MasterDragMotion(Vector3 startPosition, Vector3 targetPosition, float travelTime)
    {
        float targetDistance = 1.0f;
        float travelRate = 1.0f;

        while(targetDistance > 0)
        {
            targetDistance -= Time.deltaTime * travelRate;

            for (int i = 0; i < parameterObjects.Length; i++)
            {
                parameterObjects[i].transform.position = Vector3.Lerp(startPosition, targetPosition, targetDistance);
            }
            yield return null;
        }
    }
}
