using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private SpriteRenderer rend;
    private Rigidbody2D rigid;
    private Vector2 startPosition;
    public float speed;
    public int birdCounter;
    public float maxDragDis;
    public float timeDelay;
    public bool isDragging;
    public bool birdThrown;
    private AudioSource soundEffect;
    private bool hit;
    void Awake(){
        rend = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();    
        soundEffect = GetComponent<AudioSource>();    
    }
    void Start(){
        hit = false;
        rigid.isKinematic = true;
        startPosition = rigid.position;
    }
    void OnMouseDown(){
        rend.color = Color.blue;
        isDragging = true;
    }
    void OnMouseUp(){
        soundEffect.Play();
        isDragging = false;
        Vector2 currentPos = rigid.position;
        Vector2 dir = startPosition - currentPos;
        dir.Normalize();
        rigid.isKinematic = false;
        rigid.AddForce(dir * speed);
        birdThrown = true;
        rend.color = Color.white;
    }
    void OnMouseDrag(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;
        float distance = Vector2.Distance(desiredPosition, startPosition);
        if(distance > maxDragDis){
            Vector2 direction = desiredPosition - startPosition;
            direction.Normalize();
            desiredPosition = startPosition + (direction * maxDragDis);
        }
        if(desiredPosition.x > startPosition.x){
            desiredPosition.x = startPosition.x;
        }
        rigid.position = desiredPosition;
    }
    void OnCollisionEnter2D(Collision2D collision){
        hit = true;
        StartCoroutine(ResetAfterDelay());
    }
    IEnumerator ResetAfterDelay(){
        yield return new WaitForSeconds(3);
        rigid.isKinematic = true;
        transform.position = startPosition;
        rigid.velocity = Vector2.zero;
        if(hit){
            birdCounter--;
            hit = false;
        }
    }
    void Update(){

    }
}
