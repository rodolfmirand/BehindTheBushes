using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{

    private const string Login = "Rodolfo";
    private const string Pass = "102030";

    [SerializeField]
    private InputField usuarioField = null;
    [SerializeField]
    private InputField senhaField = null;
    [SerializeField]
    private Text feedBackMsg = null;
    [SerializeField]
    private Toggle rememberData = null;

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
        string usuario = usuarioField.text;
        string senha = senhaField.text;

        /*if(rememberData.isOn)
        {
            PlayerPrefs.SetInt("lembrar",1);
            PlayerPrefs.SetString("rememberUser",usuario);
            PlayerPrefs.SetString("rememberSenha",senha);
        }*/

        if(usuario == Login && senha == Pass) 
        {
            feedBackMsg.CrossFadeAlpha(100f, 0f, false);
            feedBackMsg.color = Color.green;
            feedBackMsg.text = "Login realizado com sucesso!\nCarregando jogo...";
            StartCoroutine(CarregandoCena());

        }else{
            feedBackMsg.CrossFadeAlpha(100f, 0f, false);
            feedBackMsg.color = Color.red;
            feedBackMsg.text = "Nickname ou Senha inválidos.";
            feedBackMsg.CrossFadeAlpha(0f,2f,false);
            usuarioField.text = "";
            senhaField.text = "";
        }
        
    }

    IEnumerator CarregandoCena()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Inicio");
    }
}
