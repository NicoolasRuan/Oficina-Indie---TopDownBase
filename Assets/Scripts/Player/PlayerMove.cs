using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    EntityStats player_stats;
    public float speed;

    private Rigidbody2D rb;
    public Vector2 direction;

    public bool _isSlow;


    void Start()
    {
        _isSlow = false;

        player_stats = GetComponent<EntityStats>();
        rb = GetComponent<Rigidbody2D>();

        speed = player_stats.base_speed;
    }

    private void Update()
    {
        OnSlow();
        Debug.Log(direction);
    }

    void FixedUpdate()
    {
        OnMovePhysics();
    }

    #region Movemment
    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }


    void OnMovePhysics()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnSlow()
    {
        if (_isSlow)
        {
            speed = player_stats.base_speed / 2;
        }
        else
        {
            speed = player_stats.base_speed;
        }
    }

    #endregion


    #region triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Lama"))
        {
            _isSlow = true;  
        } 

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lama"))
        {
            _isSlow = false;
        }
    }

    #endregion
}
