using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookBun : MonoBehaviour
{
    public Color color1;
    public Color color2;

    private bool inContactWithOven = false;
    private float timer = 0f;
    private bool color1Applied = false;
    private bool color2Applied = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("oven"))
        {
            inContactWithOven = true;
            // Start the timer when entering the oven
            timer = 0f;
            color1Applied = false;
            color2Applied = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("oven"))
        {
            inContactWithOven = false;
            // Reset the timer when exiting the oven
            timer = 0f;
            color1Applied = false;
            color2Applied = false;
        }
    }

    private void Update()
    {
        // Only update the timer if in contact with the oven
        if (inContactWithOven)
        {
            timer += Time.deltaTime;

            // Check if 5 seconds have passed and color 1 hasn't been applied yet
            if (timer >= 5f && !color1Applied)
            {
                ApplyColor(color1);
                color1Applied = true;
            }

            // Check if 10 more seconds have passed and color 2 hasn't been applied yet
            if (timer >= 15f && !color2Applied)
            {
                ApplyColor(color2);
                color2Applied = true;
            }
        }
    }

    private void ApplyColor(Color color)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
