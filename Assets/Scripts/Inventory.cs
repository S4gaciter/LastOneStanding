using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory;
    public GameObject startingWeapon;
    int currentWeapon = 0;

    // Initialization
    void Awake()
    {
        inventory.Capacity = 2;
        AddToInventory(startingWeapon);
    }
    private void Start()
    {
        inventory[currentWeapon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0.1f && inventory.Count > 1)
        {
            NextWeapon();
        }
        else if (Input.mouseScrollDelta.y < - 0.1f && inventory.Count > 1)
        {
            PreviousWeapon();
        }
    }

    void NextWeapon()
    {
        inventory[currentWeapon].SetActive(false);
        currentWeapon++;
        if (currentWeapon >= inventory.Count)
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
            currentWeapon = inventory.Count - 1;
        }
        inventory[currentWeapon].SetActive(true);
        inventory[currentWeapon].GetComponent<Gun>().UpdateGunUI();
    }

    public void AddToInventory(GameObject weapon)
    {
        inventory[currentWeapon].SetActive(false);
        if (inventory.Count < inventory.Capacity)
        {
            inventory.Add(weapon);
        }
        else
        {
            inventory[currentWeapon] = weapon;
        }
        Instantiate(weapon, transform);
    }

    public void RemoveFromInventory()
    {
        inventory.RemoveAt(currentWeapon);
        Destroy(transform.GetChild(currentWeapon).gameObject);
    }

    public bool HasWeapon(GameObject weapon)
    {
        return inventory.Contains(weapon);
    }
}
