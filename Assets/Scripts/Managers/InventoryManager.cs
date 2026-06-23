using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    public GameObject inv_background;
    public GameObject inv_slot;

    EntityStats player_stats;
    PlayerBehavior player_inv_selection;
    public int selected_slot = 1;

    // gold manager
    public int gold_count;
    public TextMeshProUGUI gold_text;


    public List<Weapon> inventory_;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        
        player_stats = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        player_inv_selection = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
        SelectedWeapon(0);
    }

    private void Update()
    {
        InventorySelection();
    }

    void RefreshInventory()
    {

        // refresh gold
        gold_text.text = gold_count.ToString();


        GameObject[] destroy_slots = GameObject.FindGameObjectsWithTag("Slot");

        foreach(GameObject go in destroy_slots)
        {
            Destroy(go);
        }

        int hotkey = 1;
        foreach(Weapon weapon in inventory_)
        {
            GameObject slot_instance = Instantiate(inv_slot, inv_background.transform);
            //GameObject.GetCompo<Image>().sprite = weapon.weapon_icon;

            if (weapon == null)
            {
                slot_instance.transform.Find("Icon").GetComponent<Image>().enabled = false;
                // slot_instance.GetComponentInChildren<Image>().enabled = false;
                slot_instance.GetComponent<Image>().enabled = true;
            }
            else
            {
                //slot_instance.GetComponent<Image>().enabled = false;
                slot_instance.transform.Find("Icon").GetComponent<Image>().enabled = true;

                slot_instance.transform.Find("Icon").GetComponent<Image>().sprite = weapon.weapon_icon;
                
                slot_instance.GetComponent<Outline>().enabled = false;

                if (selected_slot == hotkey)
                {
                    slot_instance.GetComponent<Outline>().enabled = true;
                }

            }

            slot_instance.GetComponentInChildren<TextMeshProUGUI>().text = hotkey.ToString();
            hotkey++;
        }
    }

    void SelectedWeapon(int hot_key)
    {
        if(hot_key < 1)
            return;
        
        Weapon weapon_selected;
        //Debug.Log("Key: " + hot_key);
        //Debug.Log("index: " + (hot_key - 1));

        if (inventory_[hot_key - 1] != null)
        {
            weapon_selected = inventory_[hot_key - 1];

            player_stats.attack_damage = weapon_selected.weapon_damage;
            player_stats.attack_speed = weapon_selected.weapon_speed;
            player_stats.attack_range = weapon_selected.weapon_range;
            player_stats.attack_cooldown = weapon_selected.weapon_cooldown;
        }
        else
        {
            player_stats.attack_damage = 0;
            player_stats.attack_speed = 0;
            player_stats.attack_range = 0;
            player_stats.attack_cooldown = 0;
        }
        selected_slot = hot_key;
        RefreshInventory();
    }

    void InventorySelection()
    {
        if(player_inv_selection.lastKey < 1)
        {
            SelectedWeapon(1);
        } else
        {
            SelectedWeapon(player_inv_selection.lastKey);
        }
    }

    public void AddGold(int g)
    {
        gold_count += g;
        RefreshInventory();
    }
}
