using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameOver()
    {
        // Mostrar a tela de Game Over
        gameOverUI.SetActive(true);

        // Pausar o jogo
        Time.timeScale = 0f;
    }

    public void ReiniciarJogo()
    {
        // Despausar
        Time.timeScale = 1f;

        // Recarregar a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
