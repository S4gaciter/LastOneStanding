using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Stats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float health;
    public float groundDrag;
    public float moveSpeed;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
}
