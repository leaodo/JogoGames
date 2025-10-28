using UnityEngine;

public class Pocao : MonoBehaviour
{
    public float cura = 1f; // quanto de vida vai curar
    public AudioClip somColeta; // opcional

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se quem tocou é o player
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.Curar(cura);

            // Tocar som de cura (opcional)
            if (somColeta != null)
                AudioSource.PlayClipAtPoint(somColeta, transform.position);

            // Destroi a poção após ser coletada
            Destroy(gameObject);
        }
    }
}
