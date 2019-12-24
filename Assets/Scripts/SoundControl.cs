using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public FMOD.Studio.EventInstance Melody, Counterpoint, Harmony, Bass, PercussionOne, PercussionTwo, AmbienceOne, AmbienceTwo, AmbienceThree, AmbienceFour;
    public Camera gameCamera;
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        SetValues();
        StartPlayback();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetValues()
    {
        //Music Events
        Melody = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Melody");
        Counterpoint = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Counterpoint");
        Harmony = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Harmony");
        Bass = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Bass");
        PercussionOne = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Percussion 1");
        PercussionTwo = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Percussion 2");

        //Ambient Loop Events
        AmbienceOne = FMODUnity.RuntimeManager.CreateInstance("event:/Ambient Loops/Traffic");
        AmbienceTwo = FMODUnity.RuntimeManager.CreateInstance("event:/Ambient Loops/Voiceover");
        AmbienceThree = FMODUnity.RuntimeManager.CreateInstance("event:/Ambient Loops/DroidEmotes");
        AmbienceFour = FMODUnity.RuntimeManager.CreateInstance("event:/Ambient Loops/Combat");

        FMODUnity.RuntimeManager.AttachInstanceToGameObject(AmbienceOne, gameObject.transform, rigidBody);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(AmbienceTwo, gameObject.transform, rigidBody);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(AmbienceThree, gameObject.transform, rigidBody);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(AmbienceFour, gameObject.transform, rigidBody);

    }

    void StartPlayback()
    {
        //Music Start
        Melody.start();
        Counterpoint.start();
        Harmony.start();
        Bass.start();
        PercussionOne.start();
        PercussionTwo.start();

        //Ambient Loop Start
        AmbienceOne.start();
        AmbienceTwo.start();
        AmbienceThree.start();
        AmbienceFour.start();
    }

    void StopPlayback()
    {
        //Music Stop
        Melody.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Counterpoint.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Harmony.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Bass.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        PercussionOne.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        PercussionTwo.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        //Ambient Lopp Stop
        AmbienceFour.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        AmbienceTwo.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        AmbienceThree.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        AmbienceFour.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
