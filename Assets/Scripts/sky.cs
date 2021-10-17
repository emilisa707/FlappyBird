using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sky : MonoBehaviour
{
    Bird bird;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bird = collision.gameObject.GetComponent<Bird>();

        if (bird)
        {
            Collider2D collider = GetComponent<Collider2D>();

            if (collider)
            {
                collider.enabled = false;
            }

            bird.Dead();
        }
    }
}
