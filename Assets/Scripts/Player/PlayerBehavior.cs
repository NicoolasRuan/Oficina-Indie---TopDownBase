using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    EntityStats player_stats;

    public string _player_inv_selection;

    private void Start()
    {
        player_stats = GetComponent<EntityStats>();
    }

    public void TakeDamage(float value)
    {
        player_stats.hp -= value;
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.1f);

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void OnInventorySelectKeyboard(InputAction.CallbackContext context)
    {
        _player_inv_selection = context.control.displayName;
    }

}
