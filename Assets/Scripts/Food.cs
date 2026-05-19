using UnityEngine;
//using System;

public class Food : MonoBehaviour
{
    [SerializeField] private int foodValue;
    [SerializeField] private GameObject[] destroyParticle;
    [SerializeField] private GameObject collisionParticle; 
    
    //
    public int FoodValue => foodValue;
    
    //
    private bool collisionEffectOnce = true;

    private void OnCollisionEnter(Collision collision) 
    {
        if (!collisionEffectOnce) return;
        
        collisionEffectOnce = false;
        
        Instantiate(collisionParticle, transform.position, Quaternion.identity);
            
    }
    
    
    public void Destroy()
    {
        foreach (var particle in destroyParticle)
        {
            Instantiate(particle, transform.position, Quaternion.identity);    
        }
        
        
        Destroy(gameObject);
    }
}
