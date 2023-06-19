using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public OrderController orderController;
    public ButtonController buttonController;

    public GameObject hotbar;
    public GameObject endScreen, instructionScreen;
    public GameObject arrowIndicator;

    public float countdownTimeToStart = 3f; // Tempo da contagem regressiva em segundos
    public float timerToEnd = 120f;// Tempo da contagem regressiva em segundos para o fim da partida
    public Text countdownToStartText; // Referência ao objeto Text onde o texto da contagem regressiva será exibido
    public Text countdownToEndText; // Referência ao objeto Text onde o texto da contagem regressiva será exibido
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

    private IEnumerator StartCoutdownToEndTheScene()
    {
        float currentTime = timerToEnd;

        while (currentTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;

            countdownToEndText.text = currentTime.ToString();

            if (currentTime <= 100f) 
            {
                arrowIndicator.SetActive(false);
            }
        }

        endScreen.SetActive(true);
        
        scoreText.text = "Total: $ " + orderController.totalValue.ToString("F2", new System.Globalization.CultureInfo("en-US"));

        hotbar.SetActive(false);
    }

    public void ExitGame()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        Application.Quit();
    }

    public void StartScene()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        SceneManager.LoadScene("MainScene"); 
        
    }

    public void CloseInstructions()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        instructionScreen.SetActive(false);
        StartCoroutine(StartCountdownToStartTheScene());
    }

    public void ShowErrorMessage(string message)
    {
        
        errorText.text = message;
        errorText.gameObject.SetActive(true);

        
        StartCoroutine(HideErrorMessage());
    }

    private IEnumerator HideErrorMessage()
    {
        yield return new WaitForSeconds(2f);

        // Hide the error text
        errorText.gameObject.SetActive(false);
    }
}