using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider pokemonHpBar, playerHpBar;
    public float pokemonHp, playerHp;
    void Start()
    {
        pokemonHp = 1.0f;
        playerHp = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        pokemonHpBar.value = pokemonHp;
        playerHpBar.value = playerHp;
    }

    public void minus_hp(string side, float delta)
    {
        Debug.Log("minus hp");
        if (side == "player")
        {
            playerHp = (playerHp - delta) > 0.0f ? playerHp - delta : 0.0f;
        }
        else if(side == "pokemon")
        {
            pokemonHp = (pokemonHp - delta) > 0.0f ? pokemonHp - delta : 0.0f;
        }
    }
}
