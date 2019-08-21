using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    

    public GameObject[] TetrisObjects;
    public RectTransform mPanelGameOver;
    public Text mTxtGameOver = null;
    public Text dynamicScore= null;
    public Text mTextScore = null;
    public Text  ll= null;






    public void spawnRandom()
    {
        int i = Random.Range(0, TetrisObjects.Length);

        Instantiate(TetrisObjects[i],
                   transform.position,
                   Quaternion.identity);


    }

    void Start()
    {
        spawnRandom();

    }
    void Update()
    {
        dynamicScore.text = "Your Current Score : " + MatrixGrid.returnPlayerScore().ToString();
        if (TetrisObject.IsGameOver())
        {

            Application.LoadLevel("End screen");
           
        }
    }

}
