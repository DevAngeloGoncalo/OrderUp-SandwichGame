using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandwichComponent : MonoBehaviour
{
    public OrderController orderController;
    public Text nameText;
    public Image iconImage;
    public Text ingredientsText;
    public Text valueSandwich;

    // Start is called before the first frame update
    void Start()
    {
        // Inscreve o método HandleSandwichSelection como um listener para o evento OnSandwichSelected
        orderController.OnSandwichSelected += HandleSandwichSelection;
        // Seleciona um sanduíche aleatório ao iniciar
        HandleSandwichSelection(orderController.GetRandomSandwich());

    }

    // Atualiza os componentes de UI com as informações do sanduíche selecionado
    public void HandleSandwichSelection(SandwichObject selectedSandwich)
    {
        nameText.text = selectedSandwich.name;
        iconImage.sprite = selectedSandwich.icon;
        valueSandwich.text = ("$" + selectedSandwich.valueSandwich.ToString());
        ingredientsText.text = string.Join(";\n", selectedSandwich.ingredients) + ";";
    }
}
