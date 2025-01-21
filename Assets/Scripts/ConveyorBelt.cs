using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private bool activated;
    [SerializeField] private float stopDelay = 1;

    private Rigidbody rigidBody;
    private float chrono;
    private float zSize;
    private Transform baseTransform;
    private Transform boutTransform;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        chrono = 0;
        zSize = 0;

        baseTransform = transform.Find("Base");
        if (baseTransform == null)
        {
            Debug.Log("ConvoyorBelt : La base n'a pas été trouvée");
        }
        else
        {
            zSize += baseTransform.localScale.z;
        }

        boutTransform = transform.Find("Bout");
        if (baseTransform == null)
        {
            Debug.Log("ConvoyorBelt : Le bout n'a pas été trouvée");
        }
        else
        {
            zSize += boutTransform.localScale.z;
        }
    }


    //private bool IsTaggedFood(GameObject gameObject)
    //{
    //    bool response = false;
    //    string tag = gameObject.tag;

    //    switch (tag)
    //    {
    //        case "UpBread":
    //            response = true; break;
    //        case "DownBread":
    //            response = true; break;
    //        case "Fromage":
    //            response = true; break;
    //        case "Salad":
    //            response = true; break;
    //        case "Steak":
    //            response = true; break;
    //        case "Tomato":
    //            response = true; break;
    //        default:
    //            response = false; break;
    //    }

    //    return response;
    //}


    void FixedUpdate()
    {
        if (chrono < zSize / speed + stopDelay * Time.fixedDeltaTime)
        {
            if (!rigidBody) return;

            if (!activated) return;

            Vector3 pos = rigidBody.position;

            rigidBody.position -= (transform.forward.normalized * speed * Time.fixedDeltaTime);
            rigidBody.MovePosition(pos);
            chrono += Time.fixedDeltaTime;
        }
        else
        {
            activated = false;
            chrono = 0;
        }
    }


    public void ConveyorMode(bool activated)
    {
        //Debug.Log("ConvoyerBelt : Je m'active");
        this.activated = activated;
    }
}
