using UnityEngine;
using Unity.Netcode;
using Unity.Collections;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private Rigidbody tankRigidbody;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private NetworkObject projectilePrefab;
    [SerializeField] private Transform weaponTip;

    private UIChat chatSystem;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        chatSystem = FindAnyObjectByType<UIChat>();

        if (IsOwner && IsLocalPlayer)
        {       
            chatSystem.OnMessageSent += SendChatMessageRPC;
        }
    }

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
                SpawnProjectileRPC();
            }
        }

    }

    [Rpc(SendTo.Server)]
    public void SpawnProjectileRPC()
    {
        NetworkObject clonedProjectile = Instantiate(projectilePrefab, weaponTip.position, weaponTip.rotation);
        clonedProjectile.Spawn();
            
    }


    [Rpc(SendTo.Everyone)]
    public void SendChatMessageRPC(FixedString128Bytes messageReceived)
    {
        Debug.Log(":)");
        Debug.Log(messageReceived);

        chatSystem.DisplayMessageReceived(messageReceived);

    }
}
