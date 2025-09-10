using UnityEngine;

public class ControladorCangaceiro : MonoBehaviour
{
    public float forcaPulo = 7f; // Força do pulo do cangaceiro
    private Rigidbody2D rb;
    private bool noChao = false;
    private Animator animator;

    void Start()
    {
        // Obter componentes
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Iniciar animação de corrida
        animator.SetBool("Correndo", true);
    }

    void Update()
    {
        // Verificar se o jogador pressionou a tecla de pulo (Espaço ou clique)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && noChao)
        {
            Pular();
        }
    }

    void Pular()
    {
        // Aplicar força para cima para simular o pulo
        rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
        noChao = false;
        animator.SetBool("NoChao", false);
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        // Verificar se o cangaceiro está no chão
        if (colisao.gameObject.CompareTag("Chao"))
        {
            noChao = true;
            animator.SetBool("NoChao", true);
        }

        // Verificar colisão com inimigos
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