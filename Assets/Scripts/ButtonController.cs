using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    public string cooldownButtonTag = "CooldownButton";
    public float cooldownTime = 1.0f;  

    private bool isCooldownActive;

    private void Awake()
    {

        GameObject[] buttons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);
        foreach (GameObject button in buttons)
        {
            Button buttonComponent = button.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(OnButtonClick);
            }
        }

        Button buttonBun = GameObject.FindGameObjectWithTag("ButtonBun").GetComponent<Button>();
        if (buttonBun != null)
        {
            buttonBun.onClick.AddListener(OnButtonClick);
        }

        DisableCooldownButtons();
    }

    public void DisableCooldownButtons()
    {
        GameObject[] cooldownButtons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);

        foreach (GameObject buttonObject in cooldownButtons)
        {
            Button button = buttonObject.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;
                ColorBlock colors = button.colors;
                colors.disabledColor = new Color(0.5f, 0.5f, 0.5f); // Define a cor mais escura para os botões desativados
                button.colors = colors;
            }
        }
    }

    public void OnButtonClick()
    {
        if (isCooldownActive)
        {
            return;
        }

        ApplyCooldownToButtons();
    }

    private void ApplyCooldownToButtons()
    {
        GameObject[] cooldownButtons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);

        foreach (GameObject buttonObject in cooldownButtons)
        {
            Button button = buttonObject.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;
                ColorBlock colors = button.colors;
                colors.disabledColor = new Color(0.5f, 0.5f, 0.5f); // Define a cor mais escura para os botões desativados
                button.colors = colors;
            }
        }
        
        StartCoroutine(StartCooldown());
    }
        

    private IEnumerator StartCooldown()
    {
        GameObject[] cooldownButtons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);
        yield return new WaitForSeconds(cooldownTime);

        foreach (GameObject buttonObject in cooldownButtons)
        {
            Button button = buttonObject.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true;
                ColorBlock colors = button.colors;
                colors.disabledColor = Color.white; // Restaura a cor original do botão desativado
                button.colors = colors;
            }
        }

        // Definir o cooldown como inativo
        isCooldownActive = false;
    }
}