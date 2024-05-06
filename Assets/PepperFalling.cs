using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PepperFalling : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public ParticleSystem saltParticles;
    public float minMoveThreshold = 0.01f; // Minimum distance moved to emit sparks
    public float sparkDuration = 2f; // Duration for which the sparks will be emitted
    public int particleThreshold = 5000; // Threshold for emitting seasoning done message

    private bool isMoving;
    private float lastMoveTime;
    private ParticleSystem.EmissionModule emissionModule;
    private Rigidbody rb;
    private Vector3 lastPosition;
    private int particleCount;

    public GameObject seasoningDonePopup; // Reference to the seasoning done pop-up

    private bool seasoningDoneShown = false; // Flag to track if the pop-up has been shown

    void Start()
    {
        emissionModule = saltParticles.emission;
        emissionModule.enabled = false; // Initially disable spark emission
        rb = GetComponent<Rigidbody>(); // Cache the Rigidbody component
        lastPosition = rb.position; // Initialize last position
    }

    void Update()
    {
        if (grabInteractable.isSelected)
        {
            // Check if the object has moved
            float distanceMoved = Vector3.Distance(rb.position, lastPosition);
            if (distanceMoved > minMoveThreshold)
            {
                isMoving = true;
                lastMoveTime = Time.time;
            }
        }
        else
        {
            isMoving = false;
            emissionModule.enabled = false; // Disable spark emission when not grabbed
        }

        // Emit sparks if moving
        if (isMoving && Time.time - lastMoveTime < sparkDuration)
        {
            emissionModule.enabled = true; // Enable spark emission
            saltParticles.transform.position = transform.position; // Set particles position to object's position
            particleCount += (int)saltParticles.emission.rateOverTime.constant; // Update particle count
        }
        else
        {
            isMoving = false;
            emissionModule.enabled = false; // Disable spark emission after sparkDuration
        }

        lastPosition = rb.position; // Update last position

        // Check if the particle count exceeds the threshold and the pop-up hasn't been shown yet
        if (particleCount >= particleThreshold && !seasoningDoneShown)
        {
            // Trigger seasoning done pop-up
            if (seasoningDonePopup != null)
            {
                seasoningDonePopup.SetActive(true);
                seasoningDoneShown = true; // Set the flag to true to indicate the pop-up has been shown
            }
        }
    }
}
