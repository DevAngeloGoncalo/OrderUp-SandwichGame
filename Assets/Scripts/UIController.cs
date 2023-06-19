using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    [Header("Controllers")]
    public OrderController orderController;
    public ButtonController buttonController;

    [SerializeField]
    [Header("UI Objects")]
    public GameObject hotbar;
    public GameObject endScreen, instructionScreen;
    public GameObject arrowIndicator;

    [SerializeField]
    [Header("Countdown Settings")]
    public float countdownTimeToStart = 3f; 
    public float timerToEnd = 120f;
    public Text countdownToStartText; 
    public Text countdownToEndText; 

    [SerializeField]
    [Space]
    public Text scoreText;
    public Text errorText;

    // Start is called before the first frame update
    void Start()
    {
        arrowIndicator.SetActive(true);
        hotbar.SetActive(false);
        errorText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    // Inicia a contagem regressiva para começar a cena
    private IEnumerator StartCountdownToStartTheScene()
    {
        float currentTime = countdownTimeToStart;

        while (currentTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;

            // Atualiza o texto da contagem regressiva
            countdownToStartText.text = currentTime.ToString();
        }

        // Quando a contagem regressiva terminar, permite iniciar a cena
        countdownToStartText.text = "GO!";

        // Aguarda por mais 1 segundo antes de remover o texto da contagem regressiva
        yield return new WaitForSeconds(1f);
        countdownToStartText.gameObject.SetActive(false);
        hotbar.SetActive(true);

        StartCoroutine(StartCoutdownToEndTheScene());
    }

    // Inicia a contagem regressiva para o fim da partida
    private IEnumerator StartCoutdownToEndTheScene()
    {
        float currentTime = timerToEnd;

        while (currentTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;

            countdownToEndText.text = currentTime.ToString();

            // Desativa o indicador de seta quando o tempo restante for menor ou igual a 100 segundos
            if (currentTime <= 100f) 
            {
                arrowIndicator.SetActive(false);
            }
        }
        // Ativa a tela de fim do jogo
        endScreen.SetActive(true);
        // Exibe a pontuação tota
        scoreText.text = "Total: $ " + orderController.totalValue.ToString("F2", new System.Globalization.CultureInfo("en-US"));
        hotbar.SetActive(false);
    }

    // Sai do jogo
    public void ExitGame()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        Application.Quit();
    }

    // Inicia a cena do jogo
    public void StartScene()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        SceneManager.LoadScene("MainScene"); 
        
    }

    // Fecha as instruções e inicia a contagem regressiva para começar a cena
    public void CloseInstructions()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        instructionScreen.SetActive(false);
        StartCoroutine(StartCountdownToStartTheScene());
    }

    // Exibe uma mensagem de erro no UI
    public void ShowErrorMessage(string message)
    {
        
        errorText.text = message;
        errorText.gameObject.SetActive(true);

        StartCoroutine(HideErrorMessage());
    }

    // Esconde a mensagem de erro
    private IEnumerator HideErrorMessage()
    {
        yield return new WaitForSeconds(2f);
        errorText.gameObject.SetActive(false);
    }
}