using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Player/Main Gameplay UI
    Canvas playerUI;
    Text interactionText;
    Text creditText;

    //Initialization
    private void Start()
    {
        playerUI = GameObject.Find("PlayerUI").GetComponent<Canvas>();

        playerUI.gameObject.SetActive(true);
        interactionText = GameObject.Find("InteractionText").GetComponent<Text>();
        creditText = GameObject.Find("CreditsText").GetComponent<Text>();
    }

    // Toggle Functions
    public void TogglePlayerUI()
    {
        if (playerUI.gameObject.activeSelf)
        {
            playerUI.gameObject.SetActive(false);
        }
        else
        {
            playerUI.gameObject.SetActive(true);
        }
    }

    // Set Functions
    public void SetInteractionText(string text)
    {
        interactionText.text = text;
    }

    public void SetCreditText(int amount)
    {
        creditText.text = amount.ToString();
    }

    // Show Functions
    public void ShowInteractionText()
    {
        interactionText.gameObject.SetActive(true);
    }

    // Hide Functions
    public void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }
}
