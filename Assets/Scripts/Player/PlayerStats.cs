using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Config")]
    public int Level;

    [Header("Health")]
    public float Health;
    public float MaxHealth;

    [Header("Mana")] 
    public float Mana;
    public float MaxMana;

    [Header("Experience")]
    public float CurrentExp; 
    public float NextLevelExp;
    public float InitialLevelExp;
    [Range(1f, 100f)] public float ExpMultiplier;

    public void ResetPlayer()
    {
        Mana = MaxMana;
        Health = MaxHealth;
        Level = 1;
        CurrentExp = 0f;
        NextLevelExp = InitialLevelExp; 
    }
}
