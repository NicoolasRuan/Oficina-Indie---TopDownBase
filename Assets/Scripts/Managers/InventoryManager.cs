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
    public int selected_slot = 0;

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

        int hotkey = 0;
        foreach(Weapon weapon in inventory_)
        {
            GameObject weapon_instance = Instantiate(inv_slot, inv_background.transform);
            //GameObject.GetCompo<Image>().sprite = weapon.weapon_icon;

            weapon_instance.transform.Find("Icon").GetComponent<Image>().sprite = weapon.weapon_icon;
            weapon_instance.GetComponentInChildren<TextMeshProUGUI>().text = hotkey.ToString();
            weapon_instance.GetComponent<Outline>().enabled = false;

            if(selected_slot == hotkey)
            {
                weapon_instance.GetComponent<Outline>().enabled = true;
            }
            hotkey++;
        }
    }

    void SelectedWeapon(int hot_key)
    {
        
        Weapon weapon_selected = inventory_[hot_key];
        player_stats.attack_damage = weapon_selected.weapon_damage;
        player_stats.attack_speed = weapon_selected.weapon_speed;
        player_stats.attack_range = weapon_selected.weapon_range;
        player_stats.attack_cooldown = weapon_selected.weapon_cooldown;

        selected_slot = hot_key;
        RefreshInventory();
    }

    void InventorySelection()
    {
        if(player_inv_selection._player_inv_selection == "0")
        {
            SelectedWeapon(0);
        }

        if (player_inv_selection._player_inv_selection == "1")
        {
            SelectedWeapon(1);
        }

        if (player_inv_selection._player_inv_selection == "2")
        {
            SelectedWeapon(2);
        }

    }

    public void AddGold(int g)
    {
        gold_count += g;
        RefreshInventory();
    }
}
