using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{
    [SerializeField]
    [Header("Controllers")]
    public OrderController orderController;
    public UIController uiController;

    [SerializeField]
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonSound;

    [SerializeField]
    [Header("Buttons")]
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
    public Button buttonMenu;
    public Button buttonExitGame;

    [SerializeField]
    [Space]
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

        // Adicione os listeners aos botões
        buttonSesameSeedBun.onClick.AddListener(OnButtonBunClick);
        buttonHamburger100g.onClick.AddListener(orderController.AddHamburger100g);
        buttonHamburger200g.onClick.AddListener(orderController.AddHamburger200g);
        buttonShrimpBurger.onClick.AddListener(orderController.AddShrimpBurger);
        buttonBacon.onClick.AddListener(orderController.AddBacon);
        buttonBaconSlice.onClick.AddListener(orderController.AddBaconSlice);
        buttonCheese.onClick.AddListener(orderController.AddCheese);
        buttonAmericanCheese.onClick.AddListener(orderController.AddAmericanCheese);
        buttonColeslawSauce.onClick.AddListener(orderController.AddColeslawSauce);
        buttonBarbecueSauce.onClick.AddListener(orderController.AddBarbecueSauce);
        buttonKetchup.onClick.AddListener(orderController.AddKetchup);
        buttonCaramelizedOnions.onClick.AddListener(orderController.AddCaramelizedOnions);
        buttonGreenGoddessSauce.onClick.AddListener(orderController.AddGreenGoddessSauce);
        buttonSpicyMayoSauce.onClick.AddListener(orderController.AddSpicyMayoSauce);
        buttonRedCabbage.onClick.AddListener(orderController.AddRedCabbage);
        buttonFriedOnion.onClick.AddListener(orderController.AddFriedOnion);
        buttonCloseInstructions.onClick.AddListener(uiController.CloseInstructions);
        buttonFinishOrder.onClick.AddListener(FinishOrder);
        buttonRestartGame.onClick.AddListener(uiController.StartScene);
        buttonMenu.onClick.AddListener(uiController.LoadScene);
        buttonExitGame.onClick.AddListener(uiController.ExitGame);

        // Encontre os botões com a tag "CooldownButton" e adicione os listeners
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

    // Método Finalizar Pedido
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
            return; // Se o cooldown estiver ativo, não execute nada
        }

        ApplyCooldownToButtons();
    }

    public void OnButtonBunClick()
    {
        // Reproduza o som do botão
        audioSource.PlayOneShot(buttonSound);

        // Incrementa o contador de cliques no botão de pão
        countButtonBunClick++;

        if (isCooldownActive)
        {
            return; // Se o cooldown estiver ativo, não execute nada
        }

        // Verifica se o botão foi pressionado 2 vezes
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

        // Adiciona o pão de gergelim ao pedido
        orderController.AddSesameSeedBun();
    }

    // Método que desativa os botões com TAG CooldownButtons
    // É chamado quando o jogo é iniciado, ao concluir pedido ou na inserção do segundo pedaço de pão
    public void DisableCooldownButtons()
    {
        // Encontra todos os botões com a tag de cooldown
        GameObject[] cooldownButtons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);

        // Percorre cada botão encontrado
        foreach (GameObject buttonObject in cooldownButtons)
        {
            // Obtém o componente Button do botão
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

    // Aplica o cooldown aos botões
    private void ApplyCooldownToButtons()
    {
        // Percorre cada botão encontrado
        GameObject[] cooldownButtons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);

        // Percorre cada botão encontrado
        foreach (GameObject buttonObject in cooldownButtons)
        {
            // Obtém o componente Button do botão
            Button button = buttonObject.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;
                ColorBlock colors = button.colors;
                colors.disabledColor = new Color(0.5f, 0.5f, 0.5f); // Define a cor mais escura para os botões desativados
                button.colors = colors;
            }
        }

        // Inicia a rotina de cooldown
        StartCoroutine(StartCooldown());
    }

    // Inicia o cooldown dos botões após um determinado tempo, reativando a interação e restaurando a cor original dos botões.
    private IEnumerator StartCooldown()
    {
        // Encontra todos os botões com a tag de cooldown
        GameObject[] cooldownButtons = GameObject.FindGameObjectsWithTag(cooldownButtonTag);
        // Aguarda o tempo de cooldown
        yield return new WaitForSeconds(cooldownTime);
        // Percorre cada botão encontrado
        foreach (GameObject buttonObject in cooldownButtons)
        {   
            // Obtém o componente Button do botão atual
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