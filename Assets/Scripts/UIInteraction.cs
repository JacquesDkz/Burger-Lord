using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInteraction : MonoBehaviour
{
    [SerializeField]
    private float gazeDistance = 5f;

    public EventSystem eventSystem;
    public GraphicRaycaster raycaster;
    private Camera mainCamera;
    private Ray gazeRay;

    private void Start()
    {
        mainCamera = Camera.main;        
    }

    private void Update()
    {
        gazeRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        Debug.DrawRay(gazeRay.origin, gazeRay.direction * gazeDistance, Color.red);

        //-------Tâche du Graphic Raycaster---------
        PointerEventData pointerData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(pointerData, results);

        foreach (var result in results)
        {
            if (result.gameObject.CompareTag("Button"))
            {
                result.gameObject.SendMessage("OnSelected");
                //Debug.Log("UIInteraction : " + result.gameObject.name + " est selectionné");

                if (Input.GetMouseButtonDown(0))
                {
                    result.gameObject.SendMessage("OnClicked");
                    //Debug.Log("UIInteraction : " + result.gameObject.name + " est cliqué");
                }
            }
        }
        //-------------------------------------
    }
}
