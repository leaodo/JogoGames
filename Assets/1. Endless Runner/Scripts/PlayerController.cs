using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float velocidade = 3f;
    private Vector3 posicaoInicial;
    private Rigidbody2D rb;
    private Animator animator;
    private bool estaNoChao = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        // Quando apertar espaço e estiver no chão, pula
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
        {
            Impulsionar();
        }
    }

    private void Impulsionar()
    {
        // Zera a velocidade antes de aplicar o impulso
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * velocidade, ForceMode2D.Impulse);

        // Toca a animação de pulo
        animator.SetTrigger("Pular");

        // Marca que está no ar
        estaNoChao = false;
    }

    private void OnCollisionEnter2D(Collision2D colisao)
{
    if (colisao.gameObject.CompareTag("Chao"))
    {
        estaNoChao = true;

        // Força o retorno à animação de Idle
        animator.ResetTrigger("Pular");
        animator.Play("Andar"); // nome exato do estado Idle no Animator
    }
}

}
