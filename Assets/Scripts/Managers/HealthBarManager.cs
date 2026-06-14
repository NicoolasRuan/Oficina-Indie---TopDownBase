using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarManager : MonoBehaviour
{
    private List<GameObject> bars;

    private void Start()
    {
        bars = new List<GameObject>(GameObject.FindGameObjectsWithTag("HealthBar"));
    }

    private void Update()
    {
        bars.RemoveAll(item => item == null); // remove a barra não usada.
        //Debug.Log(bars.Count);
        UpdateBars(bars);
    }

    void UpdateBars(List<GameObject> bars)
    {
        foreach (GameObject bar in bars)
        {
            bar.GetComponent<Slider>().minValue = 0;
            bar.GetComponent<Slider>().maxValue = bar.transform.parent.parent.gameObject.GetComponent<EntityStats>().max_hp;
            float current_hp = bar.transform.parent.parent.gameObject.GetComponent<EntityStats>().hp;

            //Debug.Log(bar.transform.root.gameObject.name);

            bar.GetComponent<Slider>().value = current_hp;
        }
    }
}
