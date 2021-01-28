using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float xOffset = 0;
	public float yOffset;
	public float yStartHeight;
	private float xPos;
	private float yPos;
	private float xOld;
	private float yMid;
	private float xlerpTime;
	private float ylerpTime;
	private float camMoveSpeed = 0.005f;

	private bool xlerp = false;
	private bool ylerp = false;

	private PlayerController player;
	private PauseManager pauseMenu;

	// Use this for initialization
	void Start () {

		player = FindObjectOfType<PlayerController>();
		pauseMenu = FindObjectOfType<PauseManager>();

		xOffset = PrefsManager.cameraOffset;

		transform.position = new Vector3(
			player.transform.position.x + xOffset, 
			yStartHeight, 
			transform.position.z);

		xOld = xOffset;
		yMid = yStartHeight;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		// Check if game is paused
		if (!StateManager.GetPaused()) {
			// ------------------------------ HORIZONTAL MOVEMENT ------------------------------ //

			// Get horizontal offset;
			xOffset = PrefsManager.cameraOffset;

			// Check if camera is offset horizontally
			if (Mathf.Abs(xOffset) > 0) {

				// Camera directional changes
				if (player.transform.localScale.x == 1)
					xOffset = Mathf.Abs(xOffset);
				else
					xOffset = -Mathf.Abs(xOffset);

				// Check if camera switched sides of player
				if (xOld != xOffset || xlerpTime != 0) {
					xlerp = true;
				}

				// Move camera smoothly when changing directions
				if (xlerp) {

					// Check if side switched while lerping
					if (xOld != xOffset)
						xlerpTime = 0;

					// Update lerp extrapolation point
					xlerpTime += camMoveSpeed;
					xPos = Mathf.Lerp(transform.position.x, player.transform.position.x + xOffset, xlerpTime);

					// Stop lerping reset
					if (xlerpTime >= 0.5f) {
						xlerpTime = 0;
						xlerp = false;
						xPos = player.transform.position.x + xOffset;
					}

				// Camera on the same side still
				} else {
					xPos = player.transform.position.x + xOffset;
				}

			// No horizontal offset
			} else {
				xPos = player.transform.position.x;
			}


			// ------------------------------ VERTICAL MOVEMENT ------------------------------ //
			// Check if camera is offset vertically
			if (Mathf.Abs(yOffset) > 0) {

				// Check player moved above or below vertical threshold
				if (yMid + yOffset < player.transform.position.y) {
					yMid += 2 * yOffset;
					ylerp = true;
				} else if (yMid - yOffset > player.transform.position.y) {
					yMid -= 2 * yOffset;
					ylerp = true;
				} else if (ylerpTime != 0) {
					ylerp = true;
				}

				// Move camera smoothly when changing directions
				if (ylerp) {

					// Check if side switched while lerping
					if (yMid + yOffset < player.transform.position.y || yMid - yOffset > player.transform.position.y)
						ylerpTime = 0;

					// Update lerp extrapolation point
					ylerpTime += camMoveSpeed;
					yPos = Mathf.Lerp(transform.position.y, yMid, ylerpTime);

					// Stop lerping reset
					if (ylerpTime >= 0.5f) {
						ylerpTime = 0;
						ylerp = false;
						yPos = yMid;
					}

				// Camera on the same side still
				} else {
					yPos = yMid;
				}
			}

			// ------------------------------ END UPDATES ------------------------------ //
			transform.position = new Vector3(xPos, yPos, transform.position.z);
			xOld = xOffset;
		}
	}
}
