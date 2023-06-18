using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject hotbar;

    public float countdownTime = 3f; // Tempo da contagem regressiva em segundos
    public Text countdownText; // Refer�ncia ao objeto Text onde o texto da contagem regressiva ser� exibido

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
        float currentTime = countdownTime;

        while (currentTime > 0f)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;

            // Atualiza o texto da contagem regressiva
            countdownText.text = currentTime.ToString();
        }

        // Quando a contagem regressiva terminar, permite iniciar a cena
        countdownText.text = "GO!";

        // Aguarda por mais 1 segundo antes de remover o texto da contagem regressiva
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        hotbar.SetActive(true);
    }

    public void StartScene()
    {

        // Inicia a cena
        SceneManager.LoadScene("SampleScene"); // Substitua "NomeDaCena" pelo nome da sua cena
        
    }
}