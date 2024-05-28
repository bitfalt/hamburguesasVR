using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerAssembler : MonoBehaviour
{
    private GameObject bottomBun;
    private GameObject topBun;
    private GameObject cookedMeat;
    public GameObject lettuce;
    public GameObject tomato;
    
    private Vector3 bottomBunPosition = new Vector3(0.318f, 1.062f, -0.772f);
    private Vector3 meatPosition = new Vector3(0.318f, 1.162f, -0.772f);
    private Vector3 lettucePosition = new Vector3(0.318f, 1.192f, -0.772f);
    private Vector3 tomatoPosition = new Vector3(0.318f, 1.222f, -0.772f);
    private Vector3 topBunPosition = new Vector3(0.318f, 1.252f, -0.772f);

    private float topBunOffsetZ = 5.0f;

    private bool meatOnBun = false;
    private bool lettuceOnBun = false;
    private bool tomatoOnBun = false;
    private bool topBunOnBurger = false;

    void Update()
    {
        if (bottomBun != null)
        {
            CheckMeatOnBun();
            CheckLettuceOnBun();
            CheckTomatoOnBun();
            
            if (meatOnBun && lettuceOnBun && tomatoOnBun && !topBunOnBurger)
            {
                PlaceTopBun();
            }
        }
    }

    public void SetBottomBun(GameObject bun)
    {
        bottomBun = bun;
        bottomBun.transform.position = bottomBunPosition;
    }

    public void SetTopBun(GameObject bun)
    {
        topBun = bun;
        Vector3 relativeTopBunPosition = topBunPosition;
        relativeTopBunPosition.z += topBunOffsetZ;
        topBun.transform.position = relativeTopBunPosition; 
    }

    public void SetCookedMeat(GameObject meat)
    {
        cookedMeat = meat;
    }

    public void setLettuce(GameObject lettuce)
    {
        this.lettuce = lettuce;
    }

    public void setTomato(GameObject tomato)
    {
        this.tomato = tomato;
    }

    void CheckMeatOnBun()
    {
        if (!meatOnBun && cookedMeat != null && Vector3.Distance(cookedMeat.transform.position, meatPosition) < 0.1f)
        {
            cookedMeat.transform.SetParent(bottomBun.transform);
            cookedMeat.transform.localPosition = meatPosition - bottomBunPosition;
            meatOnBun = true;
        }
    }

    void CheckLettuceOnBun()
    {
        if (!lettuceOnBun && Vector3.Distance(lettuce.transform.position, lettucePosition) < 0.1f)
        {
            lettuce.transform.SetParent(bottomBun.transform);
            lettuce.transform.localPosition = lettucePosition - bottomBunPosition;
            lettuceOnBun = true;
        }
    }

    void CheckTomatoOnBun()
    {
        if (!tomatoOnBun && Vector3.Distance(tomato.transform.position, tomatoPosition) < 0.1f)
        {
            tomato.transform.SetParent(bottomBun.transform);
            tomato.transform.localPosition = tomatoPosition - bottomBunPosition;
            tomatoOnBun = true;
        }
    }

    void PlaceTopBun()
    {
        if (Vector3.Distance(topBun.transform.position, topBunPosition) < 0.1f)
        {
            topBun.transform.SetParent(bottomBun.transform);
            topBun.transform.localPosition = topBunPosition - bottomBunPosition;
            topBunOnBurger = true;

            CombineBurger();
        }
    }

    void CombineBurger()
    {
        GameObject combinedBurger = new GameObject("CombinedBurger");
        bottomBun.transform.SetParent(combinedBurger.transform);
        combinedBurger.transform.position = bottomBun.transform.position;

        Debug.Log("Burger Assembled!");
    }
}