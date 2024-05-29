using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assemble : MonoBehaviour
{
    private int ingredientNum = 0;
    private float stackHeight = 0.5f; // Adjust this value as needed to control the stacking height

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ingredient"))
        {
            ingredientNum++;
            LockIngredient(collision.gameObject, ingredientNum);
        }
    }

    private void LockIngredient(GameObject ingredient, int ingredientIndex)
    {
        // Calculate the stack height based on the ingredient index
        float heightOffset = ingredientIndex * stackHeight;

        // Set the position of the ingredient on top of the previous one
        ingredient.transform.position = transform.position + Vector3.up * heightOffset;

        // Add a FixedJoint to the ingredient and connect it to the bottom bun
        FixedJoint joint = ingredient.AddComponent<FixedJoint>();
        joint.connectedBody = GetComponent<Rigidbody>();

        // Optionally, adjust joint settings for more realistic behavior
        joint.breakForce = Mathf.Infinity;
        joint.breakTorque = Mathf.Infinity;
        joint.enablePreprocessing = false;

        // Disable the ingredient's Rigidbody physics to prevent it from falling
        Rigidbody rb = ingredient.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
