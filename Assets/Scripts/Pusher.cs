using UnityEngine;

public class Pusher : MonoBehaviour
{
    private Vector3 startPosition;

    [SerializeField] private float amplitude;
    [SerializeField] private float speed;
    
    private void Start()
    {
        startPosition = transform.localPosition;
    }
    

    private void Update()
    {
        float z = amplitude * Mathf.Sin(Time.time * speed);
        
        // tween is better
        transform.localPosition = startPosition + new Vector3(0, 0, z);
    }
}
