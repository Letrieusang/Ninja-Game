using Unity.VisualScripting;
using UnityEngine;

public enum WeaponType
{
    Magic,
    Melee,
}

[CreateAssetMenu(fileName = "Weapon_")]
public class Weapon : ScriptableObject
{
    [Header("Config")]
    public Sprite Icon;
    public WeaponType type;
    public float Damage;

    [Header("Projectile")]
    public Projectile ProjectilePrefab;
    public float RequiredMana;
    
    

}
