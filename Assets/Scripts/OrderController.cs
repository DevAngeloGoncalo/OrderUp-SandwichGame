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
    public UIController uiController;
    public ButtonController buttonController;

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
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Hamburger 100g");
        ingredientSpawner.SpawnIngredient(hamburger100gPrefab);
    }

    public void AddHamburger200g()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Hamburger 200g");
        ingredientSpawner.SpawnIngredient(hamburger200gPrefab);
    }
    
    public void AddShrimpBurger()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Shrimp Burger");
        ingredientSpawner.SpawnIngredient(shrimpBurgerPrefab);
    }

    public void AddBacon()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Bacon");
        ingredientSpawner.SpawnIngredient(baconPrefab);
    }
    
    public void AddBaconSlice()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Bacon Slice");
        ingredientSpawner.SpawnIngredient(baconSlicePrefab);
    }

    public void AddCheese()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Cheese");
        ingredientSpawner.SpawnIngredient(cheesePrefab);
    }

    public void AddAmericanCheesePrefabe()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("American Cheese");
        ingredientSpawner.SpawnIngredient(americanCheesePrefab);
    }
    
    public void AddColeslawSaucePrefabe()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Coleslaw Sauce");
        ingredientSpawner.SpawnIngredient(coleslawSaucePrefab);
    }
    
    public void AddBarbecueSaucePrefabe()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Barbecue Sauce");
        ingredientSpawner.SpawnIngredient(barbecueSaucePrefab);
    }

    public void AddKetchup()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Ketchup");
        ingredientSpawner.SpawnIngredient(ketchupPrefab);
    }
    
    public void AddCaramelizedOnions()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Caramelized Onions");
        ingredientSpawner.SpawnIngredient(caramelizedOnionsPrefab);
    }

    public void AddGreenGoddessSauce()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Green Goddess Sauce");
        ingredientSpawner.SpawnIngredient(greenGoddessSaucePrefab);
    }
    
    public void AddSpicyMayoSauce()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Spicy Mayo Sauce");
        ingredientSpawner.SpawnIngredient(spicyMayoSaucePrefab);
    }

    public void AddRedCabbage()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Red Cabbage");
        ingredientSpawner.SpawnIngredient(redCabbagePrefab);
    }

    public void AddFriedOnion()
    {
        buttonController.audioSource.PlayOneShot(buttonController.buttonSound);
        selectedIngredients.Add("Fried Onion");
        ingredientSpawner.SpawnIngredient(friedOnionPrefab);
    }

    bool CheckOrder()
    {

        if (selectedIngredients.Count != sandwich.ingredients.Length)
        {
            uiController.ShowErrorMessage("Incorrect quantity of ingredients.");
            return false;
        }    

        for (int i = 0; i < selectedIngredients.Count; i++)
        {
            if (selectedIngredients[i] != sandwich.ingredients[i])
            {
                uiController.ShowErrorMessage("Incorrect ingredients");
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
            totalValueText.text = totalValue.ToString("F2", new System.Globalization.CultureInfo("en-US"));
        }
        else
        {
            totalValue -= sandwichValue;
            totalValue = Mathf.Max(totalValue, 0); // Garante que o valor mínimo seja zero
            Debug.Log("Order is incorrect. Please check the ingredients and order.");
            totalValueText.text = totalValue.ToString("F2", new System.Globalization.CultureInfo("en-US"));
        }

        ingredientSpawner.DestroyAllIngredients();
        ingredientSpawner.ResetIngredientCount();
        selectedIngredients.Clear();

        sandwich = GetRandomSandwich();
        SelectSandwich();

        isFirstBun = true;
    }
}
