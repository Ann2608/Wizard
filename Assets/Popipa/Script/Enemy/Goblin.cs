﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] private float AtkCoolDown;
    [SerializeField] private float Dmg;
    [SerializeField] private float Range;
    [SerializeField] private float ColliderDistance;        //độ rộng của Collider
    [SerializeField] private AudioClip SwordSound;
    private float CoolDownTimer = Mathf.Infinity;
    Rigidbody2D rg;
    Animator Anim;
    public BoxCollider2D Box;
    public LayerMask playerlayer;
    private GirlHealth PlayerHealth;

    private EnemyMv EneMv;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        EneMv = GetComponentInParent<EnemyMv>();
    }
    void Update()
    {
        CoolDownTimer += Time.deltaTime;
        if (PlayerSight())
        {
            if (CoolDownTimer >= AtkCoolDown)
            {
                CoolDownTimer = 0;
                Anim.SetTrigger("Atk");
                DmgPlayer();
                SoundManager.instance.PlaySound(SwordSound);
            }
        }
        if (EneMv != null)
        {
            EneMv.enabled = !PlayerSight();         // di chuyển nếu người chơi không trong tầm nhìn
        }
    }
    private bool PlayerSight()      //tấn công khi người chơi trong tầm nhìn
    {
        RaycastHit2D hit = Physics2D.BoxCast(Box.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance,
            new Vector3(Box.bounds.size.x * Range, Box.bounds.size.y, Box.bounds.size.z), 0, Vector2.left, 0, playerlayer);
        if (hit.collider != null)
        {
            PlayerHealth = hit.transform.GetComponent<GirlHealth>();
        }

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Box.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance,
            new Vector3(Box.bounds.size.x * Range, Box.bounds.size.y, Box.bounds.size.z));
    }
    private void DmgPlayer()
    {
        if (PlayerSight())
        {
            PlayerHealth.TakeDmg((int)Dmg);
            Debug.Log(gameObject.name + " is dealing damage to player.");
        }
        else
        {
            Debug.LogWarning(gameObject.name + " can't find PlayerHealth.");
        }
    }
}
