using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.DualShock;

public class PlayerBehavior : MonoBehaviour
{
    EntityStats player_stats;

    public int lastKey;

    public bool playerInteraction;

    //private Key lastKey;

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
    
    public void OnInventoryController(InputAction.CallbackContext context)
    {

        if (!context.performed) return;

        switch (context.control.name)
        {
            case "leftShoulder":
                lastKey = lastKey == 1 ? 4 : lastKey - 1;
                break;

            case "rightShoulder":
                lastKey = lastKey == 4 ? 1 : lastKey + 1;
                break;

            case "1":
                lastKey = 1;
                break;

            case "2":
                lastKey = 2;
                break;

            case "3":
                lastKey = 3;
                break;

            case "4":
                lastKey = 4;
                break;
        }

    }


    public void OnInteraction(InputAction.CallbackContext context)
    {
        //Debug.Log("Apertou: " + context.performed);
        playerInteraction = context.performed;
    }
}
