using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    public event System.Action<SandwichObject> OnSandwichSelected;

    [SerializeField]
    [Header("Sandwich")]
    public SandwichObject sandwich;
    public List<SandwichObject> sandwiches;
    public GameObject spawner;

    private IngredientSpawner ingredientSpawner;

    [SerializeField]
    [Space]
    public UIController uiController;
    public ButtonController buttonController;

    [SerializeField]
    [Header("Prefabs Ingredients")]
    public GameObject sesameSeedBunPrefab;
    public GameObject bottomBunPrefab;
    public GameObject topBunPrefab;
    public GameObject hamburger100gPrefab;
    public GameObject hamburger200gPrefab;
    public GameObject shrimpBurgerPrefab;
    public GameObject baconPrefab;
    public GameObject baconSlicePrefab;
    public GameObject cheesePrefab;
    public GameObject americanCheesePrefab;
    public GameObject coleslawSaucePrefab;
    public GameObject barbecueSaucePrefab;
    public GameObject ketchupPrefab;
    public GameObject caramelizedOnionsPrefab;
    public GameObject greenGoddessSaucePrefab;
    public GameObject spicyMayoSaucePrefab;
    public GameObject redCabbagePrefab;
    public GameObject friedOnionPrefab;

    [SerializeField]
    [Header("UI")]
    public Text totalValueText;
    [HideInInspector]
    public float totalValue = 0f;
    [HideInInspector]
    public bool isFirstBun = true;

    List<string> selectedIngredients = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        ingredientSpawner = spawner.GetComponent<IngredientSpawner>();

        sandwich = GetRandomSandwich();
        SelectSandwich();

    }

    // Seleciona um sanduíche aleatório
    void SelectSandwich()
    {
        sandwich = GetRandomSandwich();

        // Verifica se há algum método registrado para o evento OnSandwichSelected
        if (OnSandwichSelected != null)
        {
            // Chama o evento passando o objeto sandwich como argumento
            OnSandwichSelected(sandwich);
        }
    }

    // Obtém um sanduíche aleatório da lista de sanduíches
    public SandwichObject GetRandomSandwich()
    {
        int randomIndex = Random.Range(0, sandwiches.Count);
        return sandwiches[randomIndex];
    }

    // Adiciona o pão de gergelim
    public void AddSesameSeedBun()
    {
        // Verifica se é o primeiro pão do sanduíche
        if (isFirstBun)
        {
            ingredientSpawner.SpawnIngredient(bottomBunPrefab);
        }
        else
        {
            ingredientSpawner.SpawnIngredient(topBunPrefab);
        }

        isFirstBun = !isFirstBun;
    }

    // Adiciona um hambúrguer de 100g
    public void AddHamburger100g()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Hamburger 100g");
        ingredientSpawner.SpawnIngredient(hamburger100gPrefab);
    }

    // Adiciona um hambúrguer de 200g
    public void AddHamburger200g()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Hamburger 200g");
        ingredientSpawner.SpawnIngredient(hamburger200gPrefab);
    }

    // Adiciona um hambúrguer de camarão
    public void AddShrimpBurger()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Shrimp Burger");
        ingredientSpawner.SpawnIngredient(shrimpBurgerPrefab);
    }

    // Adiciona bacon
    public void AddBacon()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Bacon");
        ingredientSpawner.SpawnIngredient(baconPrefab);
    }

    // Adiciona fatia de bacon
    public void AddBaconSlice()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Bacon Slice");
        ingredientSpawner.SpawnIngredient(baconSlicePrefab);
    }

    // Adiciona queijo
    public void AddCheese()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Cheese");
        ingredientSpawner.SpawnIngredient(cheesePrefab);
    }

    // Adiciona queijo prato
    public void AddAmericanCheese()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("American Cheese");
        ingredientSpawner.SpawnIngredient(americanCheesePrefab);
    }

    // Adiciona molho coleslaw
    public void AddColeslawSauce()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Coleslaw Sauce");
        ingredientSpawner.SpawnIngredient(coleslawSaucePrefab);
    }

    // Adiciona molho barbecue
    public void AddBarbecueSauce()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Barbecue Sauce");
        ingredientSpawner.SpawnIngredient(barbecueSaucePrefab);
    }

    // Adiciona ketchup
    public void AddKetchup()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Ketchup");
        ingredientSpawner.SpawnIngredient(ketchupPrefab);
    }

    // Adiciona cebola caramelizada
    public void AddCaramelizedOnions()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Caramelized Onions");
        ingredientSpawner.SpawnIngredient(caramelizedOnionsPrefab);
    }

    // Adiciona molho maionese verde
    public void AddGreenGoddessSauce()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Green Goddess Sauce");
        ingredientSpawner.SpawnIngredient(greenGoddessSaucePrefab);
    }

    // Adiciona molho maionese picante
    public void AddSpicyMayoSauce()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Spicy Mayo Sauce");
        ingredientSpawner.SpawnIngredient(spicyMayoSaucePrefab);
    }

    // Adiciona repolho roxo
    public void AddRedCabbage()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Red Cabbage");
        ingredientSpawner.SpawnIngredient(redCabbagePrefab);
    }

    // Adiciona cebola frita
    public void AddFriedOnion()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Fried Onion");
        ingredientSpawner.SpawnIngredient(friedOnionPrefab);
    }

    // Verifica se o pedido está correto
    bool CheckOrder()
    {
        // Verifica se a quantidade de ingredientes selecionados é diferente da quantidade necessária para o sanduíche
        if (selectedIngredients.Count != sandwich.ingredients.Length)
        {
            // Exibe uma mensagem de erro no UIController
            uiController.ShowErrorMessage("Incorrect quantity of ingredients.");
            return false;
        }

        // Verifica se cada ingrediente selecionado corresponde ao ingrediente necessário no sanduíche
        for (int i = 0; i < selectedIngredients.Count; i++)
        {
            // Verifica se a ordem dos ingredientes está correta
            if (selectedIngredients[i] != sandwich.ingredients[i])
            {
                // Exibe uma mensagem de erro no UIController
                uiController.ShowErrorMessage("Incorrect ingredients");
                return false;
            }
        }

        return true;
    }

    // Finaliza o pedido
    public void FinishOrder()
    {
        // Verifica se o pedido está correto
        if (CheckOrder())
        {
            // Atualiza o valor total do pedido
            totalValue += sandwich.valueSandwich;
            Debug.Log("Order completed successfully! Total value: $" + totalValue.ToString("F2"));
            totalValueText.text = totalValue.ToString("F2", new System.Globalization.CultureInfo("en-US"));
        }
        else
        {
            // Reduz o valor total do pedido se o pedido estiver incorreto
            totalValue -= sandwich.valueSandwich;
            totalValue = Mathf.Max(totalValue, 0); // Garante que o valor mínimo seja zero
            Debug.Log("Order is incorrect. Please check the ingredients and order.");
            totalValueText.text = totalValue.ToString("F2", new System.Globalization.CultureInfo("en-US"));
        }

        // Limpa os ingredientes selecionados e reinicia a seleção do sanduíche
        Clear();
    }

    // Metodo para limpar os ingredientes
    void Clear()
    {
        ingredientSpawner.DestroyAllIngredients();
        ingredientSpawner.ResetIngredientCount();
        selectedIngredients.Clear();

        //Chama o próximo sanduiche
        sandwich = GetRandomSandwich();
        SelectSandwich();

        isFirstBun = true;
    }
}
