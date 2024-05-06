using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [Header("Configura��o UI")]
    public int    _pontosPlayer;
    public Text   _txtPontos;
    public int    _vidasPlayer;
    public Text   _txtvidas;

    [Header("Configura��o da Moeda")]
    public GameObject _coinPrefab;  // Prefab da moeda

    // Limites para spawn das moedas
    private float minX = -18f;  // Limite m�nimo do eixo X
    private float maxX = 16f;   // Limite m�ximo do eixo X
    private float minY = -1.6f;  // Limite m�nimo do eixo Y
    private float maxY = 8.0f;   // Limite m�ximo do eixo Y

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoin());  // Inicia a rotina de spawn de moedas
        
        Time.timeScale = 1f;
        Debug.Log("Cena iniciada. Time.timeScale: " + Time.timeScale);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCoin()
    {
        while (true)  // Loop infinito para continuar spawnando moedas
        {
            int moedasAleatorias = 1;  // Quantidade aleat�ria de moedas para spawnar
            for (int contagem = 1; contagem <= moedasAleatorias; contagem++)
            {
                // Instancia uma nova moeda
                GameObject _objetoSpawn = Instantiate(_coinPrefab);

                // Gera posi��o aleat�ria dentro dos limites definidos
                float randomX = Random.Range(minX, maxX);
                float randomY = Random.Range(minY, maxY);

                // Define a posi��o da moeda
                _objetoSpawn.transform.position = new Vector3(randomX, randomY, 0);
            }
            yield return new WaitForSeconds(10f);  // Espera 10 segundos antes de iniciar o pr�ximo ciclo de spawn
        }
    }

    public void Pontos(int _qtdPontos)
    {
        _pontosPlayer += _qtdPontos;
        _txtPontos.text = _pontosPlayer.ToString();
    }


}
