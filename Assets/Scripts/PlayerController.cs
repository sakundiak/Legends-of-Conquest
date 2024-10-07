using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] int moveSpeed = 1;
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] Animator playerAnimator;

    public string transitionName;

    Vector3 bottomLeftCorner;
    Vector3 topRightCorner;

    [SerializeField] Tilemap tilemap;
    
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        DontDestroyOnLoad(gameObject);

        bottomLeftCorner = tilemap.localBounds.min + new Vector3(0.5f, 0.8f, 0f);
        topRightCorner = tilemap.localBounds.max - new Vector3(-0.5f, -0.8f, 0f);
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        playerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        playerAnimator.SetFloat("movementX", playerRigidBody.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody.velocity.y);

        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftCorner.x, topRightCorner.x),
           Mathf.Clamp(transform.position.y, bottomLeftCorner.y, topRightCorner.y),
           Mathf.Clamp(transform.position.z, bottomLeftCorner.z, topRightCorner.z));
    }
}
