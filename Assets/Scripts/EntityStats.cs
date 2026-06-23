using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public float hp;
    public float max_hp;
    public float base_speed;
    public float attack_damage;
    public float attack_speed;
    public float attack_range;
    public float attack_cooldown;
    public int gold_carry;

    private void Start()
    {
        max_hp = hp;
        if (gameObject.tag != "Player")
        {
            gold_carry = Random.Range(0, 10);
        }
    }

    private void Update()
    {
        Death();
    }

    void Death()
    {
        
        if(hp <= 0)
        {
            // dar ouro para o player
            if (gameObject.tag != "Player")
            {
                InventoryManager.Instance.AddGold(gold_carry);
            }
            Destroy(gameObject);
        }
    }
}
