using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactible : MonoBehaviour
{
    public string interactionText;
    public InteractionType interactType;

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
        }
    }

    public enum InteractionType
    {
        Test,
        Weapon,
        Door
    }
}
