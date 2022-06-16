using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    AudioSource audio;
    public AudioClip ganaste;
    void Start()
    {
        StartCoroutine("Victori");
        audio = GetComponent<AudioSource>();
    }

    IEnumerator Victori()
    {
        yield return new WaitForSeconds(2f);
        audio.clip = ganaste;
        audio.Play();
    }
}