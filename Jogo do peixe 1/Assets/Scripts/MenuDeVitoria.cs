using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDeVitoria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReiniciarPartida1()
    {
        SceneManager.LoadScene("Nivel_01");
        Time.timeScale = 1f; // Isso garante que o tempo volte ao normal caso esteja pausado
    }

    public void SairDoJogo1()
    {
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }
}
