using RennTekNetworking.Client.Clients;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public enum r_MenuState
{
    MainMenu,
    SetUsername,
    Connecting
}

[System.Serializable]
public class r_MenuPanels
{
    public GameObject m_MenuPanel;
    public r_MenuState m_MenuState;
}

public class r_MainMenuController : MonoBehaviour
{
    public List<r_MenuPanels> m_MenuPanels = new List<r_MenuPanels>();

    [Header("Inputs")]
    public InputField m_UsernameInput;

    [Header("Buttons")]
    public Button m_SetUsernameButton;
    public Button m_PlayButton;

    public void SetPanel(r_MenuState _state)
    {
        r_MenuPanels _panel = m_MenuPanels.Find(x => x.m_MenuState == _state);

        if(_panel == null)
        {
            Debug.LogError("Cant find panel");
            return;
        }

        for(int i = 0; i < m_MenuPanels.Count;i++)
            m_MenuPanels[i].m_MenuPanel.SetActive(false);

        _panel.m_MenuPanel.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetPanel(r_MenuState.SetUsername);

        if (PlayerPrefs.HasKey("_Username"))
            m_UsernameInput.text = PlayerPrefs.GetString("_Username");
        else m_UsernameInput.text = "Guest";

        m_SetUsernameButton.onClick.AddListener(SetUsername);
        m_PlayButton.onClick.AddListener(delegate { r_Client.ConnectToServer(); SetPanel(r_MenuState.Connecting); });
    }

    private void SetUsername()
    {
        if (!string.IsNullOrEmpty(m_UsernameInput.text))
        {
            PlayerPrefs.SetString("_Username", m_UsernameInput.text);
            //r_DataSender.SendNetworkName(m_UsernameInput.text);
            SetPanel(r_MenuState.MainMenu);
        }
    }

}
