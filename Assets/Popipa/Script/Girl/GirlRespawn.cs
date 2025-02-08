using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip CpSound;     // nhac game
    private Transform CurrentCp;
    private GirlHealth girlHealth;

    private void Awake()
    {
        girlHealth = GetComponent<GirlHealth>();
    }
    public void Respawn()
    {
        transform.position = CurrentCp.position;        // chet thi ve cp
        girlHealth.respawn();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "CheckPoint")
        {
            CurrentCp = collision.transform;
            // SoundManager.instance.PlaySound(CpSound)  nhac
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
