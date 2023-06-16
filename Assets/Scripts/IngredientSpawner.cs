using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public Transform spawnPoint;
    
    public int ingredientLimit = 7;
    private int ingredientCount = 0;
    private int countSpawn = 0;

    public void SpawnIngredient(GameObject ingredientPrefab)
    {
        if (ingredientCount >= ingredientLimit)
        {
            Debug.Log("Limite de ingredientes alcançado!");
            return;
        }

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

        ingredientCount++;
    }

    //public void SpawnBun(GameObject ingredientPrefab)
    //{
        
    //    if (countSpawn >= 2)
    //    {
    //        Debug.Log("Limite atingido.");
    //        return;
    //    }

    //    Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0f);
    //    Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

    //    countSpawn++;
    //}

    public void DestroyAllIngredients()
    {
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");

        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }
    }

    public void ResetIngredientCount()
    {
        ingredientCount = 0;
    }
}
