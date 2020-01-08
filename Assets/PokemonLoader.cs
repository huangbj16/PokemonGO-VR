using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonLoader : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject result;
    public GameObject ball;
    public int aliveFrame;
    public GameObject effect;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        int index = PassingParameters.battlePokemonNameIndex;
        if(index == -1)
        {
            Debug.Log("no index assigned, use dafault 1 instead.");
            index = 4;
        }
        GameObject pokemon = Instantiate(prefabs[index]);
        pokemon.SetActive(true);
        PokemonBattle battleParams = pokemon.GetComponent<PokemonBattle>();
        battleParams.result = result;
        battleParams.ball = ball;
        battleParams.effect = effect;
        battleParams.manager = manager;
    }
}
