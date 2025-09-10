using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GerenciadorMenu : MonoBehaviour
{
    public GameObject painelPrincipal;
    public GameObject painelCreditos;
    public Button botaoIniciar;
    public Button botaoCreditos;
    public Button botaoVoltar;

    void Start()
    {
        // Configurar os bot�es e pain�is
        painelPrincipal.SetActive(true);
        painelCreditos.SetActive(false);

        // Adicionar listeners aos bot�es
        botaoIniciar.onClick.AddListener(IniciarJogo);
        botaoCreditos.onClick.AddListener(MostrarCreditos);
        botaoVoltar.onClick.AddListener(VoltarMenu);
    }

    // Inicia o jogo carregando a cena do jogo
    void IniciarJogo()
    {
        SceneManager.LoadScene("Jogo");
    }

    // Mostra o painel de cr�ditos
    void MostrarCreditos()
    {
        painelPrincipal.SetActive(false);
        painelCreditos.SetActive(true);
    }

    // Volta para o menu principal
    void VoltarMenu()
    {
        painelCreditos.SetActive(false);
        painelPrincipal.SetActive(true);
    }
}