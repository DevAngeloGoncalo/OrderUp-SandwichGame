using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandwichComponent : MonoBehaviour
{
    public SandwichObject sandwichData;
    public Text nameText;
    public Image iconImage;
    public Text ingredientsText;
    public Text valueSandwich;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = sandwichData.name;
        iconImage.sprite = sandwichData.icon;
        valueSandwich.text = ("$" + sandwichData.valueSandwich.ToString());
        ingredientsText.text = string.Join("\n", sandwichData.ingredients);
    }
}
