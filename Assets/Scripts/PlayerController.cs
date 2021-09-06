using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController character;
    [SerializeField]
    private float playerSpeed;
    private float gravitySpeed = 9.81f;
    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float backSpeed;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {

        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        anim.SetFloat("Blend", vertical);
        //Vector3 velocity = direction * playerSpeed;
        //velocity.y -= gravitySpeed;
        //velocity = transform.transform.TransformDirection(velocity);
        //character.Move(velocity * Time.deltaTime);
       // transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        if (vertical != 0)
        {
            float moveSpeed = (vertical > 0) ? playerSpeed : backSpeed;

            character.SimpleMove(transform.forward * vertical * moveSpeed);

        }
    }
}
