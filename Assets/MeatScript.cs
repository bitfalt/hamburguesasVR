using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatScript : MonoBehaviour
{
    public GameObject torta;
    public GameObject pop_up;
    public void selectMeat()
    {
        torta.SetActive(true);
        pop_up.SetActive(true);

    }

}
