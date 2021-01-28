using UnityEngine;

public class InstrumentObject : MonoBehaviour {

	// Get the instrument for this object
	public Instrument instrument;

    void OnTriggerEnter2D(Collider2D other) {
    	if (other.tag == "Player") {

            // Change stat values
            StatsManager.PickupUpdateStats(instrument);

            // Change player stats
            PlayerController.StatChange();

            // Switch instrument sound
    		BandManager.InstrumentSwitch(instrument.audioName, instrument.type);

            // Switch puase instrument icon
            PauseManager.SpriteSwitch(this.gameObject, instrument.type);

            // Update pause menu stat bars
            PauseManager.UpdateStatBars();
    	}
    }
}
