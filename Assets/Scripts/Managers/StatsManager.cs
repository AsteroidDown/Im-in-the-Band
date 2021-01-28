using UnityEngine;
using Instruments;

public class StatsManager : MonoBehaviour {

	// Stat types storage floats
	public static float speed  = 0f;
	public static float jumph  = 0f;
	public static float attack = 0f;
	public static float health = 0f;

	public static float maxSpeed  = 10f;
	public static float maxJumph  = 10f;
	public static float maxAttack = 10f;
	public static float maxHealth = 10f;

	// Instruments for storage
	private static Colour kick 	 = Colour.empty;
	private static Colour snare  = Colour.empty;
	private static Colour hihat  = Colour.empty;
	private static Colour bass 	 = Colour.empty;
	private static Colour guitar = Colour.empty;
	private static Colour keys 	 = Colour.empty;


	// ------------------------------ GET / SET ------------------------------ //
	public static void SetSpeed(float newSpeed) => speed = newSpeed;

	public static void SetJumpH(float newJumpH) => jumph = newJumpH;

	public static void SetAttack(float newAttack) => attack = newAttack;

	public static void SetHealth(float newHealth) => health = newHealth;

	public static float GetSpeed() => speed;

	public static float GetJumpH() => jumph;

	public static float GetAttack() => attack;

	public static float GetHealth() => health;


	// ------------------------------ INCREMENTS ------------------------------ //
	public static void IncrementSpeed(float incr) => speed += incr;

	public static void IncrementJumpH(float incr) => jumph += incr;

	public static void IncrementAttack(float incr) => attack += incr;

	public static void IncrementHealth(float incr) => health += incr;


	// ------------------------------ UPDATING ------------------------------ //
	public static void PickupUpdateStats(Instrument inst) {
		Colour oldColour = Colour.empty;

		// Find old instrument effecting stats
		switch (inst.type) {
			case Type.kick:
				if (kick != Colour.empty) oldColour = kick;
				kick = inst.colour;
				break;
			case Type.snare:
				if (snare != Colour.empty) oldColour = snare;
				snare = inst.colour;
				break;
			case Type.hihat:
				if (hihat != Colour.empty) oldColour = hihat;
				hihat = inst.colour;
				break;
			case Type.bass:
				if (bass != Colour.empty) oldColour = bass;
				bass = inst.colour;
				break;
			case Type.guitar:
				if (guitar != Colour.empty) oldColour = guitar;
				guitar = inst.colour;
				break;
			case Type.keys:
				if (keys != Colour.empty) oldColour = keys;
				keys = inst.colour;
				break;
		}

		// Decrease the stats off of the old instrument leaving
		if (oldColour != Colour.empty) {

			// Quick exit if old and new instrument are the same
			if (oldColour == inst.colour) return;

			// Check for drums for movement decreasing
			if ((inst.type == Type.kick) || (inst.type == Type.snare) || (inst.type == Type.hihat)) {

				if (oldColour == Colour.red) IncrementSpeed(-2f);
				else if (oldColour == Colour.green) IncrementJumpH(-2f);
				else {IncrementSpeed(-1f);	IncrementJumpH(-1f);}

			// Rythym instruments for attack and health decreasing
			} else {

				if (oldColour == Colour.red) IncrementHealth(-2f);
				else if (oldColour == Colour.green) IncrementAttack(-2f);
				else {IncrementHealth(-1f);	IncrementAttack(-1f);}
			}
		}

		// Increase the stats based on the new instrument
		// Check for drums for movement increasing
		if ((inst.type == Type.kick) || (inst.type == Type.snare) || (inst.type == Type.hihat)) {

			if (inst.colour == Colour.red) IncrementSpeed(2f);
			else if (inst.colour == Colour.green) IncrementJumpH(2f);
			else {IncrementSpeed(1f);	IncrementJumpH(1f);}

			// Make sure values don't pass their max
			Mathf.Clamp(speed, 0f, maxSpeed);
			Mathf.Clamp(jumph, 0f, maxJumph);

		// Rythym instruments for attack and health increasing
		} else {

			if (inst.colour == Colour.red) IncrementHealth(2f);
			else if (inst.colour == Colour.green) IncrementAttack(2f);
			else {IncrementHealth(1f);	IncrementAttack(1f);}

			// Make sure values don't pass their max
			Mathf.Clamp(attack, 0f, maxAttack);
			Mathf.Clamp(health, 0f, maxHealth);
		}

		//Debug.Log(System.DateTime.Now + " " + oldColour + " " + inst.colour + " " + speed + " " + jumph);
	}
}
