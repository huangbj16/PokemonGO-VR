 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerWalk : MonoBehaviour
{
    public int playerSpeed;
    public Slider energy;
    public float energy_decay_speed = 0.2f;
    public float energy_restore_speed = 0.4f;
    private bool restoring = false;
    private float restore_timer;
    public float restore_time = 10f;

    Color normal_color = new Color(19f/255f, 238f/255f, 36f/255f);
    Color restore_color = new Color(238f/255f, 19f/255f, 34f/255f);
    Image energy_image;
    // Start is called before the first frame update
    void Start()
    {
        energy_image = energy.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // FIXME: modify here to allow vertical moving.
        bool canWalk = !this.GetComponent<PlayerGrab>().inHands;
        canWalk = canWalk && !restoring;
        
        if (Input.GetButton("Fire1") && canWalk)
        {
            Vector3 shift = Camera.main.transform.forward;
            Vector3 step = new Vector3(shift[0], 0.0f, shift[2]);
            transform.position += step * playerSpeed * Time.deltaTime;

            energy.value = energy.value - Time.deltaTime * energy_decay_speed;
            energy.value = (energy.value < 0)? 0 : energy.value;
        } else {
            energy.value = energy.value + Time.deltaTime * energy_restore_speed;
            energy.value = (energy.value > 1)? 1 : energy.value;    
        }

        if (energy.value <= 0) {
            restoring = true;
        }

        if (restoring) {
            energy_image.color = restore_color; 
            restore_timer += Time.deltaTime;
            if (restore_timer > restore_time || energy.value >= 1f) {
                restoring = false;
            }
        } else {
            restore_timer = 0;
            energy_image.color = normal_color; 

        }
    }
}
