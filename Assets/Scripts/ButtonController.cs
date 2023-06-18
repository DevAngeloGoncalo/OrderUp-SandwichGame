using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    public OrderController orderController;

    public Button buttonSesameSeedBun;
    public Button buttonHamburger100g;
    public Button buttonHamburger200g;
    public Button buttonBacon;
    public Button buttonCheese;
    public Button buttonAmericanCheese;
    public Button buttonKetchup;
    public Button buttonGreenGoddessSauce;
    public Button buttonLettuce;
    public Button buttonFriedOnion;

    public Button buttonFinishOrder;

    public string cooldownButtonTag = "CooldownButton";
    public string finishButtonTag = "ButtonFinish";
    public float cooldownTime = 1.0f;
    private int countButtonBunClick = 0;

    private bool isCooldownActive;

    private void Start()
    {
        buttonFinishOrder.interactable = false;

        buttonSesameSeedBun.onClick.AddListener(OnButtonBunClick);
        buttonHamburger100g.onClick.AddListener(orderController.AddHamburger100g);
        buttonHamburger200g.onClick.AddListener(orderController.AddHamburger200g);
        buttonBacon.onClick.AddListener(orderController.AddBacon);
        buttonCheese.onClick.AddListener(orderController.AddCheese);
        buttonAmericanCheese.onClick.AddListener(orderController.AddAmericanCheesePrefabe);
        buttonKetchup.onClick.AddListener(orderController.AddKetchup);
        buttonGreenGoddessSauce.onClick.AddListener(orderController.AddGreenGoddessSauce);
        buttonLettuce.onClick.AddListener(orderController.AddLettuce);
        buttonFriedOnion.onClick.AddListener(orderController.AddFriedOnion);

        buttonFinishOrder.onClick.AddListener(FinishOrder);

        GameObject[] buttons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);
        foreach (GameObject button in buttons)
        {
            Button buttonComponent = button.GetComponent<Button>();
            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(OnButtonClick);
            }
        }
        
        DisableCooldownButtons();
    }

    private void Awake()
    {
        
        
    }

    void FinishOrder()
    {

        orderController.FinishOrder();
        DisableCooldownButtons();
        buttonFinishOrder.interactable = false;
        buttonSesameSeedBun.interactable = true;
    }

    public void OnButtonClick()
    {
        if (isCooldownActive)
        {
            return;
        }

        ApplyCooldownToButtons();
    }

    public void OnButtonBunClick()
    {
        countButtonBunClick++;

        if (isCooldownActive)
        {
            return;
        }

        if (countButtonBunClick == 2)
        {
            DisableCooldownButtons();
            countButtonBunClick = 0;
            buttonFinishOrder.interactable = true;
            buttonSesameSeedBun.interactable = false;

        }
        else
        {
            ApplyCooldownToButtons();
            buttonFinishOrder.interactable = false;

        }
        orderController.AddSesameSeedBun();
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