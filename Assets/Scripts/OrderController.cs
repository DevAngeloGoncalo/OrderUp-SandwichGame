using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    public event System.Action<SandwichObject> OnSandwichSelected;

    public SandwichObject sandwich;
    public List<SandwichObject> sandwiches;
    public GameObject spawner;
    private IngredientSpawner ingredientSpawner;
    private ButtonController buttonController;

    public GameObject sesameSeedBunPrefab;
    public GameObject bottomBunPrefab;
    public GameObject topBunPrefab;
    public GameObject hamburger100gPrefab;
    public GameObject hamburger200gPrefab;
    public GameObject baconPrefab;
    public GameObject cheesePrefab;
    public GameObject americanCheesePrefab;
    public GameObject ketchupPrefab;
    public GameObject greenGoddessSaucePrefab;
    public GameObject lettucePrefab;
    public GameObject friedOnionPrefab;

    public Button ButtonSesameSeedBun;
    public Button ButtonHamburguer100g;
    public Button ButtonHamburguer200g;
    public Button ButtonBacon;
    public Button ButtonCheese;
    public Button ButtonAmericanCheese;
    public Button ButtonKetchup;
    public Button ButtonGreenGoddessSauce;
    public Button ButtonLettuce;
    public Button ButtonFriedOnion;

    public Button ButtonFinishOrder;

    public Text totalValueText;
    public float totalValue = 0f;

    public bool isFirstBun = true;

    List<string> selectedIngredients = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
        buttonController = FindObjectOfType<ButtonController>();
        if (buttonController == null)
        {
            Debug.LogError("OrderController not found in the scene!");
        }

        ButtonSesameSeedBun.onClick.AddListener(AddSesameSeedBun);

        ButtonHamburguer100g.onClick.AddListener(AddHamburger100g);
        ButtonHamburguer200g.onClick.AddListener(AddHamburger200g);
        ButtonBacon.onClick.AddListener(AddBacon);
        ButtonCheese.onClick.AddListener(AddCheese);
        ButtonAmericanCheese.onClick.AddListener(AddAmericanCheesePrefabe);
        ButtonKetchup.onClick.AddListener(AddKetchup);
        ButtonGreenGoddessSauce.onClick.AddListener(AddGreenGoddessSauce);
        ButtonLettuce.onClick.AddListener(AddLettuce);
        ButtonFriedOnion.onClick.AddListener(AddFriedOnion);

        ButtonFinishOrder.onClick.AddListener(FinishOrder);

        ingredientSpawner = spawner.GetComponent<IngredientSpawner>();

        sandwich = GetRandomSandwich();
        SelectSandwich();

    }

    void SelectSandwich()
    {
        sandwich = GetRandomSandwich();

        if (OnSandwichSelected != null)
        {
            OnSandwichSelected(sandwich);
        }
    }

    public SandwichObject GetRandomSandwich()
    {
        int randomIndex = Random.Range(0, sandwiches.Count);
        return sandwiches[randomIndex];
    }

    void AddSesameSeedBun()
    {
        if (isFirstBun)
        {
            ingredientSpawner.SpawnIngredient(bottomBunPrefab);
        }
        else
        {
            ingredientSpawner.SpawnIngredient(topBunPrefab);
            ButtonSesameSeedBun.interactable = false;
        }

        isFirstBun = !isFirstBun;
    }
    
    void AddHamburger100g()
    {
        selectedIngredients.Add("Hamburger 100g");
        ingredientSpawner.SpawnIngredient(hamburger100gPrefab);
    }

    void AddHamburger200g()
    {
        selectedIngredients.Add("Hamburger 200g");
        ingredientSpawner.SpawnIngredient(hamburger200gPrefab);
    }
    
    void AddBacon()
    {
        selectedIngredients.Add("Bacon");
        ingredientSpawner.SpawnIngredient(baconPrefab);
    }

    void AddCheese()
    {
        selectedIngredients.Add("Cheese");
        ingredientSpawner.SpawnIngredient(cheesePrefab);
    }
    
    void AddAmericanCheesePrefabe()
    {
        selectedIngredients.Add("American Cheese");
        ingredientSpawner.SpawnIngredient(americanCheesePrefab);
    }

    void AddKetchup()
    {
        selectedIngredients.Add("Ketchup");
        ingredientSpawner.SpawnIngredient(ketchupPrefab);
    }
    
    void AddGreenGoddessSauce()
    {
        selectedIngredients.Add("Green Goddess Sauce");
        ingredientSpawner.SpawnIngredient(greenGoddessSaucePrefab);
    }

    void AddLettuce()
    {
        selectedIngredients.Add("Lettuce");
        ingredientSpawner.SpawnIngredient(lettucePrefab);
    }
    
    void AddFriedOnion()
    {
        selectedIngredients.Add("Fried Onion");
        ingredientSpawner.SpawnIngredient(friedOnionPrefab);
    }

    bool CheckOrder()
    {

        if (selectedIngredients.Count != sandwich.ingredients.Length)
        {
            return false;
        }    

        for (int i = 0; i < selectedIngredients.Count; i++)
        {
            if (selectedIngredients[i] != sandwich.ingredients[i])
            {
                return false;
            }
        }

        return true;
    }

    void FinishOrder()
    {
        bool correctOrder = CheckOrder();
        float sandwichValue = sandwich.valueSandwich;

        if (correctOrder)
        {
            totalValue += sandwichValue;
            Debug.Log("Order completed successfully! Total value: $" + totalValue);
            totalValueText.text = "$ " + totalValue;
        }
        else
        {
            totalValue -= sandwichValue;
            Debug.Log("Order is incorrect. Please check the ingredients and order.");
            totalValueText.text = "$ " + totalValue;
        }

        ingredientSpawner.DestroyAllIngredients();
        ingredientSpawner.ResetIngredientCount();
        selectedIngredients.Clear();

        sandwich = GetRandomSandwich();
        SelectSandwich();

        ButtonSesameSeedBun.interactable = true;
        isFirstBun = true;
        buttonController.DisableCooldownButtons();
        buttonController.DisableButtonFinish();
    }
}
