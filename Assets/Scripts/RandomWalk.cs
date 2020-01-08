using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class RandomWalk : MonoBehaviour
{

    public float timer = 0;
    public float speed = 3;
    private float dir_y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        dir_y = 180;
        // SceneManager.LoadScene("TutorialScene");
    }

    // Update is called once per frame

	void Update () {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            dir_y = Random.Range(-180, 180f);
            timer = 0;
        }

        if (dir_y != 0) {
            transform.Rotate(new Vector3(0, dir_y, 0));
            dir_y = 0;
        }

        transform.position -= transform.forward * speed * Time.deltaTime;
    }

}
