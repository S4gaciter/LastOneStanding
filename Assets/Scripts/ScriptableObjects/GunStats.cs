using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Stats", menuName = "ScriptableObjects/GunStats")]
public class GunStats : ScriptableObject
{
    private void Awake()
    {
        currentAmmo = maxAmmo;
        currentMag = magazineSize;
    }

    public string gunName;
    
    [Header("Weapon Stats")]
    public float damage;
    public float range;
    public float fireRate;
    public float reloadTime;

    [Header("Ammo Capacity")]
    public int maxAmmo;
    public int magazineSize;
    public int currentAmmo;
    public int currentMag;

    [Header("Additional Properties")]
    public bool automatic;
}