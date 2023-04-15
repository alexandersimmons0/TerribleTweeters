using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineBehaviour : MonoBehaviour
{
    public GameObject player;
    private Bird bird;
    private Vector3 currentLocation;
    private LineRenderer lineRend;
    void Start(){
        bird = FindObjectOfType<Bird>();
        lineRend = GetComponent<LineRenderer>();
        currentLocation = new Vector3(player.transform.position.x,player.transform.position.y,-0.1f);
        lineRend.SetPosition(0, currentLocation);
    }
    void Update(){
        if(bird.isDragging){
            lineRend.enabled = true;
            lineRend.SetPosition(1, player.transform.position);
        }else{
            lineRend.enabled = false;
        }
    }
}
