using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotate : MonoBehaviour
{
    public GameObject parentObject, gameController;
    PlayStop playStop;
    GameLogic gameLogic;
    int rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playStop = parentObject.GetComponent<PlayStop>();
        gameLogic = gameController.GetComponent<GameLogic>();
        rotateSpeed = 150;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (playStop.playbackType == gameLogic.playbackState)
        {
            transform.Rotate(rotateSpeed * Vector3.back * Time.deltaTime);
        }
    }
}
