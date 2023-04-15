using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSound : MonoBehaviour
{
    public AudioClip[] _clip;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.relativeVelocity.magnitude>5f){
            AudioClip clip = _clip[UnityEngine.Random.Range(0, _clip.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
