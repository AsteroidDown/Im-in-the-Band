using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

	[Header("Canvases")]
	public GameObject titleCanvas;
	public GameObject optionsCanvas;

	[Header("Options")]
	public Slider masterVolume;
    public Slider cameraOffset;
    public Toggle DPADToggle;

	void Start() {
		masterVolume.value = PrefsManager.masterVolume;
		cameraOffset.value = PrefsManager.cameraOffset;
		DPADToggle.isOn = PrefsManager.DPADToggle;
	}
    
    // ------------------------------ SWITCHING ------------------------------ //
    public void StartGame() {
        titleCanvas.SetActive(false);
        LoadingManager.SetLevelToLoad("ElectricAve");
        LoadingManager.SetLevelLoading(true);
    }

    public void OptionsOpen() {
    	titleCanvas.SetActive(false);
    	optionsCanvas.SetActive(true);
    }

    public void OptionsClose() {
    	titleCanvas.SetActive(true);
    	optionsCanvas.SetActive(false);
    	PrefsManager.UpdatePrefs();
    }

    public void Store() {
        titleCanvas.SetActive(false);
        LoadingManager.SetLevelToLoad("Store");
        LoadingManager.SetLevelLoading(true);
    }

    // ------------------------------ PREFS ------------------------------ //
    public void MasterVolumeChange(float newVolume) {
        AudioListener.volume = newVolume;
        PrefsManager.SetMasterVolume(newVolume);
    }

    public void CameraOffset(float offset) {
    	PrefsManager.SetCameraOffset(offset);
    }

    public void DPADHide(bool hidden) {
        PrefsManager.SetDPADToggle(hidden);
    }
}
