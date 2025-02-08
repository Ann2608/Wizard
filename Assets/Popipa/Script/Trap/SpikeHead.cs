using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : Trap
{
    private Vector3 Destination;        // điểm đích mà spikehead đi tới
    [SerializeField] private float Speed;
    [SerializeField] private float Range;
    [SerializeField] private float DelayAtk;
    [SerializeField] private LayerMask playerlayer;
    private float CheckTime;

    private bool Attacking;

    private Vector3[] Direction = new Vector3[4];       // SpikeHead di chuyển sang 4 hướng

    private void OnEnable()
    {
        Stop();
    }
    private void Update()
    {
        if(Attacking)
        transform.Translate(Destination * Time.deltaTime * Speed);      // câu lệnh dùng để di chuyển đối tượng trong unity
        else
        {
            CheckTime += Time.deltaTime;            // time.deltaTime dùng để khiến game mượt mà hơn
            if (CheckTime > DelayAtk)
                CheckPlayer();
        }
    }
    private void CheckPlayer()
    {
        Dichuyensangcachuongkhacnhau();
        //kiểm tra xem spike có thấy player ở cả 4 hướng không
        for (int i = 0; i < Direction.Length; i++)
        {
            Debug.DrawRay(transform.position, Direction[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction[i], Range, playerlayer);
            if(hit.collider != null && !Attacking)
            {
                Attacking = true;
                Destination = Direction[i];
                CheckTime = 0;
            }
        }
    }
    private void Dichuyensangcachuongkhacnhau()
    {
        Direction[0] = transform.right * Range;     // đi sang phải
        Direction[1] = -transform.right * Range;
        Direction[2] = transform.up * Range;
        Direction[3] = -transform.up * Range;
    }

    private void Stop()
    {
        Destination = transform.position;           // thay đổi vị trí đối tượng: đến đích thì dừng lại
        Attacking = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        Stop();// dừng spike lại khi chạm vào cái gì đó

    }
}
