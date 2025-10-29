using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Telas")]
    public GameObject gameOverUI;
    public GameObject vitoriaUI; // nova tela de vitória

    [Header("Pontuação")]
    public TextMeshProUGUI textoPontuacao;
    public float pontuacao = 0f;
    public float velocidadePontuacao = 10f;
    private bool jogoAtivo = true;

    void Start()
    {
        Time.timeScale = 1f;
        jogoAtivo = true;
        pontuacao = 0f;
        AtualizarTextoPontuacao();

        if (gameOverUI != null)
            gameOverUI.SetActive(false);
        if (vitoriaUI != null)
            vitoriaUI.SetActive(false);
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
            textoPontuacao.text = "Pontos: " + Mathf.FloorToInt(pontuacao).ToString("00000");
    }

    public void GameOver()
    {
        if (!jogoAtivo) return;
        jogoAtivo = false;
        StartCoroutine(MostrarPainel(gameOverUI));
    }

    public void Vitoria()
    {
        if (!jogoAtivo) return;
        jogoAtivo = false;
        StartCoroutine(MostrarPainel(vitoriaUI));
    }

    System.Collections.IEnumerator MostrarPainel(GameObject painel)
    {
        if (painel != null)
            painel.SetActive(true);

        yield return new WaitForEndOfFrame();
        Time.timeScale = 0f;
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
