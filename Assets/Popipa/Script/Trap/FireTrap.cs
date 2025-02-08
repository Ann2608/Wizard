using UnityEngine;
using System.Collections;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;         // thời gian sau khi người chơi va chạm bẫy sẽ kích hoạt
    [SerializeField] private float activeTime;              // thời gian lửa đốt
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // bẫy bắt đầu kích hoạt nhưng chưa gây sát thương
    private bool active; // bẫy kích hoạt và có thể gây sát thương lên player

    private GirlHealth player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
                StartCoroutine(ActivateFiretrap());

            player = collision.GetComponent<GirlHealth>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player = null;
    }

    private void Update()
    {
        if (active && player != null)
            player.TakeDmg((int)damage);
    }

    private IEnumerator ActivateFiretrap()
    {
        // Người chơi nhảy qua sẽ kích hoạt bẫy thành màu đỏ
        triggered = true;
        spriteRend.color = Color.red;

        //chờ thời gian sau khi player nhảy qua sẽ kích hoạt bẫy và trở lại bình thường
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white; //kích hoạt xong trở lại thành bình thường  
        active = true;      //đang gây sát thương
        anim.SetBool("On", true);

        //chờ sau khi hết thời gian gây sát thương sẽ trở về trạng thái ban đầu
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("On", false);
    }
}