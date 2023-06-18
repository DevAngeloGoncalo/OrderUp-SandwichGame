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
    public GameObject bottomBunPrefab;
    public GameObject topBunPrefab;
    public GameObject hamburger100gPrefab;
    public GameObject hamburger200gPrefab;
    public GameObject baconPrefab;
    public GameObject cheesePrefab;
    public GameObject americanCheesePrefab;
    public GameObject coleslawSaucePrefab;
    public GameObject barbecueSaucePrefab;
    public GameObject ketchupPrefab;
    public GameObject greenGoddessSaucePrefab;
    public GameObject redCabbagePrefab;
    public GameObject friedOnionPrefab;

    public Text totalValueText;
    public float totalValue = 0f;

    public bool isFirstBun = true;

    List<string> selectedIngredients = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
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

    public void AddSesameSeedBun()
    {
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

    public void AddHamburger100g()
    {
        selectedIngredients.Add("Hamburger 100g");
        ingredientSpawner.SpawnIngredient(hamburger100gPrefab);
    }

    public void AddHamburger200g()
    {
        selectedIngredients.Add("Hamburger 200g");
        ingredientSpawner.SpawnIngredient(hamburger200gPrefab);
    }

    public void AddBacon()
    {
        selectedIngredients.Add("Bacon");
        ingredientSpawner.SpawnIngredient(baconPrefab);
    }

    public void AddCheese()
    {
        selectedIngredients.Add("Cheese");
        ingredientSpawner.SpawnIngredient(cheesePrefab);
    }

    public void AddAmericanCheesePrefabe()
    {
        selectedIngredients.Add("American Cheese");
        ingredientSpawner.SpawnIngredient(americanCheesePrefab);
    }
    
    public void AddColeslawSaucePrefabe()
    {
        selectedIngredients.Add("Coleslaw Sauce");
        ingredientSpawner.SpawnIngredient(coleslawSaucePrefab);
    }
    
    public void AddBarbecueSaucePrefabe()
    {
        selectedIngredients.Add("Barbecue Sauce");
        ingredientSpawner.SpawnIngredient(barbecueSaucePrefab);
    }

    public void AddKetchup()
    {
        selectedIngredients.Add("Ketchup");
        ingredientSpawner.SpawnIngredient(ketchupPrefab);
    }

    public void AddGreenGoddessSauce()
    {
        selectedIngredients.Add("Green Goddess Sauce");
        ingredientSpawner.SpawnIngredient(greenGoddessSaucePrefab);
    }

    public void AddLettuce()
    {
        selectedIngredients.Add("Red Cabbage");
        ingredientSpawner.SpawnIngredient(redCabbagePrefab);
    }

    public void AddFriedOnion()
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

    public void FinishOrder()
    {
        bool correctOrder = CheckOrder();
        float sandwichValue = sandwich.valueSandwich;

        if (correctOrder)
        {
            totalValue += sandwichValue;
            Debug.Log("Order completed successfully! Total value: $" + totalValue.ToString("F2"));
            totalValueText.text = "$ " + totalValue.ToString("F2");
        }
        else
        {
            totalValue -= sandwichValue;
            Debug.Log("Order is incorrect. Please check the ingredients and order.");
            totalValueText.text = "$ " + totalValue.ToString("F2");
        }

        ingredientSpawner.DestroyAllIngredients();
        ingredientSpawner.ResetIngredientCount();
        selectedIngredients.Clear();

        sandwich = GetRandomSandwich();
        SelectSandwich();

        isFirstBun = true;
    }
}
