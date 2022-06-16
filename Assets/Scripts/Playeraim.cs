using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playeraim : MonoBehaviour
{
    public int MinPower = 0;
    public int MaxPower = 100;
    int curPower;
    int curAngle;
    public int miTurno;
    public SpriteRenderer aimSprite;
    public SpriteRenderer aimSprite2;

    public Transform disparar;
    public Text poder;

    public TankShooting tankShooting;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.Instance.GetPuedoDisparar() && GameManager.Instance.GetTurno() == miTurno)
        {
            aimSprite.GetComponent<SpriteRenderer>().enabled = true;
            CalculateAngle();
            CalculatePower();
        }
        else if (Input.GetMouseButtonUp(0) && GameManager.Instance.GetPuedoDisparar() && GameManager.Instance.GetTurno() == miTurno)
        {
            tankShooting.Fireprojectile(curPower);
            aimSprite.GetComponent<SpriteRenderer>().enabled = false;
            GameManager.Instance.SetPuedoDisparar(false);
        }
    }

    private void CalculatePower()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        float distance = Vector3.Distance(mousePos, transform.position);
        UpdatePower((int)distance * 2);
    }

    private void UpdatePower(int amount)
    {
        curPower = Mathf.Clamp(amount, MinPower, MaxPower);
        aimSprite.transform.localScale = new Vector2(curPower / 12, 1);
        poder.text = "Poder: " + curPower;
    }

    private void CalculateAngle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 dir = mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        UpdateAngle((int)angle);
    }

    private void UpdateAngle(int angle)
    {
        curAngle = angle;
        aimSprite2.transform.rotation = Quaternion.AngleAxis(curAngle, Vector3.forward);
    }

}