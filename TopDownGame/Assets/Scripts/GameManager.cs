using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject painelGameOver;
    public GameObject painelPause;

    public Text txtPontuacaoAtual;
    public Text txtPontuacaoFinal;
    public Text highScore;

    public int pontuacaoAtual;

    private bool isPaused;

    void Awake(){

        instance = this;
    }


    void Start()
    {
        Time.timeScale = 1f;

        pontuacaoAtual = 0;
        txtPontuacaoAtual.text = "PONTUAÇÂO: " + pontuacaoAtual;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
    }

    public void AumentarPontuacao(){

        pontuacaoAtual++;
        txtPontuacaoAtual.text = "PONTUAÇÂO: "+pontuacaoAtual;
    }

    public void GameOver(){
        Time.timeScale = 0f;

        painelGameOver.SetActive(true);

        txtPontuacaoFinal.text = ""+pontuacaoAtual;

        if(pontuacaoAtual > PlayerPrefs.GetInt("HighScore")){

            PlayerPrefs.SetInt("HighScore",pontuacaoAtual);
        }

        highScore.text = ""+ PlayerPrefs.GetInt("HighScore");
    }

    public void PauseScreen()
    {
        if(isPaused)
        {   
            isPaused = false;
            Time.timeScale = 1f;
            painelPause.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            painelPause.SetActive(true);
        }
    }
}
