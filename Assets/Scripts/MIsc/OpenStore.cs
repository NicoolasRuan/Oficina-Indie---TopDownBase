using UnityEngine;
using UnityEngine.InputSystem;

public class OpenStore : MonoBehaviour
{
    public GameObject playerObj;

    public GameObject storeText;

    private bool playerIsNear;

    private void Start()
    {
        storeText.SetActive(false); 
    }
    private void Update()
    {
        float dist = Vector2.Distance(transform.position, playerObj.transform.position);

        playerIsNear = dist < 2.5f;

        storeText.SetActive(playerIsNear);

        if (!playerIsNear && UIManager.instance.isStoreOpen)
        {
            UIManager.instance.CloseStore();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (playerIsNear)
        {
            UIManager.instance.ToggleStore();
        }
    }
}
