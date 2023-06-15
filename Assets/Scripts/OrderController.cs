using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderController : MonoBehaviour
{
    public SandwichObject sandwich;
    public Button ButtonHamburguer;
    public Button ButtonCheese;
    public Button ButtonLettuce;
    public Button ButtonFinishOrder;

    List<string> selectedIngredients = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        ButtonHamburguer.onClick.AddListener(AddHamburger);
        ButtonCheese.onClick.AddListener(AddCheese);
        ButtonLettuce.onClick.AddListener(AddLettuce);
        ButtonFinishOrder.onClick.AddListener(FinishOrder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddHamburger()
    {
        selectedIngredients.Add("Hamburger");
    }

    void AddCheese()
    {
        selectedIngredients.Add("Cheese");
    }

    void AddLettuce()
    {
        selectedIngredients.Add("Lettuce");
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
