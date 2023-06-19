using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    public OrderController orderController;
    public UIController uiController;

    public AudioSource audioSource;
    public AudioClip buttonSound;

    public Button buttonSesameSeedBun;
    public Button buttonHamburger100g;
    public Button buttonHamburger200g;
    public Button buttonShrimpBurger;
    public Button buttonBacon;
    public Button buttonBaconSlice;
    public Button buttonCheese;
    public Button buttonAmericanCheese;
    public Button buttonColeslawSauce;
    public Button buttonBarbecueSauce;
    public Button buttonKetchup;
    public Button buttonCaramelizedOnions;
    public Button buttonGreenGoddessSauce;
    public Button buttonSpicyMayoSauce;
    public Button buttonRedCabbage;
    public Button buttonFriedOnion;

    public Button buttonCloseInstructions;
    public Button buttonFinishOrder;
    public Button buttonRestartGame;
    public Button buttonExitGame;

    public string cooldownButtonTag = "CooldownButton";
    public string finishButtonTag = "ButtonFinish";
    public float cooldownTime = 0.5f;
    private int countButtonBunClick = 0;

    private bool isCooldownActive;

    private void Start()
    {
       
    }

    //Deve estar no Awake, para que o CD funcione corretamente
    private void Awake()
    {
        // Obtenha a referência do componente AudioSource
        audioSource = GetComponent<AudioSource>();

        buttonFinishOrder.interactable = false;

        buttonSesameSeedBun.onClick.AddListener(OnButtonBunClick);
        buttonHamburger100g.onClick.AddListener(orderController.AddHamburger100g);
        buttonHamburger200g.onClick.AddListener(orderController.AddHamburger200g);
        buttonShrimpBurger.onClick.AddListener(orderController.AddShrimpBurger);
        buttonBacon.onClick.AddListener(orderController.AddBacon);
        buttonBaconSlice.onClick.AddListener(orderController.AddBaconSlice);
        buttonCheese.onClick.AddListener(orderController.AddCheese);
        buttonAmericanCheese.onClick.AddListener(orderController.AddAmericanCheesePrefabe);
        buttonColeslawSauce.onClick.AddListener(orderController.AddColeslawSaucePrefabe);
        buttonBarbecueSauce.onClick.AddListener(orderController.AddBarbecueSaucePrefabe);
        buttonKetchup.onClick.AddListener(orderController.AddKetchup);
        buttonCaramelizedOnions.onClick.AddListener(orderController.AddCaramelizedOnions);
        buttonGreenGoddessSauce.onClick.AddListener(orderController.AddGreenGoddessSauce);
        buttonSpicyMayoSauce.onClick.AddListener(orderController.AddSpicyMayoSauce);
        buttonRedCabbage.onClick.AddListener(orderController.AddRedCabbage);
        buttonFriedOnion.onClick.AddListener(orderController.AddFriedOnion);

        buttonCloseInstructions.onClick.AddListener(uiController.CloseInstructions);
        buttonFinishOrder.onClick.AddListener(FinishOrder);
        buttonRestartGame.onClick.AddListener(uiController.StartScene);
        buttonExitGame.onClick.AddListener(uiController.ExitGame);

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

    void FinishOrder()
    {
        // Reproduza o som do botão
        audioSource.PlayOneShot(buttonSound);

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
        // Reproduza o som do botão
        audioSource.PlayOneShot(buttonSound);

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