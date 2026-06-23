using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public bool isStoreOpen;

    public GameObject store_canvas;
    public GameObject shop_item;
    public GameObject shop_bg;

    public List<Weapon> weapons_sold;


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
        RandomItemShop();

        isStoreOpen = false;    
        store_canvas.SetActive(false);
    }

    public void ToggleStore()
    {
        if(isStoreOpen)
        {
            CloseStore();
        } else
        {
            OpenStore();
        }
    }

    public void OpenStore()
    {
        isStoreOpen = true;
        store_canvas.SetActive(true);
    }
    public void CloseStore()
    {
        isStoreOpen = false;
        store_canvas.SetActive(false);
    }


    void RandomItemShop()
    {

        int[] numbers = new int[3];

        for (int i = 0; i < 3; i++)
        {
            int random_n = Random.Range(0, weapons_sold.Count);

            numbers[i] = random_n;
        }

        bool isVerified = false;

        while (isVerified)
        {
            if (numbers[0] == numbers[1] || numbers[0] == numbers[2])
            {
                numbers[0] = Random.Range(0, weapons_sold.Count);
                continue;
            }
            else if (numbers[1] == numbers[2])
            {
                numbers[1] = Random.Range(0, weapons_sold.Count);
                continue;
            }
            else
            {
                isVerified = true;
            }
        }

        foreach (int i in numbers)
        {
            GameObject new_item_shop = Instantiate(shop_item, shop_bg.transform);
            new_item_shop.GetComponent<ShopItem>().w_ = weapons_sold[i];
            new_item_shop.GetComponent<ShopItem>().Setup(weapons_sold[i]);
        }

    }
}
