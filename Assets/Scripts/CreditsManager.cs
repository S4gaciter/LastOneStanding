using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public int currentCredits = 500;
    private int maxCredits = 1000000;

    void AddCredits(int credits)
    {
        currentCredits += credits;
    }

    void RemoveCredits(int credits)
    {
        currentCredits -= credits;
        currentCredits = Mathf.Clamp(currentCredits, 0, maxCredits);
    }
}
