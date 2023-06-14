using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Sandwich Game/Ingredient Object")]
public class IngredientObject : ScriptableObject
{
    public string nameIngredient;
    public Sprite icon;
}
