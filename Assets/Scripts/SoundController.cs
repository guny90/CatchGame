using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    public AudioSource meow, woof;

	// Use this for initialization
	void Start () {
        //meow = GetComponent<AudioSource>();
         
	}
	
	public void SoundOnOff()
    {
        if(meow.mute)
        {
            meow.mute = false;
            woof.mute = false;
        } else
        {
            meow.mute = true;
            woof.mute = true;
        }
    }
}
