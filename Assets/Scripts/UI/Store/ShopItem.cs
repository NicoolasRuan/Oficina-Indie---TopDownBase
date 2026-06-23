using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public Weapon w_;

    public TextMeshProUGUI item_name_holder;
    public TextMeshProUGUI item_price_holder;
    public Image item_icon_holder;
    public TextMeshProUGUI item_info_holder;

    private void Start()
    {
        Setup(w_);
    }

    public void Setup(Weapon w)
    {
        item_name_holder.text = w.weapon_name;
        item_price_holder.text = w.weapon_price.ToString();
        item_icon_holder.sprite = w.weapon_icon;
        item_info_holder.text = "Attack Damage: " + w.weapon_damage + "\n\nAttack Speed: " + w.weapon_speed + "\n\nRange: " + w.weapon_range;
    }
}
