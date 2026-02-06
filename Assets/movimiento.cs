using UnityEngine;

public class movimiento : MonoBehaviour
{
    public GameObject Player;
    public float velocity = 1;
    public Rigidbody rg;
    public float jumpforce = 1;
    public int score = 0;

    BoxCollider box;
    bool canJump = true;
    SphereCollider sp;
    public GameObject suelo;

    Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        box = suelo.GetComponent<BoxCollider>();
        sp = Player.GetComponent<SphereCollider>();
        transform = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            transform.position = new Vector3(transform.position.x + velocity*Time.deltaTime, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position = new Vector3(transform.position.x - velocity*Time.deltaTime, transform.position.y, transform.position.z);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + velocity*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - velocity*Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space)&&canJump){
            rg.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            canJump=false;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            canJump=true;
        }

    }

        private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Moneda"))
        {
            score++;
        }
    }
}


