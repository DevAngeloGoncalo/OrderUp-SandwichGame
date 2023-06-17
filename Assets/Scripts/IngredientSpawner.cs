using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public Transform spawnPoint;
    
    public int ingredientLimit = 5;
    private int ingredientCount = 0;

    public void SpawnIngredient(GameObject ingredientPrefab)
    {
        if (ingredientCount <= ingredientLimit)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0f);
            GameObject ingredient = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

            if (ingredient.CompareTag("Ingredient"))
            {
                ingredientCount++;
            }
        }
        else
        {
            Debug.Log("Limite de ingredientes alcançado!");
            return;
        }
    }

    public void DestroyAllIngredients()
    {
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
        GameObject[] buns = GameObject.FindGameObjectsWithTag("Bun");

        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }

        foreach (GameObject bun in buns)
        {
            Destroy(bun);
        }
    }

    public void ResetIngredientCount()
    {
        ingredientCount = 0;
    }
}
