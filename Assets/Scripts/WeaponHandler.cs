using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    public GameObject currentWeapon;

    public void Start()
    {
        Instantiate(currentWeapon, transform);
    }

    public void ChangeWeapon(GameObject weapon)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        currentWeapon = weapon;
        Instantiate(currentWeapon, transform);
    }
}
