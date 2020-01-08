using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterPokemon : MonoBehaviour
{
    public string nextSceneName;

    string[] names = new string[5] {
        "Bulbasaur",
        "Charmander",
        "Dratini",
        "Magikarp",
        "Pikachu"
    };

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.name.Contains("Ground"))
            Debug.Log("player collision: " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        string name = other.gameObject.name;
        Debug.Log("player trigger: " + name);
        int index;
        bool isPokemon = false;
        for(index = 0; index < names.Length; index++)
        {
            if (name.Contains(names[index]))
            {
                isPokemon = true;
                break;
            }
        }
        if (isPokemon)
        {
            Debug.Log("encounter: " + name+"; change scene to battle");
            PassingParameters.battlePokemonNameIndex = index;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
