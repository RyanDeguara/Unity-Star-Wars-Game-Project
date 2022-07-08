using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSound : MonoBehaviour
{
    void OnTriggerEnter()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
}
