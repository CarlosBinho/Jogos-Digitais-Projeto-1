using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    private ControleDoJogador _controleDoJogador;
    // Start is called before the first frame update
    void Start()
    {
        _controleDoJogador = FindObjectOfType(typeof(ControleDoJogador)) as ControleDoJogador;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VoltarGame()
    {
        _controleDoJogador.painelDePausa.SetActive(false);
        Time.timeScale = 1f; 
        Debug.Log("Jogo Despausado");
    }

    public void SairDoJogo2()
    {
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }
}
