using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectile_prefab;
    EntityStats player_stats;

    private PlayerGamepadPosition gamepadPointer;

    public float _cooldown;
    public bool can_attack = true;

    private bool isAttacking;

    private Vector2 mouseScreenPosition;


    void Start()
    {
        player_stats = GetComponent<EntityStats>();
        gamepadPointer = GetComponent<PlayerGamepadPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        //Attack();
        CoolDown();

        if(isAttacking && can_attack)
        {
            Attack();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
        }

        if (context.canceled)
        {
            isAttacking = false;
        }
    }
    public void Attack()
    {
        
        Vector3 mouseWorldPosition = gamepadPointer.GetPointerWorldPosition();
        mouseWorldPosition.z = 0f;
            

        Vector2 projectile_direction = ((Vector2)mouseWorldPosition - (Vector2)transform.position).normalized;

        GameObject projectile_instance = Instantiate(projectile_prefab, transform.position, Quaternion.identity);

        projectile_instance.GetComponent<ProjectileDamage>().projectile_damage = player_stats.attack_damage;



        projectile_instance.GetComponent<Rigidbody2D>().AddForce(projectile_direction * player_stats.attack_speed, ForceMode2D.Impulse);

        can_attack = false;
        _cooldown = 0;
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseScreenPosition = context.ReadValue<Vector2>();
    }

    void CoolDown()
    {
        if(_cooldown > player_stats.attack_cooldown && !can_attack)
        {
            _cooldown = 0;
            can_attack = true;
        } else
        {
            _cooldown += Time.deltaTime;
        }
    }
}
