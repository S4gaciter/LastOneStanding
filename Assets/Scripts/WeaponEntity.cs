using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEntity : MonoBehaviour
{
    public int cost;
    public GameObject weapon;

    private WeaponHandler handler;
    private void Start()
    {
        handler = GameObject.Find("WeaponHandle").GetComponent<WeaponHandler>();
    }

    public string GetWeaponName()
    {
        return weapon.GetComponent<Gun>().stats.gunName;
    }

    public void BuyWeapon()
    {
        handler.ChangeWeapon(weapon);
    }
}
