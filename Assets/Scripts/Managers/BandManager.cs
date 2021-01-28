using UnityEngine;
using Instruments;

public class BandManager : MonoBehaviour {
    
    private static string kick;
    private static string snare;
    private static string hihat;
    private static string bass;
    private static string guitar;
    private static string keys;

    public static void InstrumentSwitch(string newClip, Type instrument) {
    	string oldClip = null;

        // Get oldClip
        switch (instrument) {
            case Type.kick:
                oldClip = kick;
                break;
            case Type.snare:
                oldClip = snare;
                break;
            case Type.hihat:
                oldClip = hihat;
                break;
            case Type.bass:
                oldClip = bass;
                break;
            case Type.guitar:
                oldClip = guitar;
                break;
            case Type.keys:
                oldClip = keys;
                break;
        }

        // No change
        if (oldClip == newClip)
            return;
        
        else {
            // No instrument currently set
            if (oldClip == null) {
                AudioManager.Unmute(newClip);

            // There is an instrument set, mute it and unmute the new one
            } else if (AudioManager.Unmute(newClip)) {
                AudioManager.Mute(oldClip);
            }
            
            // Switch instrument sound
            switch (instrument) {
                case Type.kick:
                    kick = newClip;
                    break;
                case Type.snare:
                    snare = newClip;
                    break;
                case Type.hihat:
                    hihat = newClip;
                    break;
                case Type.bass:
                    bass = newClip;
                    break;
                case Type.guitar:
                    guitar = newClip;
                    break;
                case Type.keys:
                    keys = newClip;
                    break;
            }
        }
    }
}
