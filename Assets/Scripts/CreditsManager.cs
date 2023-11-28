using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    int currentCredits = 500;
    const int maxCredits = 999999;

    UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        uiManager.SetCreditText(currentCredits);
    }

    public void AddCredits(int credits)
    {
        currentCredits += credits;
        uiManager.SetCreditText(currentCredits);
    }

    public void RemoveCredits(int credits)
    {
        currentCredits -= credits;
        currentCredits = Mathf.Clamp(currentCredits, 0, maxCredits);
        uiManager.SetCreditText(currentCredits);
    }
    public int GetCurrentCredits()
    {
        return currentCredits;
    }

}
