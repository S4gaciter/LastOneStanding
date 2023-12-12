using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    int currentCredits = 500;
    const int maxCredits = 999999;

    public static CreditsManager Instance;

    private void Start()
    {
        Instance = this;
        UIManager.Instance.SetCreditText(currentCredits);
    }

    public void AddCredits(int credits)
    {
        currentCredits += credits;
        UIManager.Instance.SetCreditText(currentCredits);
    }

    public void RemoveCredits(int credits)
    {
        currentCredits -= credits;
        currentCredits = Mathf.Clamp(currentCredits, 0, maxCredits);
        UIManager.Instance.SetCreditText(currentCredits);
    }
    public int GetCurrentCredits()
    {
        return currentCredits;
    }

}
