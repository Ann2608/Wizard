using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    [SerializeField] private int HealthPlus;
    [SerializeField] private AudioClip HealthSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.PlaySound(HealthSound);
            collision.GetComponent<GirlHealth>().HealthPlus(HealthPlus);
            gameObject.SetActive(false);
        }
    }
}
