using Unity.Netcode;
using UnityEngine;

public class NetworkProjectile : NetworkBehaviour
{
    [SerializeField] private Rigidbody projectileRigidbody;
    [SerializeField] private float forwardSpeed;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(IsServer)
        {
            projectileRigidbody.AddForce(transform.forward * forwardSpeed);
        }
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
