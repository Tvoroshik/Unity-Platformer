using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ground")
            GetComponentInParent<PlayerController>().ground = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
               
        if (collision.gameObject.tag == "ground")
            GetComponentInParent<PlayerController>().ground = false;
    }
}
