using UnityEngine;

public class CloseButton : MonoBehaviour
{
    // Método que se llama cuando el jugador hace clic en el botón de cerrar
    public void ClosePopup()
    {
        // Desactivar el pop-up
        transform.parent.gameObject.SetActive(false);
    }
}
