using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sandwich", menuName = "Sandwich Game/SandwichObject")]
public class SandwichObject : ScriptableObject
{
    public string nameSandwich;
    public Sprite icon;
    public IngredientObject[] ingredients = new IngredientObject[3];
}
