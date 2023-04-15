using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseUI;
    public GameObject resumeButton;
    public GameObject loseText;
    private Bird bird;
    public GameObject nextLevelButton;
    public GameObject winText;
    private levelController levels;
    private bool loseScreen;
    void Start(){
        pauseUI.SetActive(false);
        loseScreen = false;
        bird = GameObject.Find("redBird").GetComponent<Bird>();
        levels = GameObject.Find("levelControl").GetComponent<levelController>();
        Resume();
    }
    void Update(){
        if(!loseScreen||!levels.win){
            if(Input.GetKeyUp(KeyCode.Tab)){
                if(gameIsPaused){
                    Resume();
                }else{
                    Pause();
                }
            }
        }
        if(bird.birdCounter == 0&&!levels.win){
            loseScreen = true;
            Pause();
        }else if(levels.win){
            Pause();
        }
    }
    public void Resume(){
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause(){
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        nextLevelButton.SetActive(false);
        if(loseScreen){
            loseText.SetActive(true);
            winText.SetActive(false);
            resumeButton.SetActive(false);
        }else if(levels.win){
            loseText.SetActive(false);
            winText.SetActive(true);
            resumeButton.SetActive(false);
            nextLevelButton.SetActive(true);
        }else{
            loseText.SetActive(false);
            winText.SetActive(false);
            resumeButton.SetActive(true);
        }
    }
}
