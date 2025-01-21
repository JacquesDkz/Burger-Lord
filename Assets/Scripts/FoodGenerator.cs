using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static FoodType;

public class FoodGenerator : MonoBehaviour
{
    [Header("Nouritures")]
    [SerializeField] private GameObject upBread;
    [SerializeField] private GameObject downBread;
    [SerializeField] private GameObject fromage;
    [SerializeField] private GameObject salad;
    [SerializeField] private GameObject steak;
    [SerializeField] private GameObject tomato;

    [Header("Other")]
    [SerializeField] private Transform _model;

    private List<GameObject> burger;

    public void GenerateFood(FoodType foodType)
    {
        GameObject food;

        switch (foodType)
        {
            case UPBREAD:
                food = GameObject.Instantiate(upBread, _model.position, _model.rotation);
                burger.Add(food);
                break;

            case DOWNBREAD:
                food = GameObject.Instantiate(downBread, _model.position, _model.rotation);
                burger.Add(food);
                break;

            case FROMAGE:
                food = GameObject.Instantiate(fromage, _model.position, _model.rotation);
                burger.Add(food);
                break;

            case SALAD:
                food = GameObject.Instantiate(salad, _model.position, _model.rotation);
                burger.Add(food);
                break;

            case STEAK:
                food = GameObject.Instantiate(steak, _model.position, _model.rotation);
                burger.Add(food);
                break;

            case TOMATO:
                food = GameObject.Instantiate(tomato, _model.position, _model.rotation);
                burger.Add(food);
                break;

            default:
                break;
        }
    }

    public void DestroyBurger()
    {
        foreach (GameObject food in burger)
        {
            Destroy(food);
        }
    }

    private void OnEnable()
    {
        EventManager.instance.OnFoodGeneratorCalled += GenerateFood;
    }

    private void OnDisable()
    {
        EventManager.instance.OnFoodGeneratorCalled -= GenerateFood;
    }

    private void Start()
    {
        burger = new List<GameObject>();
    }
}
