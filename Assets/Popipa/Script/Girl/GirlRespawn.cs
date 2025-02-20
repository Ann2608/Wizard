﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip CpSound;     // nhac game
    private Transform CurrentCp;
    private GirlHealth girlHealth;
    private UIMenu UiMenu;

    private void Awake()
    {
        girlHealth = GetComponent<GirlHealth>();
        UiMenu = FindObjectOfType<UIMenu>();        // tìm kiếm đối tượng UImenu trong scene, không nên dùng nhiều lần
    }
    public void CheckRespawn()
    {
        // kiểm tra xem đã chạm vào checkpoint hay chưa
        if (CurrentCp == null)
        {
            // Game over screen
            UiMenu.GameOVer();

            return;     // không chạy phần respawn
        }
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
