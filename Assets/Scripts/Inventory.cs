using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum WeaponType
    {
        Pistol,
        SMG,
        AssaultRifle,
        Shotgun,
        SniperRifle
    }

    public static Inventory Instance;

    public List<GameObject> weapons;
    int currentWeapon = 0;

    [SerializeField] private GameObject primary = null;
    [SerializeField] private GameObject secondary = null;
    
    // Initialization
    void Start()
    {
        SetPrimary(WeaponType.Pistol);
        SetSecondary(WeaponType.SMG);
        HideAllWeapons();
        primary.SetActive(true);
        primary.GetComponent<Gun>().UpdateGunUI();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.mouseScrollDelta.y > 0.1f || Input.mouseScrollDelta.y < -0.1f) && secondary != null)
        {
            SwapWeapon();
        }
    }

    void SwapWeapon()
    {
        switch(currentWeapon)
        {
            case 0:
                primary.SetActive(false);
                secondary.SetActive(true);
                currentWeapon = 1;
                break;
            case 1:
                primary.SetActive(true);
                secondary.SetActive(false);
                currentWeapon = 0;
                break;
        }
    }

    public void ExchangeWeapon(WeaponType weapon)
    {
        if (secondary != null)
        {
            switch (currentWeapon)
            {
                case 0:
                    SetPrimary(weapon);
                    break;
                case 1:
                    SetSecondary(weapon);
                    break;
            }
        }
        else
        {
            SetSecondary(weapon);
        }
    }

    void SetPrimary(WeaponType weapon)
    {
        secondary.SetActive(false);
        primary.SetActive(false);
        switch(weapon)
        {
            case WeaponType.Pistol:
                primary = GetPistol();
                break;
            case WeaponType.SMG:
                primary = GetSMG();
                break;
            case WeaponType.AssaultRifle:
                primary = GetAssaultRifle();
                break;
            case WeaponType.Shotgun:
                primary = GetShotgun();
                break;
            case WeaponType.SniperRifle:
                primary = GetSniperRifle();
                break;
        }
        primary.SetActive(true);
    }

    void SetSecondary(WeaponType weapon)
    {
        primary.SetActive(false);
        secondary.SetActive(false);
        switch (weapon)
        {
            case WeaponType.Pistol:
                secondary = GetPistol();
                break;
            case WeaponType.SMG:
                secondary = GetSMG();
                break;
            case WeaponType.AssaultRifle:
                secondary = GetAssaultRifle();
                break;
            case WeaponType.Shotgun:
                secondary = GetShotgun();
                break;
            case WeaponType.SniperRifle:
                secondary = GetSniperRifle();
                break;
        }
        secondary.SetActive(true);
    }

    GameObject GetPistol()
    {
        return weapons[0];
    }
    GameObject GetSMG()
    {
        return weapons[1];
    }
    GameObject GetAssaultRifle()
    {
        return weapons[2];
    }
    GameObject GetShotgun()
    {
        return weapons[3];
    }
    GameObject GetSniperRifle()
    {
        return weapons[4];
    }

    void HideAllWeapons()
    {
        for(int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }
    }
}
