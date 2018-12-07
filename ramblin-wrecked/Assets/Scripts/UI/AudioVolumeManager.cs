using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVolumeManager : MonoBehaviour {

    AudioSource audioSource;
    public float perc = 1.0f;
    public bool bg = false;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.volume = perc * (bg ? OptionsManager.bgVolume : OptionsManager.sfxVolume);
	}
}
