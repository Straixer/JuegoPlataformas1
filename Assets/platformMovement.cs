using UnityEngine;

public class platformMovement : MonoBehaviour
{
    public GameObject platform1;
    public float velocityPlatform1 = 1;
    public float waitTimePlatform1 = 2;
    public float distancePlatform1 = 3;
    Vector3 initialPositionPlatform1;
    bool endPlatform1=false;
    Transform transformPlatform1;

    public GameObject player;
    Transform transformPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformPlatform1 = platform1.transform;
        initialPositionPlatform1 = transformPlatform1.position;

        transformPlayer = player.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromStartPlatform1 = transformPlatform1.position.x - initialPositionPlatform1.x;
        if (endPlatform1) {
            transformPlatform1.Translate(Vector3.right * velocityPlatform1 * Time.deltaTime);
            if (distanceFromStartPlatform1 >= distancePlatform1)
            {
                endPlatform1 = false;
            }
        }
        else
        {
            transformPlatform1.Translate(Vector3.left * velocityPlatform1 * Time.deltaTime);
            if (distanceFromStartPlatform1 <= -distancePlatform1)
            {
                endPlatform1 = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (endPlatform1)
            {
                transformPlayer.Translate(Vector3.right * velocityPlatform1 * Time.deltaTime);
            }
            else
            {
                transformPlayer.Translate(Vector3.left * velocityPlatform1 * Time.deltaTime);
            }
        }
    }

}
