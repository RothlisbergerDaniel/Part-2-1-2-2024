using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1); //load Game scene
    }
}
