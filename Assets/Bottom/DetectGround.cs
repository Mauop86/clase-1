using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround: MonoBehaviour
{
    public static bool checkGround;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            checkGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            checkGround = false;
        }
    }
}
