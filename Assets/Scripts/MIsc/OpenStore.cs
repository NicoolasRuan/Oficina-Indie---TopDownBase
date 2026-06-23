using UnityEngine;
using UnityEngine.InputSystem;

public class OpenStore : MonoBehaviour
{
    public GameObject playerObj;

    public GameObject storeText;

    private bool playerIsNear;

    public InputActionReference interactAction;

    private void Start()
    {
        storeText.SetActive(false); 
    }

    private void OnEnable()
    {
        interactAction.action.Enable();
    }

    private void OnDisable()
    {
        interactAction.action.Disable();
    }
    private void Update()
    {
        float dist = Vector2.Distance(transform.position, playerObj.transform.position);

        playerIsNear = dist < 2.5f;

        storeText.SetActive(playerIsNear);

        if (playerIsNear && interactAction.action.WasPressedThisFrame())
        {
            UIManager.instance.ToggleStore();
        }

        if (!playerIsNear && UIManager.instance.isStoreOpen)
        {
            UIManager.instance.CloseStore();
        }
    }
}
