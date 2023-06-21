using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float life = 1f;
    [SerializeField] float damage = 1f;

    ChickenManager manager;

    private void Update()
    {
        transform.Translate(GetRandomVector() * speed * Time.deltaTime);
    }

    private Vector3 GetRandomVector()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        return new Vector3(x, y, 0f);
    }

    public void SetManager(ChickenManager manager)
    {
        this.manager = manager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Hit chicken");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
