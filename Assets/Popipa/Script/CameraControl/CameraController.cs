using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float Ahead;               //cam hướng về phía trước
    [SerializeField] private float SpeedCam;
    private float LookAhead;
    [SerializeField] private float heightOffset; // Độ cao camera sẽ di chuyển theo
    private void Update()
    {
        float targetY = player.position.y + heightOffset;
        transform.position = new Vector3 (player.position.x + LookAhead, targetY, transform.position.z);
        LookAhead = Mathf.Lerp(LookAhead, (Ahead * player.localScale.x), Time.deltaTime * SpeedCam);
    }
}
