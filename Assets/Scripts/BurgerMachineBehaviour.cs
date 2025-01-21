using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static FoodType;

public class BurgerMachineBehaviour : MonoBehaviour
{
    [SerializeField] private ConveyorBelt conveyorBelt;
    [SerializeField] private FoodGenerator foodGenerator;
    [SerializeField] private PlateBehaviour plate;
    [SerializeField] private TextBoxBehaviour textBox;

    private List<FoodType> burger;
    private int currentRecipe = 0;


    private List<FoodType> recipe0 = new List<FoodType>()
    {
        DOWNBREAD,
        STEAK,
        SALAD,
        TOMATO,
        FROMAGE,
        UPBREAD,
    };

    private List<FoodType> recipe1 = new List<FoodType>()
    {
        DOWNBREAD,
        FROMAGE,
        STEAK,
        TOMATO,
        SALAD,
        UPBREAD,
    };

    private List<FoodType> recipe2 = new List<FoodType>()
    {
        DOWNBREAD,
        SALAD,
        TOMATO,
        STEAK,
        FROMAGE,
        UPBREAD,
    };

    private List<List<FoodType>> recipeList = new List<List<FoodType>>();


    private void OnEnable()
    {
        if (EventManager.instance != null)
        {
            EventManager.instance.BurgerReadyEvent += SendBurgerToCheck;
            EventManager.instance.PlayAgainEvent += InitBurgerMachine;
            EventManager.instance.OnFoodGeneratorCalled += FoodStacked;
            EventManager.instance.BurgerOnPlateEvent += BurgerOnPlate;
        }
        else
        {
            Debug.Log("BurgerBehaviour : EventManager instance is null in BurgerMachineBehaviour OnEnable");
        }
    }



    private void OnDisable()
    {
        if (EventManager.instance != null)
        {
            EventManager.instance.BurgerReadyEvent -= SendBurgerToCheck;
            EventManager.instance.PlayAgainEvent -= InitBurgerMachine;
            EventManager.instance.OnFoodGeneratorCalled -= FoodStacked;
            EventManager.instance.BurgerOnPlateEvent -= BurgerOnPlate;
        }
        else
        {
            Debug.Log("BurgerBehaviour : EventManager instance is null in BurgerMachineBehaviour OnEnable.");
        }
    }



    private void InitBurgerMachine()
    {
        conveyorBelt.ConveyorMode(false);

        if (burger.Count != 0)
        {
            foodGenerator.DestroyBurger();
            burger.Clear();
        }

        textBox.DisplayRecipe(recipeList[currentRecipe]);
    }


    private bool AsWon()
    {
        bool result = false;

        if (burger.SequenceEqual(recipeList[currentRecipe]))
        {
            textBox.DisplayWinStatement();

            //Debug.Log("La recette est " + currentRecipe);
            
            if (currentRecipe < recipeList.Count - 1) 
            {
                currentRecipe++;
            }
            else
            {
                currentRecipe = 0;
            }
        }
        else
        {
            textBox.DisplayLoseStatement();
        }

        return result;
    }


    private void SendBurgerToCheck()
    {
        //Debug.Log("BurgerMachineBehaviour : On me dit d'envoyer le burger");
        conveyorBelt.ConveyorMode(true);
        plate.SetBurgerDetection(true);
    }

    private void FoodStacked(FoodType food)
    {
        burger.Add(food);
    }


    private void BurgerOnPlate()
    {
        plate.SetBurgerDetection(false);
        AsWon();
    }



    private void Start()
    {
        burger = new List<FoodType>();
        recipeList.Add(recipe0);
        recipeList.Add(recipe1);
        recipeList.Add(recipe2);

        if (plate == null)
        {
            Debug.Log("BurgerMachineBehaviour : Il me manque une assiette");
        }

        if (conveyorBelt == null)
        {
            Debug.Log("BurgerMachineBehaviour : Il me manque un convoyeur");
        }

        if (foodGenerator == null)
        {
            Debug.Log("BurgerMachineBehaviour : Il me manque un générateur de nourriture");
        }

        if (textBox == null)
        {
            Debug.Log("BurgerMachineBehaviour : Il me manque une zone de texte");
        }

        InitBurgerMachine();
    }

}

