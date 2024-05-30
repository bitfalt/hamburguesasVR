using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assemble : MonoBehaviour
{
    private List<GameObject> lockedIngredients = new List<GameObject>();
    private BoxCollider[] mainColliders;

    private void Start()
    {
        mainColliders = GetComponents<BoxCollider>();
        if (mainColliders.Length != 2)
        {
            Debug.LogError("Main GameObject needs exactly 2 BoxColliders.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ingredient"))
        {
            LockIngredient(collision.gameObject);
            UpdateColliderSize();
        }
    }

    private void LockIngredient(GameObject ingredient)
    {
        // Calculate the new position for the ingredient
        Vector3 newPosition = transform.position;

        if (lockedIngredients.Count > 0)
        {
            // Get the height of the last locked ingredient
            Bounds lastIngredientBounds = lockedIngredients[lockedIngredients.Count - 1].GetComponent<Collider>().bounds;
            float newIngredientHeight = ingredient.GetComponent<Collider>().bounds.size.y;

            // Calculate the new position based on the height of the last ingredient
            newPosition.y = lastIngredientBounds.max.y + newIngredientHeight / 2;
        }

        // Set the new position for the ingredient
        ingredient.transform.position = newPosition;

        // Add a FixedJoint to the ingredient and connect it to the main GameObject
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

        // Add ingredient to the list
        lockedIngredients.Add(ingredient);
    }

    private void UpdateColliderSize()
    {
        
        // Calculate the combined bounds of the two main colliders
        Bounds combinedBounds = new Bounds(transform.position, Vector3.zero);
        foreach (BoxCollider collider in mainColliders)
        {
            combinedBounds.Encapsulate(collider.bounds);
        }

        // Include the bounds of all locked ingredients
        foreach (GameObject lockedIngredient in lockedIngredients)
        {
            combinedBounds.Encapsulate(lockedIngredient.GetComponent<Collider>().bounds);
        }

        // Adjust the size and center of both main colliders to fit all ingredients
        foreach (BoxCollider collider in mainColliders)
        {
            collider.size = combinedBounds.size;
            collider.center = combinedBounds.center - transform.position;
        }
        
    }
}
