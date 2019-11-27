using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStop : MonoBehaviour
{
    public GameObject ring, gameController;
    GameLogic gameLogic;
    public float rotateSpeed;
    public string playbackType;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = gameController.GetComponent<GameLogic>();
        rotateSpeed = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        gameLogic.playbackState = playbackType;
    }
}
