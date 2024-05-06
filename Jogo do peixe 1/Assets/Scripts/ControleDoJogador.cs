using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleDoJogador : MonoBehaviour
{
    public Rigidbody2D oRigidboody2D;
    private Animator   _playerAnimator;
    public float       velocidadeDoPolvo;
    private float      _playerInitialSpeed;
    public float       _playerRunSpeed;
    private Vector2    teclasApertadas;
    private bool       _isAttack = false;
    private bool       _movimentoParado = true;
    public GameObject painelDeGameOver;
    private GameController _gameController;
    public GameObject painelDeVitoria;
    public GameObject painelDePausa;
    public Text textoDePontuação;
    public Text textoDeTempo;
    public Text textoDePontuação2;
    public Text textoDeTempo2;
    public Text textoDePontuaçãoPausa;
    public Text textoDeTempoPausa;
    private Segundos _segundos;
 


    // Start is called before the first frame update
    void Start()
    {
        oRigidboody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerInitialSpeed = velocidadeDoPolvo;
        _gameController = FindObjectOfType(typeof(GameController)) as GameController;
        _segundos = FindObjectOfType(typeof(Segundos)) as Segundos;
    }

    // Update is called once per frame
    void Update()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (teclasApertadas.sqrMagnitude > 0)
        {
            _playerAnimator.SetInteger("Walk", 1);
            _playerAnimator.SetInteger("Idle", 0);
        }
        else
        {
            if (_movimentoParado == true)
            {
                _playerAnimator.SetInteger("Idle", 1);
                _playerAnimator.SetInteger("Walk", 0);
                
            }
        }

        Flip();

        PlayerRun();

        OnAttack();

        if(_isAttack == true)
        {
            _playerAnimator.SetInteger("Attack", 1);
            _playerAnimator.SetInteger("Walk", 0);
            _playerAnimator.SetInteger("Idle", 0);
            
        }
        if(_isAttack == false)
        {
            _playerAnimator.SetInteger("Attack", 0);

        }


    }

    void FixedUpdate()
    {
        oRigidboody2D.MovePosition(oRigidboody2D.position + teclasApertadas.normalized * velocidadeDoPolvo * Time.fixedDeltaTime);
    }

   void Flip()
    {
        if(teclasApertadas.x > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        else if (teclasApertadas.x < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

   void PlayerRun()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            velocidadeDoPolvo = _playerRunSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            // Só reduz a velocidade se todas as teclas e o mouse estiverem soltos
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.Space) && !Input.GetMouseButton(0))
            {
                velocidadeDoPolvo = _playerInitialSpeed;
            }
        }
    }

    void OnAttack()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _isAttack = true;
            velocidadeDoPolvo = 0;
        }

        if(Input.GetMouseButtonUp(1))
        {
            _isAttack = false;
            velocidadeDoPolvo = _playerInitialSpeed;

        }
    }

    public void ExecutarAnimacaoMorte()
    {
        Debug.Log("Executando animação de morte");
        _movimentoParado = false;
        _playerRunSpeed = 0;
        _playerAnimator.SetInteger("Die", 1);
        _playerAnimator.SetInteger("Attack", 0);
        _playerAnimator.SetInteger("Walk", 0);
        _playerAnimator.SetInteger("Idle", 0);
        //_playerAnimator.SetInteger("Hurt", 0);

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        painelDeGameOver.SetActive(true);
        //painelDeVitoria.SetActive(false);
        textoDePontuação.text = "Pontuação: " + _gameController._pontosPlayer;
        textoDeTempo.text = "Tempo: " + _segundos.timeRemaining.ToString("F2");
        Debug.Log("Game Over");
    }

    public void GameVitoria()
    {
        Time.timeScale = 0f;
        painelDeVitoria.SetActive(true);
        //painelDeGameOver.SetActive(false);
        textoDePontuação2.text = "Pontuação: " + _gameController._pontosPlayer;
        textoDeTempo2.text = "Tempo: " + _segundos.timeRemaining.ToString("F2");
        //Debug.Log("Você Venceu!");
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
        painelDePausa.SetActive(true);
        //painelDeGameOver.SetActive(false);
        textoDePontuaçãoPausa.text = "Pontuação: " + _gameController._pontosPlayer;
        textoDeTempoPausa.text = "Tempo: " + _segundos.timeRemaining.ToString("F2");
        Debug.Log("Jogo Pausado");
    }

    
}
