using UnityEngine;
using System.Collections;
using TMPro;

public class Player : MonoBehaviour
{
    public float vida = 100f;
    private Animator animator;
    private bool estaMorto = false;
    public TextMeshProUGUI textoVida; // arraste o objeto VidaText aqui no Inspector

    void Start()
    {
        animator = GetComponent<Animator>();
        AtualizarTextoVida();
    }

    public void TomarDano(float dano)
    {
        if (estaMorto) return;

        vida -= dano;
        vida = Mathf.Clamp(vida, 0, 100); // evita valores negativos
        AtualizarTextoVida();

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void AtualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vida.ToString("0");
        }
    }

    void Morrer()
    {
        estaMorto = true;
        Debug.Log("Player morreu!");

        // Desativa física e colisão
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = false;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        // Toca animação de morte
        if (animator != null)
        {
            animator.SetTrigger("Morrer");
            // Inicia Coroutine para aguardar a animação antes do GameOver
            StartCoroutine(AguardarAnimacaoAntesDeGameOver());
        }
        else
        {
            // Caso não tenha Animator
            FindFirstObjectByType<GameManager>().GameOver();
        }
    }

    IEnumerator AguardarAnimacaoAntesDeGameOver()
    {
        // Aguarda o tempo da animação de morte
        AnimatorStateInfo estado = animator.GetCurrentAnimatorStateInfo(0);
        

        
        float duracaoAnimacao = 3f;

        yield return new WaitForSeconds(duracaoAnimacao);

        FindFirstObjectByType<GameManager>().GameOver();
    }
}
