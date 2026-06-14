using UnityEngine;
using UnityEngine.InputSystem;

public class GamepadPointerManager : MonoBehaviour
{
    public RectTransform pointerTransform;
    public float pointerSpeed = 500f;

    private Vector2 stickInput; // input do analogico
    private Vector2 pointerPosition;

    private bool isUsingGamepad = false;

    private void Start()
    {
        pointerPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
        pointerTransform.position = pointerPosition;

        Cursor.visible = false;
    }

    private void Update()
    {
        if (isUsingGamepad)
        {
            MoveWithGamepad();
        }
        else
        {
            MoveWithMouse();
        }
    }




    public void OnLookGamepad(InputAction.CallbackContext context)
    {
        stickInput = context.ReadValue<Vector2>();

        // Se o analógico se moveu além da zona morta, o jogador mudou para o controle
        if (stickInput.sqrMagnitude > 0.05f)
        {
            isUsingGamepad = true;
        }
    }

    public void OnLookMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            // Pega a posição bruta do mouse diretamente da tela
            pointerPosition = context.ReadValue<Vector2>();
            isUsingGamepad = false;
        }
    }

    void MoveWithGamepad()
    {
        if (stickInput.sqrMagnitude > 0.01f)
        {
            // Soma a direção do analógico à posição atual
            pointerPosition += stickInput * pointerSpeed * Time.deltaTime;

            // Limita para o ponteiro não fugir da tela
            pointerPosition.x = Mathf.Clamp(pointerPosition.x, 0, Screen.width);
            pointerPosition.y = Mathf.Clamp(pointerPosition.y, 0, Screen.height);

            pointerTransform.position = pointerPosition;
        }
    }

    private void MoveWithMouse()
    {
        // No caso do mouse, a posição do ponteiro da UI é simplesmente a posição real do mouse
        pointerTransform.position = pointerPosition;
    }

    public Vector3 GetPointerWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(pointerPosition);
    }
}
