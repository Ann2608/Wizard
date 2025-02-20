using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GirlAtk : MonoBehaviour
{
    [SerializeField] private float AtkCoolDown;
    public Transform AttackPoint;
    public float Range;
    public int AtkDmg;
    public LayerMask Enemylayer;
    Rigidbody2D rg;
    Animator Anim;
    private GirlMV girl;
    private float CoolDownTimer = Mathf.Infinity;
    [SerializeField] private AudioClip SwordSound;
    void Awake()
    {
        Anim = GetComponent<Animator>();
        girl = GetComponent<GirlMV>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && CoolDownTimer > AtkCoolDown && girl.CanAtk())
            Attack();
        CoolDownTimer += Time.deltaTime;
    }
    private void Attack()
    {
        SoundManager.instance.PlaySound(SwordSound);
        Anim.SetTrigger("Attack");
        CoolDownTimer = 0;
        Collider2D[] HitEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, Range, Enemylayer);
        foreach (Collider2D hitEnemy in HitEnemy)
        {
            hitEnemy.GetComponent <HealthEnemy>().TakeDmg(AtkDmg);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, Range);
    }
}
