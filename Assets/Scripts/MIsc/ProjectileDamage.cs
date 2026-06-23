using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float projectile_damage;
    EntityStats player_stats;

    private void Start()
    {
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        Destroy(gameObject, player_stats.attack_range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.GetComponent<EntityStats>().hp -= projectile_damage;
        }
    }
}
