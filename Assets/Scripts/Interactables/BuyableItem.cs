using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Buyable Item", menuName = "Buyable Item")]
public class BuyableItem : ScriptableObject {
    
	public Sprite image;

    public string itemName;
    public int cost;
    public string description;

    public int speed;
    public int jump;
    public int health;
    public int attack;

    // public void Print() {
    // 	Debug.Log(itemName + ": " + description);
    // }
}
