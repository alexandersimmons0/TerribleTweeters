using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterBehaviour : MonoBehaviour
{
    public Sprite deadSprite;
    public ParticleSystem deathParticle;
    public float delay;
    private bool hasDied;
    private SpriteRenderer monsterSprite;
    void Start(){
        monsterSprite = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(ShouldDieFromCollision(collision)){
           StartCoroutine(Die());
        }
    }
    IEnumerator Die(){
        monsterSprite.sprite = deadSprite;
        deathParticle.Play();
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
