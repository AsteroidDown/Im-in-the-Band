using UnityEngine;
using Instruments;

namespace Instruments {
    public enum Type {
        kick,
        snare,
        hihat,
        bass,
        guitar,
        keys,
        empty
    }

    public enum Colour {
        red,
        blue,
        green,
        empty
    }
}

//[CreateAssetMenu(fileName = "New Instrument", menuName = "Instrument")]
public class Instrument : ScriptableObject {

    public Type type;
    public Colour colour;
	public string audioName;

    public Instrument() {
        type = Type.empty;
        colour = Colour.empty;
        audioName = "";
    }

    public Instrument(Instrument inst) {
        type = inst.type;
        colour = inst.colour;
        audioName = inst.audioName;
    }

    public Instrument(Type t, Colour c, string a) {
        type = t;
        colour = c;
        audioName = a;
    }

    public bool Equals(Instrument inst) {
        if (type == inst.type && colour == inst.colour && audioName == inst.audioName) return true;
        else return false;
    }

    public void Set(Instrument inst) {
        type = inst.type;
        colour = inst.colour;
        audioName = inst.audioName;
    }

    public void SetEmpty() {
        type = Type.empty;
        colour = Colour.empty;
        audioName = "";
    }
}
