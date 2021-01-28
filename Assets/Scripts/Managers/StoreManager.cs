using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour {

	// ---------- Editor Stuff ---------- //
	[Header("Animators")]
	public Animator selectionAnim;
	public Animator itemsAnim;

	[Header("UI")]
	public GameObject[] itemContainers;
	public Image[] itemImages;
	public TMP_Text[] itemNames;

	[Header("Items")]
	public BuyableItem[] section1;
	public BuyableItem[] section2;
	public BuyableItem[] section3;


	// ---------- Manager Stuff ---------- //
	private BuyableItem[] items;


	// ---------- Show/Hide Items from Section ---------- //
    public void ViewItems() {
    	// Set UI elements to match items
    	for (int i = 0; i < items.Length; i++) {
    		itemContainers[i].SetActive(true);
    		itemImages[i].sprite = items[i].image;
    		itemNames[i].SetText(items[i].itemName);
    	}

    	// Disable unused containers
    	if (items.Length < itemContainers.Length) {
    		for (int i = items.Length; i < itemContainers.Length; i++) {
    			itemContainers[i].SetActive(false);
    		}
    	}

    	// Animate sections away and items in
    	selectionAnim.SetBool("ViewItems", true);
    	itemsAnim.SetBool("ViewItems", true);
    }

    public void HideItems() {
    	selectionAnim.SetBool("ViewItems", false);
    	itemsAnim.SetBool("ViewItems", false);
    }

    // ---------- Set Up Items Menu ---------- //
    public void SetSection(int section) {
    	switch (section) {
    		case 1:
    			items = section1;
    			break;
    		case 2:
    			items = section2;
    			break;
    		case 3:
    			items = section3;
    			break;
    	} 
    }
    
}
