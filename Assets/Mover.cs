using UnityEngine;

public class BellScript : MonoBehaviour
{
    // Referencia al pop-up que queremos mostrar
    public GameObject popup;

    public bool isFinished = false;

    public void bell()
    {
        // Mostrar el pop-up
        if (popup != null && isFinished)
        {
            popup.SetActive(true);
        }


    }

    public void setFinished()
    {
        isFinished = true;
    }



}
