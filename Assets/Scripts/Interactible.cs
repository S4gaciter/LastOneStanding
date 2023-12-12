using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    public int cost;
    [HideInInspector] public string interactionText;
    [SerializeField] private InteractionType interactType;
    
    Inventory inventory;

    public void Awake()
    {
        inventory = GameObject.Find("WeaponHandle").GetComponent<Inventory>();
    }

    public void Start()
    {
        SetInteractibleText();
    }
    public void ReceiveInteraction()
    {
        switch (interactType)
        {
            // Add Interaction Functions Here
            case InteractionType.Test:
                CreditsManager.Instance.AddCredits(100);
                break;
            case InteractionType.Door:
                if (CreditsManager.Instance.GetCurrentCredits() >= cost)
                {
                    CreditsManager.Instance.RemoveCredits(cost);
                    Destroy(gameObject);
                }
                break;
            case InteractionType.Weapon:
                {
                    WeaponEntity buyable = gameObject.GetComponent<WeaponEntity>();
                    if (CreditsManager.Instance.GetCurrentCredits() >= buyable.cost)
                    {
                        CreditsManager.Instance.RemoveCredits(buyable.cost);
                        buyable.BuyWeapon();
                    }
                }
                break;
        }
    }

    void SetInteractibleText()
    {
        switch (interactType)
        {
            case InteractionType.Test:
                interactionText = $"F - Gain 100 points";
                break;
            case InteractionType.Weapon:
                WeaponEntity buyable = gameObject.GetComponent<WeaponEntity>();
                interactionText = $"F - Buy {buyable.GetWeaponName()} for {cost}";
                break;
            case InteractionType.Door:
                interactionText = $"F - Open door for {cost}";
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
