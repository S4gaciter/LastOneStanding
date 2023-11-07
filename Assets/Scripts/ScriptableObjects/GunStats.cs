using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Stats", menuName = "ScriptableObjects/GunStats")]
public class GunStats : ScriptableObject
{
    public string gunName;
    public float damage;
    public float range;
    public int currentAmmo;
    public int maxAmmo;
    public int magazineSize;
}
