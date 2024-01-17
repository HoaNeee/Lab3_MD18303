using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            CharMove1.charMove1.isGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            CharMove1.charMove1.isGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            CharMove1.charMove1.isGround = false;
    }
}
