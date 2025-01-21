using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ButtonType;

public class ButtonBehaviour : MonoBehaviour
{
    private EventManager eventManager;
    private TMP_Text buttonText;
    private bool selected;
    private float selectTimer = 0f; // Variable pour stocker le temps écoulé
    private Button button;

    [SerializeField]
    private ButtonType buttonType = NONE_B;


    void DarkenButton()
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = colorBlock.highlightedColor;
        button.colors = colorBlock;
    }

    void LightenButton()
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = Color.white;
        button.colors = colorBlock;
    }

    private void OnSelected()
    {
        //Debug.Log("ButtonBehaviour (" + buttonType + ") : On me selectionne");
        selected = true;
        DarkenButton();
    }


    private void OnClicked()
    {
        //Debug.Log("ButtonBehaviour (" + buttonType + ") : On m'a cliqué dessus");

        if (buttonType == NONE_B)
        {
            Debug.Log("ButtonBehaviour (" + buttonType + ") : Je n'ai pas de type.");
        }
        else
        {
            eventManager.OnButtonClicked(buttonType);
        }
    }

    private void TextInit(ButtonType buttonType)
    {
        switch (buttonType)
        {
            case NONE_B:
                buttonText.text = "None";
                break;
            case UPBREAD_B:
                buttonText.text = "Pain Haut";
                break;
            case DOWNBREAD_B:
                buttonText.text = "Pain Bas";
                break;
            case FROMAGE_B:
                buttonText.text = "Fromage";
                break;
            case SALAD_B:
                buttonText.text = "Salade";
                break;
            case STEAK_B:
                buttonText.text = "Steak";
                break;
            case TOMATO_B:
                buttonText.text = "Tomates";
                break;
            case READY_B:
                buttonText.text = "Prêt !";
                break;
            default:
                break;
        }
    }

    private void MainButtonSwitchType()
    {
        //Debug.Log("ButtonB... : On me demande de changer de type");

        if (buttonType == READY_B)
        {
            //Debug.Log("ButtonB... : Je deviens un type AGAIN_B");

            buttonType = AGAIN_B;
            buttonText.text = "Encore ?";
        }
        else
        {
            //Debug.Log("ButtonB... : Je deviens un type READY_B");

            buttonType = READY_B;
            buttonText.text = "Prêt !";

        }
    }



    private void SelectedOrNot()
    {
        if (selected)
        {
            //Debug.Log("ButtonBehaviour (" + buttonType + ") : On me selectionne depuis " + selectTimer + "s");
            selectTimer += Time.deltaTime;

            if (selectTimer > Time.deltaTime * 2)
            {
                //Debug.Log("ButtonBehaviour (" + buttonType + ") : J'estime ne plus être séléctionné");
                selected = false;
                selectTimer = 0;
                LightenButton();
            }
        }
    }



    private void OnEnable()
    {
        if (EventManager.instance != null)
        {
            if (buttonType == READY_B || buttonType == AGAIN_B)
            {
                EventManager.instance.BurgerOnPlateEvent += MainButtonSwitchType;
                EventManager.instance.PlayAgainEvent += MainButtonSwitchType;
            }
        }
    }


    private void OnDisable()
    {
        if (EventManager.instance != null)
        {
            if (buttonType == READY_B || buttonType == AGAIN_B)
            {
                EventManager.instance.BurgerOnPlateEvent -= MainButtonSwitchType;
                EventManager.instance.PlayAgainEvent -= MainButtonSwitchType;
            }
        }
    }


    private void Start()
    {
        eventManager = EventManager.instance;
        selected = false;
        selectTimer = 0;

        buttonText = GetComponentInChildren<TMP_Text>();
        if (buttonText != null)
        {
            TextInit(buttonType);
        }
        else
        {
            Debug.Log("ButtonBehaviour : Je ne trouve pas le texte du bouton");
        }

        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.Log("ButtonBehaviour : Je ne trouve pas le bouton");
        }
    }


    private void Update()
    {
        SelectedOrNot();
    }
}
