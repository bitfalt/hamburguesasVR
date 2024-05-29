using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assemble : MonoBehaviour
{
    private int ingredientNum = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ingredient"))
        {
            ingredientNum++;
            LockIngredient(collision.gameObject);
        }
    }

    private void LockIngredient(GameObject ingredient)
    {
        ingredient.transform.position = transform.position;
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
            joint.connectedBody = GetComponent<Rigidbody>();
            joint.breakForce = Mathf.Infinity;
            joint.breakTorque = Mathf.Infinity;
            joint.enablePreprocessing = false;
        }
    }

}