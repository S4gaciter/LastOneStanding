using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Player/Main Gameplay UI
    Canvas playerUI;
    Text interactionText;
    Text healthText;
    Text ammoText;
    Text creditText;

    public Fade blackScreen;

    public static UIManager Instance;

    //Initialization
    private void Awake()
    {
        Instance = this;

        // Gameplay UI
        playerUI = GameObject.Find("PlayerUI").GetComponent<Canvas>();

        playerUI.gameObject.SetActive(true);

        ammoText        = GameObject.Find("AmmoText").GetComponent<Text>();
        healthText      = GameObject.Find("HealthText").GetComponent<Text>();
        creditText      = GameObject.Find("CreditsText").GetComponent<Text>();
        interactionText = GameObject.Find("InteractionText").GetComponent<Text>();
        blackScreen.BeginFadeIn();
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
    public void SetHealthText(float amount)
    {
        healthText.text = amount.ToString("F2");
    }
    public void SetAmmoText(int curr, int max)
    {
        ammoText.text = $"{curr}/{max}";
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
