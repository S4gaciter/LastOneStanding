using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    public string interactionText;
    public CreditsManager credits;
    public InteractionType interactType;

    public void Start()
    {
        credits = GameObject.Find("Player").GetComponent<CreditsManager>();
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
                    WeaponEntity buyable = gameObject.GetComponent<WeaponEntity>();
                    if (credits.GetCurrentCredits() >= buyable.cost)
                    {
                        credits.RemoveCredits(buyable.cost);
                    }
                }
                break;
        }
    }

    public enum InteractionType
    {
        Test,
        Weapon,
        Door
    }
}
