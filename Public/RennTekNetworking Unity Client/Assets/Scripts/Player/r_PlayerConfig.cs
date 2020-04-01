using RennTekNetworking.Client.Public;
using RennTekNetworking.Client.Public.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_PlayerConfig : MonoBehaviour
{
    [Header("Scripts Enables")]
    public MonoBehaviour[] m_AllScripts;

    [Header("Netview")]
    public r_NetView m_NetView;

    private void Awake()
    {
        if (m_NetView == null)
            m_NetView = GetComponent<r_NetView>(); //damn im sleeping man really haha

        if (m_NetView == null)
            this.enabled = false;
    }

    private void Start()
    {
        if(m_NetView.IsMine())
            EnableScripts();
    }

    private void EnableScripts()
    {
        if (m_AllScripts.Length == 0) return;

        for (int i = 0; i < m_AllScripts.Length; i++)
        {
            m_AllScripts[i].enabled = true;
        }
    }
}
