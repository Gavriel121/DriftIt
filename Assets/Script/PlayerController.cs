using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Joystick joystick;
    public Joystick joystickTwo;

    public float MoveSpeed = 100;
    public float MaxSpeed = 20;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;

    private Vector3 MoveForce;

    public AudioSource audioSource;
    public AudioClip PickUp;
    public AudioClip Explosion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        /* MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
         transform.position += MoveForce * Time.deltaTime;*/

        //Joystick movement
        MoveForce += transform.forward * MoveSpeed * joystick.Vertical * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //Steer
        /*float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);*/

        //Joystick steer
        float steerInput = joystickTwo.Horizontal;
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        //Drag + speed limit
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        //Traction
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Deathwall")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.tag == "Blocker")
        {
            Destroy(gameObject);

            audioSource.PlayOneShot(Explosion);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.tag == "Box")
        {
            ScoreSystem.instance.Addpoint();

            audioSource.PlayOneShot(PickUp);

        }

        if (other.tag == "Deathwall")
        {

            audioSource.PlayOneShot(Explosion);

        }
    }
}
