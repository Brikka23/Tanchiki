using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    public GameObject parent;

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<User>())
        {
            if (col.gameObject!= parent)
            {
                Destroy(gameObject);
                col.gameObject.GetComponent<User>().TakeDamage(damage);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
