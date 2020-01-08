using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PokemonGenerator : MonoBehaviour
{
    public GameObject[] prefabs;

    Vector3 bornPosition;
    float[] heights = new float[5]{ 1f, 1f, 2.5f, 2.1f, 3f };
    const long GAP = 3000;

    Stopwatch counter;
    long elapsedTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        counter = new Stopwatch();
        counter.Start();
        bornPosition = new Vector3(6, 0, 12);
    }

    // Update is called once per frame
    void Update()
    {
        long lastCount = elapsedTime / GAP;
        elapsedTime = counter.ElapsedMilliseconds;
        long curCount = elapsedTime / GAP;
        if (lastCount != curCount)//born new pokemons
        {
            float val = Random.value;
            int index;
            if (val <= 0.2) index = 0;
            else if (val <= 0.4) index = 1;
            else if (val <= 0.6) index = 2;
            else if (val <= 0.8) index = 3;
            else index = 4;
            //UnityEngine.Debug.Log("new pokemon: " + prefabs[index].name);
            bornPosition.y = heights[index];
            Instantiate(prefabs[index], bornPosition, Quaternion.identity);
        }
    }
}
