using UnityEngine;

public class Player : MonoBehaviour
{
    public float vida = 100f;
    private Animator animator;
    private bool estaMorto = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDano(float dano)
    {
        if (estaMorto) return; 

        vida -= dano;
        Debug.Log("Player levou dano! Vida atual: " + vida);

        if (vida <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        estaMorto = true;
        Debug.Log("Player morreu!");

        if (animator != null)
        {
            animator.SetTrigger("Morrer");
        }

        
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Collider2D>().enabled = false;

        
    }
}
