using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private int Turno = 1;
    [SerializeField] private Text tiempo;
    [SerializeField] private bool puedoDisparar = true;

    public static GameManager Instance;
    public Player[] jugadores;

    int time = 10;


    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        StartCoroutine("CambiarTurno");

    }
    public void SetPuedoDisparar(bool disparar)
    {
        puedoDisparar = disparar;
    }
    public bool GetPuedoDisparar()
    {
        return puedoDisparar;
    }
    public int GetTurno()
    {
        return Turno;
    }
    IEnumerator CambiarTurno()
    {
        yield return new WaitForSeconds(1f);
        if (time < 1)
        {
            tiempo.color = Color.white;
            time = 10;
            puedoDisparar = true;
            if (Turno == 1)
            {
                Turno = 2;
            }
            else
            {
                Turno = 1;
            }
            tiempo.text = time.ToString();
            StartCoroutine("CambiarTurno");
        }
        else
        {
            if (time < 3)
            {
                time--;
                tiempo.color = Color.red;
                tiempo.text = "Turno:" + time.ToString();
                StartCoroutine("CambiarTurno");
            }
            else
            {
                time--;
                tiempo.text = "Turno:" + time.ToString();
                StartCoroutine("CambiarTurno");
            }

        }

    }
}
