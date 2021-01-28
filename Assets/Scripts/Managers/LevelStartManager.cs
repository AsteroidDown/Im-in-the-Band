using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartManager : MonoBehaviour {

	public Sound[] sounds; 

	void Awake() {
		foreach (Sound s in sounds) {
			AudioManager.ChangeSound(s.name, s);
			//Debug.Log("Changed " + s.name);
		}
	}
    
}
