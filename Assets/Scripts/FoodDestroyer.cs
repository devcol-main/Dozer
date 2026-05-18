using System;
using UnityEngine;

public class FoodDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Food>())
        {
            //
            Destroy(other.gameObject);
        }
        
    }
}
