using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEntity : MonoBehaviour
{
    public int cost;
    public GameObject weapon;

    private Inventory inventory;
    private void Start()
    {
        inventory = GameObject.Find("WeaponHandle").GetComponent<Inventory>();
    }

    public string GetWeaponName()
    {
        return weapon.GetComponent<Gun>().stats.gunName;
    }

    public void BuyWeapon()
    {
        inventory.SwapWeapon(weapon);
    }
}
