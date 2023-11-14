using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    private int currentCredits = 500;
    private const int maxCredits = 999999;
    private Text creditsText;

    private void Start()
    {
        creditsText = GameObject.Find("CreditsText").GetComponent<Text>();
        UpdateCreditUI();
    }
    public void AddCredits(int credits)
    {
        currentCredits += credits;
        UpdateCreditUI();
    }

    public void RemoveCredits(int credits)
    {
        currentCredits -= credits;
        currentCredits = Mathf.Clamp(currentCredits, 0, maxCredits);
        UpdateCreditUI();
    }
    public int GetCurrentCredits()
    {
        return currentCredits;
    }

    void UpdateCreditUI()
    {
        creditsText.text = currentCredits.ToString();
    }
}
