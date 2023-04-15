using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelController : MonoBehaviour
{
    private monsterBehaviour[] monsters;
    private bool pause;
    public string nextLevelName;
    public bool win;
    private Bird bird;
    //public GameObject birdLifeOG;
    public List<GameObject> birdLife;
    void Start(){
        bird = GameObject.Find("redBird").GetComponent<Bird>();
        win = false;
    }
    void OnEnable(){
        monsters = FindObjectsOfType<monsterBehaviour>();
    }
    void Update(){
        if(bird.birdThrown){
            birdLife[bird.birdCounter-1].SetActive(false);
            bird.birdThrown = false;
            //bird.birdCounter--;
        }
        if(MonstersAllDead()){
            win = true;
        }
    }
    bool MonstersAllDead(){
        foreach(var monsterBehaviour in monsters){
            if(monsterBehaviour.gameObject.activeSelf){
                return false;
            }
        }
        return true;
    }
    void GoToNextLevel(){
        SceneManager.LoadScene(nextLevelName);
    }
}
