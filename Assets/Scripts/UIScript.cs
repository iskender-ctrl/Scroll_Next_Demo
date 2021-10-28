using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public GameObject uıPanel, uıLosePanel, winPanel;
    Animator anim;
    GameObject enemyControl;
    void Start()
    {
        uıPanel.SetActive(true);
        enemyControl = GameObject.FindGameObjectWithTag("Player");
        //anim = GameObject.FindGameObjectWithTag("Cursor").GetComponent<Animator>();
        Time.timeScale = 0;
    }
    void Update()
    {
        
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        uıPanel.SetActive(false);
    }
    public void PlayAgainLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void PlayAgainLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void PlayAgainLevel3()
    {
        SceneManager.LoadScene("FinalLevel");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void NextLevel1()
    {
        SceneManager.LoadScene("FinalLevel");
    }
    
}
