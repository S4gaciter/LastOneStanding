using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory;
    int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        inventory[currentWeapon].SetActive(true);
        for (int i = 0; i < inventory.Length; i++)
        {
            if (i == currentWeapon)
                inventory[i].SetActive(true);
            else if (inventory[i] != null)
                inventory[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0.1f)
        {
            NextWeapon();
        }
        else if (Input.mouseScrollDelta.y < - 0.1f)
        {
            PreviousWeapon();
        }
    }

    void NextWeapon()
    {
        inventory[currentWeapon].SetActive(false);
        currentWeapon++;
        if (currentWeapon >= inventory.Length)
        {
            currentWeapon = 0;
        }
        inventory[currentWeapon].SetActive(true);
        inventory[currentWeapon].GetComponent<Gun>().UpdateGunUI();
    }

    void PreviousWeapon()
    {
        inventory[currentWeapon].SetActive(false);
        currentWeapon--;
        if (currentWeapon < 0)
        {
            currentWeapon = inventory.Length - 1;
        }
        inventory[currentWeapon].SetActive(true);
        inventory[currentWeapon].GetComponent<Gun>().UpdateGunUI();
    }

    public void SwapWeapon(GameObject weapon)
    {
        // Check to see if the weapon is already in the player's inventory
        bool shouldSwap = true;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == weapon)
            {
                shouldSwap = false;
            }
        }

        if (shouldSwap)
        {
            inventory[currentWeapon].SetActive(false);
            RemoveFromInventory();
            inventory[currentWeapon] = weapon;
            AddToInventory(weapon);
            inventory[currentWeapon].SetActive(true);
        }
    }

    void AddToInventory(GameObject weapon)
    {
        Instantiate(weapon, transform);
    }

    void RemoveFromInventory()
    {
        Destroy(transform.GetChild(currentWeapon).gameObject);
    }
}
