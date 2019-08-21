using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{


    [SerializeField]
    private GameObject pausePanel;



    void Awake()
    {
        pausePanel.SetActive(false);
    }


    public void Pausegame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);


    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Start screen");


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
