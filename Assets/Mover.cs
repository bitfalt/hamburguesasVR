using UnityEngine;

public class BellScript : MonoBehaviour
{
    // Referencia al pop-up que queremos mostrar
    public GameObject popup;
    public AudioSource AudioClip;

    private void OnTriggerEnter(Collider other)
    {
        AudioClip.Play();
        

        // Mostrar el pop-up
        
        // Mostrar el pop-up
        if (popup != null)
        {
            popup.SetActive(true);
        }
        
    }

    
}
