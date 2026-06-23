using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public bool isStoreOpen;

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

    private void Start()
    {
        isStoreOpen = false;
    }

    private void Update()
    {
        if(isStoreOpen)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}
