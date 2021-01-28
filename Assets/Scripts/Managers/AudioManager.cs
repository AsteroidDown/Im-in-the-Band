using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] startSounds;
	public static Sound[] sounds;
    
    // Start is called before the first frame update
    void Start() {

        sounds = new Sound[startSounds.Length];
        int i = 0;

    	foreach (Sound s in startSounds) {
    		s.source = gameObject.AddComponent<AudioSource>();
    		s.source.clip = s.clip;

    		s.source.volume = s.volume;
    		s.source.pitch = s.pitch;

    		s.source.mute = s.mute;
    		
    		s.source.loop = s.loop;
    		if (s.playOnAwake) 
    			s.source.Play();

            sounds[i] = s;
            i++;
    	}   
    }

    public static Sound FindSound(string name) {
    	Sound s = Array.Find(sounds, sound => sound.name == name);
    	if (s == null)
    		Debug.LogWarning("Sound: " + name + " not found");
    	
    	return s;
    }

    public static void Play(string name) {
    	Sound s = FindSound(name);
    	if (s != null)
    		s.source.Play();
    }

    public static bool Mute(string name) {
    	Sound s = FindSound(name);
    	if (s != null) {
    		s.source.mute = true;
    		return true;
    	} else
    		return false;
    }

    public static bool Unmute(string name) {
    	Sound s = FindSound(name);
    	if (s != null) {
    		s.source.mute = false;
    		return true;
    	} else
    		return false;
    }

    public static void MuteAll() {
        foreach (Sound s in sounds) {
            s.source.mute = true;
        }
    }

    public static void ChangeSound(string name, Sound newSound) {
        Sound s = FindSound(name);
        s.source.clip = newSound.clip;
        s.source.Play();
    }

}
