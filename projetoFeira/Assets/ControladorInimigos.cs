using UnityEngine;
using System.Collections.Generic;

public class ControladorInimigos : MonoBehaviour
{
    public GameObject[] inimigosPrefabs; // Array com todos os prefabs de inimigos
    public float velocidadeInimigos = 5f; // Velocidade dos inimigos
    public float intervaloGeracao = 2f; // Intervalo entre a geração de inimigos
    public float distanciaMinima = 3f; // Distância mínima entre inimigos

    private List<GameObject> inimigosAtivos = new List<GameObject>();
    private float tempoUltimaGeracao = 0f;
    private float limiteDestruicao; // Limite para destruir inimigos que saíram da tela

    void Start()
    {
        // Calcular o limite de destruição (fora da tela à esquerda)
        limiteDestruicao = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - 2f;
    }

    void Update()
    {
        // Gerar inimigos em intervalos regulares
        if (Time.time - tempoUltimaGeracao > intervaloGeracao)
        {
            GerarInimigo();
            tempoUltimaGeracao = Time.time;
        }

        // Mover inimigos e destruir os que saíram da tela
        MoverInimigos();
    }

    void GerarInimigo()
    {
        // Escolher aleatoriamente um inimigo para gerar
        int indexInimigo = Random.Range(0, inimigosPrefabs.Length);
        GameObject novoInimigo = Instantiate(inimigosPrefabs[indexInimigo]);

        // Posicionar o inimigo fora da tela à direita
        float posicaoY = -2f; // Ajuste conforme necessário para seu jogo
        float posicaoX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 2f;
        novoInimigo.transform.position = new Vector3(posicaoX, posicaoY, 0);

        // Adicionar à lista de inimigos ativos
        inimigosAtivos.Add(novoInimigo);
    }

    void MoverInimigos()
    {
        // Mover todos os inimigos para a esquerda
        for (int i = inimigosAtivos.Count - 1; i >= 0; i--)
        {
            if (inimigosAtivos[i] != null)
            {
                // Mover o inimigo
                inimigosAtivos[i].transform.Translate(Vector3.left * velocidadeInimigos * Time.deltaTime);

                // Verificar se saiu da tela e destruir
                if (inimigosAtivos[i].transform.position.x < limiteDestruicao)
                {
                    Destroy(inimigosAtivos[i]);
                    inimigosAtivos.RemoveAt(i);
                }
            }
            else
            {
                inimigosAtivos.RemoveAt(i);
            }
        }

        // Aumentar gradualmente a dificuldade
        velocidadeInimigos += 0.01f * Time.deltaTime;
    }
}