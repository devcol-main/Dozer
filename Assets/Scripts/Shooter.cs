using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject[] foodPrefab;
    [SerializeField] private float shotSpeed;
    [SerializeField] private float shotAngle;

    [SerializeField] private float baseWidth;
    
    //[SerializeField] private float shotInterval;
    [SerializeField] private FoodHolder foodHolder;
    
    GameObject SelectRandomFood()
    {
        GameObject prefab = null;
        int randomIndex = Random.Range(0, foodPrefab.Length);
        prefab = foodPrefab[randomIndex];
        return prefab;
    }

    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth *
                  (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }
    

    public void Shot()
    {
        if (foodHolder.CurrentFoodAmount <= 0) return;
        
        //GameObject food = Instantiate(foodPrefab, transform.position, Quaternion.identity);
        GameObject food = Instantiate(SelectRandomFood(), GetInstantiatePosition(), Quaternion.identity);
        
        food.transform.parent = foodHolder.transform;
        
        
        Rigidbody rb = food.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shotSpeed, ForceMode.Impulse);
        rb.AddTorque(transform.up * shotAngle, ForceMode.Impulse);
        
        
        // should I do it with event?
        foodHolder.ConsumeFood();
    }
}
