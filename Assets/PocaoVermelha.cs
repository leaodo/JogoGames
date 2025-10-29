using UnityEngine;

public class PocaoVermelha : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Poção vermelha coletada! Vitória!");
            FindFirstObjectByType<GameManager>().Vitoria();

            Destroy(gameObject);
        }
    }
}
