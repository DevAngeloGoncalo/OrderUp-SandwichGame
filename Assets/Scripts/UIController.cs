using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public OrderController orderController;

    public GameObject hotbar;
    public GameObject endScreen;

    public float countdownTimeToStart = 3f; // Tempo da contagem regressiva em segundos
    public float timerToEnd = 120f;// Tempo da contagem regressiva em segundos para o fim da partida
    public Text countdownToStartText; // Referência ao objeto Text onde o texto da contagem regressiva será exibido
    public Text countdownToEndText; // Referência ao objeto Text onde o texto da contagem regressiva será exibido
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        hotbar.SetActive(false);
        StartCoroutine(StartCountdownToStartTheScene());
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
        }

        endScreen.SetActive(true);
        
        scoreText.text = "$ " + orderController.totalValue.ToString("F2");

        hotbar.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartScene()
    {

        SceneManager.LoadScene("MainScene"); 
        
    }
}