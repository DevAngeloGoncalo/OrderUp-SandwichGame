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

    public GameObject sesameSeedBunPrefab;
    public GameObject hamburger100gPrefab;
    public GameObject hamburger200gPrefab;
    public GameObject baconPrefab;
    public GameObject cheesePrefab;
    public GameObject americanCheesePrefab;
    public GameObject ketchupPrefab;
    public GameObject greenGoddessSaucePrefab;
    public GameObject lettucePrefab;
    public GameObject friedOnionsPrefab;

    public Button ButtonSesameSeedBun;
    public Button ButtonHamburguer100g;
    public Button ButtonHamburguer200g;
    public Button ButtonBacon;
    public Button ButtonCheese;
    public Button ButtonAmericanCheese;
    public Button ButtonKetchup;
    public Button ButtonGreenGoddessSauce;
    public Button ButtonLettuce;
    public Button ButtonFriedOnions;

    public Button ButtonFinishOrder;

    List<string> selectedIngredients = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

        ButtonSesameSeedBun.onClick.AddListener(AddSesameSeedBun);
        ButtonHamburguer100g.onClick.AddListener(AddHamburger100g);
        ButtonHamburguer200g.onClick.AddListener(AddHamburger200g);
        ButtonBacon.onClick.AddListener(AddBacon);
        ButtonCheese.onClick.AddListener(AddCheese);
        ButtonAmericanCheese.onClick.AddListener(AddAmericanCheesePrefabe);
        ButtonKetchup.onClick.AddListener(AddKetchup);
        ButtonGreenGoddessSauce.onClick.AddListener(AddGreenGoddessSauce);
        ButtonLettuce.onClick.AddListener(AddLettuce);
        ButtonFriedOnions.onClick.AddListener(AddFriedOnions);

        ButtonFinishOrder.onClick.AddListener(FinishOrder);

        ingredientSpawner = spawner.GetComponent<IngredientSpawner>();

        sandwich = GetRandomSandwich();
    }

    SandwichObject GetRandomSandwich()
    {
        int randomIndex = Random.Range(0, sandwiches.Count);
        return sandwiches[randomIndex];
    }

    void AddSesameSeedBun()
    {
        selectedIngredients.Add("Sesame Seed Bun");
        ingredientSpawner.SpawnIngredient(sesameSeedBunPrefab);
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
    
    void AddFriedOnions()
    {
        selectedIngredients.Add("Fried Onions");
        ingredientSpawner.SpawnIngredient(friedOnionsPrefab);
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

        if (correctOrder)
        {
            Debug.Log("Order completed successfully!");
        }
        else
        {
            Debug.Log("Order is incorrect. Please check the ingredients and order.");
        }

        if (OnSandwichSelected != null)
        {
            OnSandwichSelected(sandwich);
        }

        ingredientSpawner.DestroyAllIngredients();
        ingredientSpawner.ResetIngredientCount();
        selectedIngredients.Clear();

        sandwich = GetRandomSandwich();
    }
}
