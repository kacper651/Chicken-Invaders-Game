using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    Rigidbody2D rb2d;
    float screenBoundsX;
    float playerWidth;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        float screenHalfWidth = Camera.main.aspect *
                                Camera.main.orthographicSize;
        playerWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        screenBoundsX = screenHalfWidth - playerWidth / 2;
    }

    void Update()
    {
        float movementX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Vector3 newPosition = transform.position + new Vector3(movementX, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, -screenBoundsX, screenBoundsX);
        transform.position = newPosition;
    }
}
