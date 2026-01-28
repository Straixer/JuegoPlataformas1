using UnityEngine;

public class platformMovement : MonoBehaviour
{
    public GameObject platform1;
    public float velocityPlatform1 = 1;
    public float waitTimePlatform1 = 2;
    public float distancePlatform1 = 3;
    bool endPlatform1=false;
    Transform transformPlatform1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformPlatform1 = platform1.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (endPlatform1) {
            transformPlatform1.position = new Vector3(transform.position.x - velocityPlatform1* Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transformPlatform1.position = new Vector3(transform.position.x + velocityPlatform1 * Time.deltaTime, transform.position.y, transform.position.z);
        }

        if(transformPlatform1.position.x>distancePlatform1|| transformPlatform1.position.x < distancePlatform1*-1)
        {
            endPlatform1 = !endPlatform1;
        }
    }

}
