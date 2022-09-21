using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamerManager2 : MonoBehaviour
{
    public void IniciarJogo(){
        SceneManager.LoadScene("Jogo");
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
