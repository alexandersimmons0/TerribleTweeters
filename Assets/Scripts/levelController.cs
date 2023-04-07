using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    private monsterBehaviour[] monsters;
    public string nextLevelName;
    void OnEnable(){
        monsters = FindObjectsOfType<monsterBehaviour>();
    }
    void Update(){
        if(MonstersAllDead()){
            GoToNextLevel();
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
