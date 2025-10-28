using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Tela de Game Over")]
    public GameObject gameOverUI;

    [Header("Pontuação")]
    public TextMeshProUGUI textoPontuacao;
    public float pontuacao = 0f;
    public float velocidadePontuacao = 10f; // pontos por segundo
    private bool jogoAtivo = true;

    void Start()
    {
        Time.timeScale = 1f; // garante que o tempo começa normal
        jogoAtivo = true;
        pontuacao = 0f;
        AtualizarTextoPontuacao();
    }

    void Update()
    {
        if (jogoAtivo)
        {
            pontuacao += velocidadePontuacao * Time.deltaTime;
            AtualizarTextoPontuacao();
        }
    }

    void AtualizarTextoPontuacao()
    {
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontos: " + Mathf.FloorToInt(pontuacao).ToString("00000");
        }
    }

    public void GameOver()
    {
        if (!jogoAtivo) return; // evita chamar duas vezes
        jogoAtivo = false;

        // Primeiro mostra o painel
        gameOverUI.SetActive(true);

        // Depois pausa o jogo (um pequeno delay ajuda a garantir que a UI renderize)
        StartCoroutine(PausarJogo());
    }

    System.Collections.IEnumerator PausarJogo()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        Time.timeScale = 0f;
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
