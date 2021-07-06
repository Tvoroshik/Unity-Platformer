using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;
    }
    private void Update()
    {
        
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        pos.z = -10f;
    }
}