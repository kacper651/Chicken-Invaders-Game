using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUtils : MonoBehaviour
{
    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Chicken"))
        {
            Debug.Log("Hit chicken");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
