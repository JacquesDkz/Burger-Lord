using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static ButtonType;
using static FoodType;

public class EventManager : MonoBehaviour
{
    public static EventManager                  instance { get; private set; }

    public delegate void                        FoodGeneratorCall(FoodType food);
    public event FoodGeneratorCall              OnFoodGeneratorCalled;              // Utilisation du delegué custom fait par moi

    public delegate void                        BurgerReadyAction();
    public event BurgerReadyAction              BurgerReadyEvent;

    public delegate void                        BurgerOnPlateAction();
    public event BurgerOnPlateAction            BurgerOnPlateEvent;

    public delegate void                        PlayAgainAction();
    public event PlayAgainAction                PlayAgainEvent;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnButtonClicked(ButtonType buttonType)
    {
        //Debug.Log("EventManager : On me dit qu'un bouton a été cliqué");

        if (OnFoodGeneratorCalled != null && BurgerReadyEvent != null)
        {
            //Debug.Log("EventManager : C'est un bouton " + buttonType);

            switch (buttonType)
            {
                case UPBREAD_B:
                    OnFoodGeneratorCalled(UPBREAD); break;

                case DOWNBREAD_B:
                    OnFoodGeneratorCalled(DOWNBREAD); break;

                case FROMAGE_B:
                    OnFoodGeneratorCalled(FROMAGE); break;

                case SALAD_B:
                    OnFoodGeneratorCalled(SALAD); break;

                case STEAK_B:
                    OnFoodGeneratorCalled(STEAK); break;

                case TOMATO_B:
                    OnFoodGeneratorCalled(TOMATO); break;

                case READY_B:
                    //Debug.Log("EventManager : On clique sur READY donc j'invoque l'event 'BergerReadyEvent'");
                    BurgerReadyEvent(); break;

                case AGAIN_B:
                    //Debug.Log("EventManager : Invocation de l'evenement PlayAgainEvent");
                    PlayAgainEvent(); break;

                case NONE_B:
                    Debug.Log("EventManager : Le bouton n'a pas encore de type assigné"); break;
                default:
                    Debug.Log("EventManager : Je ne reconnais pas le paramètre"); break;
            }
            //Debug.Log("EventManager : J'invoque l'évenement 'OnGenerateFoodCalled'");
        }
    }


    public void BurgerIsOnPlateHandler()
    {
        if (BurgerOnPlateEvent != null)
        {
            //Debug.Log("EventManager : Invocation de l'evenement BurgerOnPlateEvent");
            BurgerOnPlateEvent();
        }
    }
}
