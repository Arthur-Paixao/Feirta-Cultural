using UnityEngine;

public class ControladorCenario : MonoBehaviour
{
    public float velocidadeRolagem = 5f; // Velocidade de rolagem do cenário
    public Renderer[] planosFundos; // Array com os renderers dos planos de fundo (para parallax)
    public float[] fatoresParallax; // Fatores de parallax para cada plano

    void Update()
    {
        // Mover o cenário para criar ilusão de movimento
        MoverCenario();
    }

    void MoverCenario()
    {
        // Rolagem simples para objetos não parallax
        transform.Translate(Vector3.left * velocidadeRolagem * Time.deltaTime);

        // Aplicar efeito parallax se configurado
        if (planosFundos != null && planosFundos.Length > 0)
        {
            for (int i = 0; i < planosFundos.Length; i++)
            {
                if (i < fatoresParallax.Length)
                {
                    float offset = Time.time * velocidadeRolagem * fatoresParallax[i] / 100f;
                    planosFundos[i].material.mainTextureOffset = new Vector2(offset, 0);
                }
            }
        }

        // Aumentar gradualmente a velocidade
        velocidadeRolagem += 0.01f * Time.deltaTime;
    }
}