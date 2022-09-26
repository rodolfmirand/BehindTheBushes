using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jersoButton : MonoBehaviour
{
    public GameObject imagem;
    public AudioSource som;

    void Start()
    {
        imagem.SetActive(false);
    }

    public void ativarQuack()
    {
        StartCoroutine(Quack());
        som.Play();
    }

    public IEnumerator Quack()
    {
        imagem.SetActive(true);
        yield return new WaitForSeconds(2f);
        imagem.SetActive(false);
    }
}
