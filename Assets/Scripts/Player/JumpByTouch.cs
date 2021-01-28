using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class JumpByTouch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    PlayerController player;

	public Image arrow;
	public Sprite arrowChange;
	public GameObject dpadDirection;

	private Sprite arrowNotPressed;

	void Start() {
		arrowNotPressed = arrow.sprite;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		JumpPressed();
		//Debug.Log("Jump Button Pressed");
    }
    
    public void OnPointerExit(PointerEventData eventData) {
    	JumpReleased();
		//Debug.Log("Jump Button Released");
    }

    public void JumpPressed() {
        if (!player) player = FindObjectOfType<PlayerController>();
    	player.jumpButton = true;
    	dpadDirection.SetActive(true);
    	arrow.sprite = arrowChange;
    }

    public void JumpReleased() {
    	player.jumpButton = false;
    	dpadDirection.SetActive(false);
    	arrow.sprite = arrowNotPressed;
    }
}
