using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public void SpawnIngredient(GameObject ingredientPrefab)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);
    }
}
