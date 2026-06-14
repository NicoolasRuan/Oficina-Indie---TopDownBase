using UnityEngine;

[CreateAssetMenu(fileName="Weapon")]
public class Weapon : ScriptableObject
{
    public float weapon_damage;
    public float weapon_speed;
    public float weapon_range;
    public float weapon_cooldown;
    public Sprite weapon_icon;
}
