using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    public float rotationSpeed = 10f;
    private Rigidbody rb;
    private Animator animator;
    public float moveSpeed = 7f;
    public ParticleSystem particleSystem;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        particleSystem.Clear();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Dönmeyi engellemek için angular velocity'yi sıfırlıyoruz
        rb.angularVelocity = Vector3.zero;

        // Yalpalamayı engellemek için drag değerini arttırabilirsiniz
        rb.angularDrag = 0f;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;



        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);
            transform.rotation = Quaternion.Euler(0, angle, 0);


            Vector3 move = transform.forward * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + move);
            animator.SetFloat("speed", moveDirection.magnitude);

            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            animator.SetFloat("speed", 0);
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }

        }
    }
}