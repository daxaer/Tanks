using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    public int Turno;
    public Text victoria;
    public string textoDeVictoria= "";
    public GameObject prefab;

    Vector2 move;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        if(Turno == GameManager.Instance.GetTurno())
        movePlayer(move);
    }

    private void movePlayer(Vector2 dir)
    {
        rb.AddForce(dir * speed);
    }
    private void OnDestroy()
    {
        Instantiate(prefab, transform.localPosition, transform.rotation);
        victoria.text = textoDeVictoria; 
    }
}
