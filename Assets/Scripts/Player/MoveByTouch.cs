using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveByTouch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	
	PlayerController player;

	public Image arrow;
	public Sprite arrowChange;
	public GameObject dpadDirection;
	public bool movingRight;

	private Sprite arrowNotPressed;

	void Start() {
		arrowNotPressed = arrow.sprite;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		Move();
		//Debug.Log("Movement Button Pressed");
    }
    
    public void OnPointerExit(PointerEventData eventData) {
    	Stop();
		//Debug.Log("Movement Button Released");
    }

	public void Move() {
		if (!player) player = FindObjectOfType<PlayerController>();
		if (movingRight) 
			player.externalMove = 1f;
		else 
			player.externalMove = -1f;

		// Change the sprites
		arrow.sprite = arrowChange;
		dpadDirection.SetActive(true);
	}

	public void Stop() {
		player.externalMove = 0f;
		arrow.sprite = arrowNotPressed;
		dpadDirection.SetActive(false);
	}
}
