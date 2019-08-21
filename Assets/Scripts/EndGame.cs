using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour

{

 public Text mTextScore = null;
public void AgainMenu()
    {
        Application.LoadLevel("Start screen");

    }

    private void Update()
    {
        mTextScore.text = "Your Final Score : " + MatrixGrid.returnPlayerScore().ToString();
    }
}
