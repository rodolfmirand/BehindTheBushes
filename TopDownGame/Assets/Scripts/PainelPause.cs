using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelPause : MonoBehaviour
{
    public GameManager gameManager;

    public void Resume()
    {
        gameManager.PauseScreen();
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
        Debug.Log("Saiu");
    }
}
