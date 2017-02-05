using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public new AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	public void SoundOnOff()
    {
        if(audio.mute)
        {
            audio.mute = false;
        } else
        {
            audio.mute = true;
        }
    }
}
