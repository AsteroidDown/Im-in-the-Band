using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {
	[Header("Timers")]
    public  float light1Count;
    private float light1Timer;
    public  float light2Count;
    private float light2Timer;


    void Update() {
    	if (Input.GetKeyDown(KeyCode.L)) {

    		if (light2Timer > 0) {
    			print(Time.time + "\tLLL");
    		}
    		else if (light1Timer > 0) {
    			light2Timer = light2Count;
				print(Time.time + "\tLL");
    		}
    		else if (light1Timer < 0) {
    			light1Timer = light1Count;
    			print(Time.time + "\tL");
    		}
    	}

    	light1Timer -= Time.deltaTime;
    	light2Timer -= Time.deltaTime;
    }
}
