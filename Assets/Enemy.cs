using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string nome;
    public float speed;
    public float vida;
    public float maxVida;
    public Transform target;
    public float dano = 10f; 

    void Start()
    {
        vida = maxVida;
        Introduction();
    }

    protected virtual void Introduction()
    {
        Debug.Log("Meu nome é " + nome + ", minha vida é " + vida + " e o máximo da vida é " + maxVida);
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void Update()
    {
        Move();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TomarDano(dano);
            }
        }
    }
}
