using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterBehaviour : MonoBehaviour
{
    public Sprite deadSprite;
    public ParticleSystem deathParticle;
    public float delay;
    public AudioClip[] clipArray;
    private bool hasDied;
    private AudioSource audios;
    private SpriteRenderer monsterSprite;
    IEnumerator Start(){
        monsterSprite = GetComponent<SpriteRenderer>();
        audios = GetComponent<AudioSource>();
        while(!hasDied){
            float delay = UnityEngine.Random.Range(5,30);
            yield return new WaitForSeconds(delay);
            if(!hasDied){
                audios.PlayOneShot(clipArray[0]);
            }
        }
    }
    void OnMouseDown(){
        audios.PlayOneShot(clipArray[1]);
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(ShouldDieFromCollision(collision)){
           StartCoroutine(Die());
        }
    }
    IEnumerator Die(){
        monsterSprite.sprite = deadSprite;
        deathParticle.Play();
        audios.PlayOneShot(clipArray[2]);
        hasDied = true;
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
    bool ShouldDieFromCollision(Collision2D collision){
        if(hasDied){
            return false;
        }
        if(collision.gameObject.tag=="Player" || collision.contacts[0].normal.y < -0.5){
            return true;
        }
        return false;
    }
}
