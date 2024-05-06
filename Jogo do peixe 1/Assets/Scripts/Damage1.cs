using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage1 : MonoBehaviour
{

    private Rigidbody2D obstaculoRB;
    private GameController _gameController;
    private ControleDoJogador _controleDoJogador;
    private SpriteRenderer srPlayer;
    private Segundos _segundos;


    public float invulnerabilityTime = 1.0f; // Tempo de invulnerabilidade em segundos
    private float lastHitTime;

    private float lastFoodTime;


    // Start is called before the first frame update
    void Start()
    {
        obstaculoRB = GetComponent<Rigidbody2D>();
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        _controleDoJogador = FindObjectOfType(typeof(ControleDoJogador)) as ControleDoJogador;
        srPlayer = GetComponent<SpriteRenderer>();
        _segundos = FindObjectOfType(typeof(Segundos)) as Segundos;



        lastHitTime = Time.time - invulnerabilityTime; // Garante que o jogador possa ser atingido imediatamente no início do jogo
        lastFoodTime = Time.time;  // Inicializa o cooldown de comida

    }

    // Update is called once per frame
    void Update()
    {
        if(_gameController._pontosPlayer == 5)
        {
            _controleDoJogador.GameVitoria();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _controleDoJogador.GamePause();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "inimigo")
        {
            if(Time.time > lastHitTime + invulnerabilityTime)
            {
                lastHitTime = Time.time;
                _gameController._vidasPlayer--;
                UpdateLifeUI();
                StartCoroutine("Dano");
            }

            

            if (_gameController._vidasPlayer <= 0)
            {
                Debug.Log("Fim do Jogo");
                _gameController._txtvidas.text = "0";
                _controleDoJogador.velocidadeDoPolvo = 0;
                _controleDoJogador.ExecutarAnimacaoMorte();
                Invoke("GameOver", 3f);
                
            }
            else
            {
                _gameController._txtvidas.text = _gameController._vidasPlayer.ToString();
                Debug.Log("Perdeu uma vida!");
            }
            
        }
        if (collision.tag == "comida" && Time.time > lastFoodTime + 0.5f) // Cooldown de 0.5 segundos
        {
            lastFoodTime = Time.time;
            Destroy(collision.gameObject);
            _gameController._vidasPlayer++;
            UpdateLifeUI();
            Debug.Log("Ganhou uma vida! Vidas agora: " + _gameController._vidasPlayer);
        }
    }
    IEnumerator Dano()
    {
        for(float i =0; i<1; i += 0.1f)
        {
                srPlayer.enabled = false;
                yield return new WaitForSeconds(0.1f);
                srPlayer.enabled = true;
                yield return new WaitForSeconds(0.1f);
        }
    }
    
    void CarregaoJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        _controleDoJogador.GameOver();
    }

    private void UpdateLifeUI()
    {
        _gameController._txtvidas.text = _gameController._vidasPlayer.ToString();
    }
}
