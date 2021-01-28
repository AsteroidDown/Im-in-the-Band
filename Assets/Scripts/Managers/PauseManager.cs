using UnityEngine;
using UnityEngine.UI;
using Instruments;

public class PauseManager : MonoBehaviour {

    // Canvases
    [Header("Areas")]
    public GameObject backPanel;
    public GameObject pauseMenu;
    public GameObject optioinsMenu;
    public GameObject areYouSure;
    public GameObject HUDCanvas;

    // Instrument Images
    [Header("Instrument Images")]
    public Image kickImage;
    public Image snareImage;
    public Image hihatImage;
    public Image bassImage;
    public Image guitarImage;
    public Image keysImage;

    private static Image kick;
    private static Image snare;
    private static Image hihat;
    private static Image bass;
    private static Image guitar;
    private static Image keys;

    // Stat sliders
    [Header("Stat Sliders")]
    public Slider speedSlider;
    public Slider jumphSlider;
    public Slider attackSlider;
    public Slider healthSlider;

    private static Slider speed;
    private static Slider jumph;
    private static Slider attack;
    private static Slider health;


    //public static PauseManager Instance;

    void Start() {
        // Get Images
        kick = kickImage;
        snare = snareImage;
        hihat = hihatImage;
        bass = bassImage;
        guitar = guitarImage;
        keys = keysImage;

        // Set sliders
        speed = speedSlider;
        jumph = jumphSlider;
        attack = attackSlider;
        health = healthSlider;
    }

    void Update() {
    	if (Input.GetKeyDown(KeyCode.Escape)) {
    		if (StateManager.GetPaused()) {
                Resume(); 
            } else {
                Pause();
            }
    	}
    }

    // ------------------------------ Navigation functions ------------------------------ //
    // Pause the game
    public void Pause() {
        backPanel.SetActive(true);
    	pauseMenu.SetActive(true);
        HUDCanvas.SetActive(false);
        StateManager.SetPaused(true);
    	Time.timeScale = 0f;
    }

    // Resume the game
    public void Resume() {
        backPanel.SetActive(false);
		pauseMenu.SetActive(false);
        HUDCanvas.SetActive(true);
        StateManager.SetPaused(false);
    	Time.timeScale = 1f;
    }

    // Open the options menu
    public void OptionsOpen() {
        optioinsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    // Close the options menu
    public void OptionsClose() {
        optioinsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        PrefsManager.UpdatePrefs();
    }

    // Open AreYouSure and set level load to main menu
    public void QuitToMain() {
        areYouSure.SetActive(true);
        LoadingManager.SetLevelToLoad("Title");
    }

    // Open AreYouSure and set level load to LevelSelect
    public void LevelSelect() {
        areYouSure.SetActive(true);
        LoadingManager.SetLevelToLoad("ElectricAve");
    }

    // Close AreYouSure panel
    public void NotSoSure() {
        areYouSure.SetActive(false);
    }

    // Close AreYouSure in the case of a new level being loaded
    public void SoSure() {
        areYouSure.SetActive(false);
        Resume();
    }

    // ------------------------------ Player Stuff Updates ------------------------------ //
    // Update the stat bars
    public static void UpdateStatBars() {
        speed.value = StatsManager.GetSpeed();
        jumph.value = StatsManager.GetJumpH();
        attack.value = StatsManager.GetAttack();
        health.value = StatsManager.GetHealth();
    }

    // Instrument Image Switching
    public static void SpriteSwitch(GameObject other, Type instrument) {
    	Sprite otherSprite = other.GetComponent<SpriteRenderer>().sprite;

    	switch (instrument) {
            case Type.kick:
                kick.sprite = otherSprite;
                break;
            case Type.snare:
                snare.sprite = otherSprite;
                break;
            case Type.hihat:
                hihat.sprite = otherSprite;
                break;
            case Type.bass:
                bass.sprite = otherSprite;
                break;
            case Type.guitar:
                guitar.sprite = otherSprite;
                break;
            case Type.keys:
                keys.sprite = otherSprite;
                break;
        }
    }
}
