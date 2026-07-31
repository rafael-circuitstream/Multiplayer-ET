using TMPro;
using Unity.Netcode;
using UnityEngine;

public class UIMultiplayer : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInput;
    [SerializeField] private TMP_Dropdown tankColorDropdown;


    public void JoinMatch()
    {
        NetworkManager.Singleton.StartClient();

        gameObject.SetActive(false);
    }

    public void CreatePrivateMatch()
    {
        NetworkManager.Singleton.StartHost();

        gameObject.SetActive(false);
    }
}
