using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    public SandwichObject sandwich;
    //public Spawner spawner;
    public GameObject spawner;
    private IngredientSpawner ingredientSpawner;

    public GameObject hamburger100gPrefab;
    public GameObject hamburger200gPrefab;
    public GameObject cheesePrefab;
    public GameObject ketchupPrefab;
    public GameObject lettucePrefab;

    public Button ButtonHamburguer100g;
    public Button ButtonHamburguer200g;
    public Button ButtonCheese;
    public Button ButtonKetchup;
    public Button ButtonLettuce;
    public Button ButtonFinishOrder;

    List<string> selectedIngredients = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        ButtonHamburguer100g.onClick.AddListener(AddHamburger100g);
        ButtonHamburguer200g.onClick.AddListener(AddHamburger200g);
        ButtonCheese.onClick.AddListener(AddCheese);
        ButtonKetchup.onClick.AddListener(AddKetchup);
        ButtonLettuce.onClick.AddListener(AddLettuce);
        ButtonFinishOrder.onClick.AddListener(FinishOrder);

        //spawner = GetComponent<Spawner>();
        ingredientSpawner = spawner.GetComponent<IngredientSpawner>();
    }

    public void SpawnIngredient(GameObject ingredientPrefab)
    {
        Instantiate(ingredientPrefab, transform.position, Quaternion.identity);
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

    void AddCheese()
    {
        selectedIngredients.Add("Cheese");
        ingredientSpawner.SpawnIngredient(cheesePrefab);
    }

    void AddKetchup()
    {
        selectedIngredients.Add("Ketchup");
        ingredientSpawner.SpawnIngredient(ketchupPrefab);
    }
    void AddLettuce()
    {
        selectedIngredients.Add("Lettuce");
        ingredientSpawner.SpawnIngredient(lettucePrefab);
    }

    void FinishOrder()
    {
        //bool correctIngredients = (hasHamburger && hasCheese && hasLettuce);
        bool correctOrder = CheckOrder();

        //if (correctIngredients && correctOrder)
        if (correctOrder)
        {
            Debug.Log("Order completed successfully!");
            // Execute any desired actions upon successful order completion
        }
        else
        {
            Debug.Log("Order is incorrect. Please check the ingredients and order.");
            // Execute any desired actions upon incorrect order
        }
    }

    bool CheckOrder()
    {

        if (selectedIngredients.Count != sandwich.ingredients.Length)
            return false;

        for (int i = 0; i < selectedIngredients.Count; i++)
        {
            if (selectedIngredients[i] != sandwich.ingredients[i])
            {
                return false;
            }
        }

        return true;
    }
}
