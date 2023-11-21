using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "ScriptableObjects/ShopItem")]
public class ShopItem : ScriptableObject
{
    public int cost;
    public Sprite icon;
}
