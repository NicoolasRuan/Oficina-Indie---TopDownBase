using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    EntityStats enemy_stats;
    private GameObject player_object;
    private float speed;
    void Start()
    {
        player_object = GameObject.FindGameObjectWithTag("Player");
        enemy_stats = GetComponent<EntityStats>();
        speed = enemy_stats.base_speed;
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player_object.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Tomou dano");
            collision.gameObject.GetComponent<PlayerBehavior>().TakeDamage(enemy_stats.attack_damage);
            enemy_stats.hp -= (enemy_stats.max_hp + 1);

            Debug.Log(enemy_stats.hp);
        }
    }
}
