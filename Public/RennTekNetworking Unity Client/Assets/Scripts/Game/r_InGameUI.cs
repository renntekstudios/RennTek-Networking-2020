using RennTekNetworking.Client.Clients;
using UnityEngine;
using UnityEngine.UI;

public class r_InGameUI : MonoBehaviour
{
    public Button m_DisconnectButton;

    void Start()
    {
        m_DisconnectButton.onClick.AddListener(delegate
        {
            r_Client.Disconnect(false);
        });
    }
}
