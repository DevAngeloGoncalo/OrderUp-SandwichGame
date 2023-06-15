using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public void SpawnIngredient(GameObject ingredientPrefab)
    {
        Instantiate(ingredientPrefab, transform.position, Quaternion.identity);
    }
}
