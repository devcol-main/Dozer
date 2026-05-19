using System;
using UnityEngine;

public class FoodDestroyer : MonoBehaviour
{
    
    [SerializeField] private FoodHolder foodHolder;
    
    
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.GetComponent<Food>())
        if (other.gameObject.TryGetComponent(out Food food))
        {
            //
            foodHolder.AddFood();
            food.Destroy();
            
            //Destroy(other.gameObject);
        }
        
    }
}
