using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static FoodType;

public class TextBoxBehaviour : MonoBehaviour
{
    private TMP_Text textBox;

    private void Start()
    {
        textBox = GetComponent<TMP_Text>();

        if ( textBox == null )
        {
            Debug.Log("TextBoxBehaviour : Je ne trouve pas le texte");
        }
    }

    public void DisplayRecipe(List<FoodType> burgerRecipe)
    {
        Clear();

        textBox.text += "Recette :\n";

        string foodWord = "";

        for (int i = burgerRecipe.Count - 1; i >= 0; i--)
        {
            switch (burgerRecipe[i])
            {
                case UPBREAD:
                    foodWord = "Pain Haut";
                    break;
                case DOWNBREAD:
                    foodWord = "Pain Bas";
                    break;
                case FROMAGE:
                    foodWord = "Fromage";
                    break;
                case TOMATO:
                    foodWord = "Tomates";
                    break;
                case SALAD:
                    foodWord = "Salade";
                    break;
                case STEAK:
                    foodWord = "Steak";
                    break;
                default:
                    foodWord = "...";
                    break;
            }
            textBox.text += "  - " + foodWord + "\n";
        }
    }

    public void DisplayWinStatement()
    {
        Clear();
        textBox.text = "Bravo !\nVous êtes un chef !";
    }

    public void DisplayLoseStatement()
    {
        Clear();
        textBox.text = "Dommage...\nEncore une erreur et vous êtes viré !";
    }

    private void Clear()
    {
        textBox.text = "";
    }
}
