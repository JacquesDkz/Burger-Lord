using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBehaviour : MonoBehaviour
{
    private bool burgerDetection = false;

    private void OnTriggerEnter(Collider other)
    {
        if (burgerDetection)
        {
            //Debug.Log("PlateBehaviour : Un burger est sur moi");
            EventManager.instance.BurgerIsOnPlateHandler();
        }
    }

    public void SetBurgerDetection(bool _burgerDetection)
    {
        burgerDetection = _burgerDetection;
    }
}
