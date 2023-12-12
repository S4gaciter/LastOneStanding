using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEntity : MonoBehaviour
{
    public int cost;
    public string gunName;
    public Inventory.WeaponType weapon;

    private void Awake()
    {

    }

    public string GetWeaponName()
    {
        return gunName;
    }

    public void BuyWeapon()
    {
        Inventory.Instance.ExchangeWeapon(weapon);
    }
}
