using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonCooldown : MonoBehaviour
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
    }
    public void OnButtonClick()
    {
        if (isCooldownActive)
        {
            return;
        }

        StartCoroutine(StartCooldown());
    }

    private IEnumerator StartCooldown()
    {
        // Desativa os botões
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = false;
            ColorBlock colors = button.colors;
            colors.disabledColor = new Color(0.5f, 0.5f, 0.5f); // Define a cor mais escura para os botões desativados
            button.colors = colors;
        }

        yield return new WaitForSeconds(cooldownTime);
        
        // Reativa os botões e restaura a aparência
        foreach (Button button in buttons)
        {
            button.interactable = true;
            ColorBlock colors = button.colors;
            colors.disabledColor = Color.white; // Restaura a cor original do botão desativado
            button.colors = colors;
        }

        // Definir o cooldown como inativo
        isCooldownActive = false;
    }
}