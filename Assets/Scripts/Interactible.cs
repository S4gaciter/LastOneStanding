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
    Inventory inventory;

    public void Awake()
    {
        credits = GameObject.Find("Player").GetComponent<CreditsManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        inventory = GameObject.Find("WeaponHandle").GetComponent<Inventory>();
    }
    public void ReceiveInteraction()
    {
        switch (interactType)
        {
            // Add Interaction Functions Here
            case InteractionType.Test:
                interactionText = "Interact to get 100 points";
                credits.AddCredits(100);
                break;
            case InteractionType.Door:
                Destroy(gameObject);
                break;
            case InteractionType.Weapon:
                {
                    WeaponEntity buyable = gameObject.GetComponent<WeaponEntity>();
                    if (credits.GetCurrentCredits() >= buyable.cost && !inventory.HasWeapon(buyable.weapon))
                    {
                        credits.RemoveCredits(buyable.cost);
                        buyable.BuyWeapon();
                    }
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
