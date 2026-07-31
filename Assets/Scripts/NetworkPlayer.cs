using UnityEngine;
using Unity.Netcode;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private Rigidbody tankRigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private NetworkObject projectilePrefab;
    
    // Update is called once per frame
    void Update()
    {
        if(IsOwner && IsLocalPlayer)
        {
            
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            tankRigidbody.linearVelocity = transform.forward * moveSpeed * verticalInput;
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position + Vector3.up, transform.rotation).Spawn();
            }
        }

    }
}
