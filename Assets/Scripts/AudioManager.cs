﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // references this script possibly, not 100% sure about instances
    public static AudioManager instance;

    // number of audiotracks there are
    public int numberOfAudioTracks = 30;

    // array of all the "tracks" and audiosources
    public AudioSource[] tracks;

    // int responsible for keeping track of what specific track in the array we are playing on
    public int currentTrackNumber;


    public void Awake()
    {
        tracks = new AudioSource[numberOfAudioTracks]; //intializes the array of AudioSources
        currentTrackNumber = 0; //number used for navigating the tracks array


        //create an empty game object for every audiotrack
        //parent it to the Audio gameobject
        //add an audiosource
        //Assign that audiosource to the i'th element of the tracks array
        for (int i = 0; i < numberOfAudioTracks; i++)
        {
            var GO = new GameObject("Track" + (i + 1));
            GO.transform.parent = this.gameObject.transform;
            var AS = GO.AddComponent<AudioSource>();
            tracks[i] = AS;
        }


        instance = this;

        /* GameObject soundTrack = new GameObject("SoundTrack");
         var soundTrackAudioSource = soundTrack.AddComponent<AudioSource>();
         soundTrackAudioSource.clip = Resources.Load<AudioClip>("Sounds/Phase3Soundtrack");
         soundTrackAudioSource.loop = true;
         soundTrackAudioSource.volume = 0.2f;
         soundTrackAudioSource.Play(); */
    }
    //i.e.   var knifeThrow = Resources.Load<AudioClip>("Sounds/KnifeThrow");
    //       AudioManager.instance.PlaySound(knifeThrow);
    public void PlaySound(AudioClip clip, float volume = 1)
    {
        tracks[currentTrackNumber].volume = volume;
        tracks[currentTrackNumber].PlayOneShot(clip);
        currentTrackNumber = (currentTrackNumber + 1) % numberOfAudioTracks;

    }
}