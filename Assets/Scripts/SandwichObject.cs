using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe que define um objeto de sanduíche para o jogo
[CreateAssetMenu(fileName = "New Sandwich", menuName = "Sandwich Game/SandwichObject")]
public class SandwichObject : ScriptableObject
{
    public string nameSandwich;
    public Sprite icon;
    public string[] ingredients = new string[3];
    public float valueSandwich;
}
