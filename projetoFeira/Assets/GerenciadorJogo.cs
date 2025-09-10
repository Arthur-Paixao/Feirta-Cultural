using UnityEngine;
using UnityEngine.UI;

public class GerenciadorJogo : MonoBehaviour
{
    public static GerenciadorJogo Instancia;
    public Text textoPontuacao;
    private int pontuacao = 0;
    private float tempoPontuacao = 0f;
    public float intervaloPontuacao = 0.1f; // Intervalo para aumentar a pontuação

    void Awake()
    {
        // Configurar instância singleton
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Aumentar pontuação com o tempo
        tempoPontuacao += Time.deltaTime;
        if (tempoPontuacao >= intervaloPontuacao)
        {
            pontuacao += 1;
            tempoPontuacao = 0f;
            AtualizarPontuacao();
        }
    }

    void AtualizarPontuacao()
    {
        // Atualizar texto da pontuação
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontos: " + pontuacao.ToString();
        }
    }

    public void GameOver()
    {
        // Voltar para o menu quando o jogador morrer
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }
}