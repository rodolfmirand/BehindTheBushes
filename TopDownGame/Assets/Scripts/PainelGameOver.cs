using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PainelGameOver : MonoBehaviour
{
    public GameObject telaGameOver;
    public AudioSource morrendo;
    public bool morreu = true;

    private void Update() {
        if(telaGameOver.activeInHierarchy && morreu == true)
        {
            morrendo.Play();
            morreu = false;
            //Debug.Log("Morreu");
        }
    }
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
        Debug.Log("Saiu");
    }
}
