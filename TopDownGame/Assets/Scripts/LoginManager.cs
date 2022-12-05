using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoginManager : MonoBehaviour
{

    [SerializeField]
    private InputField usuarioField = null;
    [SerializeField]
    private InputField senhaField = null;
    [SerializeField]
    private Text feedBackMsg = null;
    //[SerializeField]
    //private Toggle rememberData = null;

    private string url = "http://localhost/login/login.php";

    void Start()
    {
        /*if(PlayerPrefs.HasKey("lembrar") && PlayerPrefs.GetInt("lembrar") == 1)
        {
            usuarioField.text = PlayerPrefs.GetString("rememberUser");
            senhaField.text = PlayerPrefs.GetString("rememberSenha");
        }*/
    }

    public void FazerLogin()
    {
        if(usuarioField.text == "" || senhaField.text == "")
        {
            FeedBackError("Preencha todos os campos.");

        }else{
            string usuario = usuarioField.text;
            string senha = senhaField.text;

        /*if(rememberData.isOn)
        {
            PlayerPrefs.SetInt("lembrar",1);
            PlayerPrefs.SetString("rememberUser",usuario);
            PlayerPrefs.SetString("rememberSenha",senha);
        }*/

            /*if(usuario == Login && senha == Pass) 
            {
                FeedBackOk("Login realizado com sucesso!");
                StartCoroutine(CarregandoCena());

            }else{
                FeedBackError("Nickname ou Senha inválidos.");
            }*/

            UnityWebRequest www = new UnityWebRequest(url + "?login=" + usuario + "&senha=" + senha); //http://localhost/login/login.php?login=xxxx&senha=xxxx
            StartCoroutine(ValidaLogin(www));
        }
    }

    IEnumerator ValidaLogin(UnityWebRequest www)
    {
        yield return www;
        if(www.error == null){
            if(www.downloadHandler.text == "1")
            {
                FeedBackOk("Login realizado com sucesso!\nCarregando jogo...");
                StartCoroutine(CarregandoCena());
            }else{
                FeedBackError("Usuário ou Senha inválidos");
            }

        }else{
            if(www.error == "couldn't connect to host")
            {
                FeedBackError("Servidor indisponível.");
            }
        }
    }

    IEnumerator CarregandoCena()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Inicio");
    }

    void FeedBackOk(string mensagem)
    {
        feedBackMsg.CrossFadeAlpha(100f, 0f, false);
        feedBackMsg.color = Color.green;
        feedBackMsg.text = mensagem;
    }
    void FeedBackError(string mensagem)
    {
        feedBackMsg.CrossFadeAlpha(100f, 1f, false);
        feedBackMsg.color = Color.red;
        feedBackMsg.text = mensagem;
        feedBackMsg.CrossFadeAlpha(0f,2f,false);
        usuarioField.text = "";
        senhaField.text = "";
    }
}
