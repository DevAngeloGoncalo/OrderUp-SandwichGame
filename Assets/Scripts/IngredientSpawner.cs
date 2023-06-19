using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    public UIController uiController;
    
    public int ingredientLimit = 5;
    private int ingredientCount = 0;

    // Spawna um ingrediente na posi��o do spawner
    public void SpawnIngredient(GameObject ingredientPrefab)
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0f);
        
        if (ingredientCount <= ingredientLimit)
        {
            // Instancia o ingrediente na posi��o de spawn
            GameObject ingredient = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

            // Incrementa o contador de ingredientes se o ingrediente for uma tag "Ingredient"
            if (ingredient.CompareTag("Ingredient"))
            {
                ingredientCount++;
            }
        }
        else
        {
            // Se o limite de ingredientes foi alcan�ado e o ingrediente sendo spawnado � uma tag "Bun", ele � spawnado mesmo assim
            if (ingredientPrefab.CompareTag("Bun"))
            {
                Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);
            }

            // Exibe uma mensagem de erro no UIController
            uiController.ShowErrorMessage("Ingredient limit reached!");
            Debug.Log("Limite de ingredientes alcan�ado!");
            return;
        }
    }

    // Destroi todos os ingredientes e p�es na cena
    public void DestroyAllIngredients()
    {
        // Encontra todos os GameObjects com a tag "Ingredient" e "Bun" na cena
        GameObject[] ingredients = GameObject.FindGameObjectsWithTag("Ingredient");
        GameObject[] buns = GameObject.FindGameObjectsWithTag("Bun");

        // Destroi cada ingrediente encontrado
        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }

        // Destroi cada p�o encontrado
        foreach (GameObject bun in buns)
        {
            Destroy(bun);
        }
    }

    // Reseta o contador de ingredientes para zero
    public void ResetIngredientCount()
    {
        ingredientCount = 0;
    }
}
