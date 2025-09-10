using UnityEngine;

public class ControladorCangaceiro : MonoBehaviour
{
    public float forcaPulo = 7f; // For�a do pulo do cangaceiro
    private Rigidbody2D rb;
    private bool noChao = false;
    private Animator animator;

    void Start()
    {
        // Obter componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Iniciar anima��o de corrida
        animator.SetBool("Correndo", true);
    }

    void Update()
    {
        // Verificar se o jogador pressionou a tecla de pulo (Espa�o ou clique)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && noChao)
        {
            Pular();
        }
    }

    void Pular()
    {
        // Aplicar for�a para cima para simular o pulo
        rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
        noChao = false;
        animator.SetBool("NoChao", false);
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        // Verificar se o cangaceiro est� no ch�o
        if (colisao.gameObject.CompareTag("Chao"))
        {
            noChao = true;
            animator.SetBool("NoChao", true);
        }

        // Verificar colis�o com inimigos
        if (colisao.gameObject.CompareTag("Inimigo"))
        {
            Morrer();
        }
    }

    void Morrer()
    {
        // Parar o jogo e voltar para o menu
        Time.timeScale = 0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }
}