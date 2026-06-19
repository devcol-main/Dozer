using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private FoodHolder foodHolder;
    
    [SerializeField] private GameObject[] foodPrefab;
    
    [Header("Shot Settings")]
    [SerializeField] private float shotSpeed;
    [SerializeField] private float shotRate;
    [SerializeField] private bool canShoot = true; 
    
    private float shotAngle; // randomly between 0 and 1

    private const float baseWidth = 5;
    
    private GameObject SelectRandomFood()
    {
        GameObject prefab = null;
        int randomIndex = Random.Range(0, foodPrefab.Length);
        prefab = foodPrefab[randomIndex];
        return prefab;
    }

    private Vector3 GetInstantiatePosition( )
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            screenPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        }
        
        float x = baseWidth *
                  (screenPosition.x / Screen.width) - (baseWidth / 2);
        
        Debug.Log("X: " + x +  " | location.x: " + screenPosition.x );
        
        return transform.position + new Vector3(x, 0, 0);
    }
    
    public void OnShoot()
    {
        if (foodHolder.CurrentFoodAmount <= 0) return;
        
        if (!canShoot) return;
        
        Debug.Log("Shooted");
        
        //GameObject food = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        
        
        GameObject food = Instantiate(SelectRandomFood(), GetInstantiatePosition(), Quaternion.identity);
        
        food.transform.parent = foodHolder.transform;
        
        
        Rigidbody rb = food.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shotSpeed, ForceMode.Impulse);
        
        shotAngle = Random.Range(0f, 1f);
        
        rb.AddTorque(transform.up * shotAngle, ForceMode.Impulse);
        
        
        // should I do it with event?
        foodHolder.ConsumeFood();
        
        StartCoroutine(ShotCooldown());
    }
    
    IEnumerator ShotCooldown()
    {
        canShoot = false;
        
        yield return new WaitForSeconds(shotRate);
        
        canShoot = true;
        
    }

}
