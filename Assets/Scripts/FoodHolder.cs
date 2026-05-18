using System;
using UnityEngine;

public class FoodHolder : MonoBehaviour
{
    [SerializeField] private int startingFoodAmount;
    [SerializeField] private int currentFoodAmount;
    
    public int CurrentFoodAmount => currentFoodAmount;
    
    private void Start()
    {
        currentFoodAmount = startingFoodAmount;
    }

    public void ConsumeFood()
    {
        if (currentFoodAmount > 0)
        {
            --currentFoodAmount;
        }
    }

    public void AddFood(int amount = 1)
    {
        currentFoodAmount += amount;
    }
    
    //
    /*private void OnGUI()
    {
        GUI.color = Color.red;
        string label = "Food: " + currentFoodAmount;
        GUI.Label(new Rect(10, 10, 100, 20), label);
    }*/
}
