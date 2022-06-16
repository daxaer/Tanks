using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    Rigidbody2D rb;

    public float AliveTime = 5;
    public float radius = 1;
    public GameObject ExplisonPrefab;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke("Explode", AliveTime);
        Invoke("EnableCollider", .2f);
    }
    public void Initialize(int power)
    {
        rb.AddForce(transform.right * (power / 2), ForceMode2D.Impulse);
    }
    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    void Explode()
    {
        DestruirTerreno.instance.DestruirMapa(transform.position, radius);
        Instantiate(ExplisonPrefab, transform.localPosition,transform.rotation);
        Destroy(gameObject);
    }     
}
