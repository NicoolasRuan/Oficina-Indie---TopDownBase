using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }


    private void Awake()
    {
        // Se já existir uma instância e não for esta, destrói o intruso
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Define a instância global
        instance = this;

    }
}
