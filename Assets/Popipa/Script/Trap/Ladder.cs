using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    [SerializeField] private float Speed;
    private bool IsLadder;
    private bool IsClim;

    [SerializeField] private Rigidbody2D rg;


    private void Update()   //không liên quan đến vật lý
    {
        vertical = Input.GetAxis("Vertical");

        if(IsLadder && Mathf.Abs(vertical) > 0f)
        {
            IsClim = true;
        }
    }
    private void FixedUpdate()  //liên quan đến vật lý
    {
        if(IsClim)
        {
            rg.gravityScale = 0f;
            rg.linearVelocity = new Vector2 (rg.linearVelocity.x, vertical * Speed);
        }
        else
        {
            rg.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            IsLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            IsLadder = false;
            IsClim = false;
        }
    }

}
