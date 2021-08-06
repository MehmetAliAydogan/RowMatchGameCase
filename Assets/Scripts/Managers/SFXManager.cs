using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
	public AudioSource[] sfx;

    void Start () {
		instance = GetComponent<SFXManager>();
		sfx = GetComponents<AudioSource>();
    }

    public void PlaySFX(SoundClip audioClip) {
		sfx[(int)audioClip].Play();
	}
}
