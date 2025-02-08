using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    [SerializeField] private int HealthPlus;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<GirlHealth>().HealthPlus(HealthPlus);
            gameObject.SetActive(false);
        }
    }
}
