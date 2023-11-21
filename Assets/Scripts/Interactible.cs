using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    public string interactionText;
    [SerializeField] private InteractionType interactType;
    
    CreditsManager credits;
    UIManager uiManager;

    public void Start()
    {
        credits = GameObject.Find("Player").GetComponent<CreditsManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    public void ReceiveInteraction()
    {
        switch (interactType)
        {
            // Add Interaction Functions Here
            case InteractionType.Test:
                Debug.Log("Interacted with " + gameObject.name);
                break;
            case InteractionType.Door:
                Destroy(gameObject);
                break;
            case InteractionType.Weapon:
                {
                    Inventory inventory = GameObject.Find("WeaponHandle").GetComponent<Inventory>();
                    WeaponEntity buyable = gameObject.GetComponent<WeaponEntity>();
                    if (credits.GetCurrentCredits() >= buyable.cost && !inventory.HasWeapon(buyable.weapon))
                    {
                        credits.RemoveCredits(buyable.cost);
                        inventory.SwapWeapon(buyable.weapon);
                    }
                }
                break;
            case InteractionType.Shop:
                {
                    uiManager.TogglePlayerUI();
                    uiManager.ToggleShopUI();
                }
                break;
        }
    }

    public enum InteractionType
    {
        Test,
        Weapon,
        Door,
        Shop
    }
}
