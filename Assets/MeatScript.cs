using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatScript : MonoBehaviour
{
    public GameObject torta;
    public GameObject pop_up;
    public float scaleSpeed = 0.3f;
    public Vector3 maxScale = new Vector3(0.15f, 0.15f, 0.15f);

    private float scaleFactorX = 0.04967953f / 0.02f; // ~2.484
    private float scaleFactorY = 1.0f;
    private float scaleFactorZ = 0.04967953f / 0.02f; // ~2.484

    public void selectMeat()
    {
        torta.SetActive(true);
        //pop_up.SetActive(true);

        Vector3 scaleIncrement = new Vector3(scaleSpeed * scaleFactorX, scaleSpeed * scaleFactorY, scaleSpeed * scaleFactorZ) * Time.deltaTime;
        torta.GetComponent<Transform>().localScale += scaleIncrement;

        Debug.Log("Current Local Scale: " + torta.GetComponent<Transform>().localScale);
        //transform.localScale = Vector3.Min(transform.localScale, maxScale);
    }
}
