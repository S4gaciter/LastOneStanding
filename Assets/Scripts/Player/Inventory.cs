using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<GameObject> weapons;
    int currentWeapon = 0;
    
    // Initialization
    void Start()
    {
        HideAllWeapons();
        weapons[0].SetActive(true);
        weapons[0].GetComponent<Gun>().UpdateGunUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0.1f && !weapons[currentWeapon].GetComponent<Gun>().IsReloading())
        {
            NextWeapon();
        }
        else if(Input.mouseScrollDelta.y < -0.1f && !weapons[currentWeapon].GetComponent<Gun>().IsReloading())
        {
            PrevWeapon();
        }
    }

    void NextWeapon()
    {
        weapons[currentWeapon].SetActive(false);
        currentWeapon++;
        if (currentWeapon == weapons.Count)
        {
            currentWeapon = 0;
        }
        weapons[currentWeapon].SetActive(true);
        weapons[currentWeapon].GetComponent<Gun>().UpdateGunUI();
    }

    void PrevWeapon()
    {
        weapons[currentWeapon].SetActive(false);
        currentWeapon--;
        if (currentWeapon < 0)
        {
            currentWeapon = weapons.Count - 1;
        }
        weapons[currentWeapon].SetActive(true);
        weapons[currentWeapon].GetComponent<Gun>().UpdateGunUI();
    }

    void HideAllWeapons()
    {
        for(int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(false);
        }
    }
}
