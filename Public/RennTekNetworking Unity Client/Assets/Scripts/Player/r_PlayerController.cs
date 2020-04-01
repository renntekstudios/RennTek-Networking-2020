using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_PlayerController : MonoBehaviour
{
    [Header("Character Controller")]
    public CharacterController m_CharacterController;

    [Header("Movement Configuration")]
    public float m_MovementSpeed;
    public float m_Gravity = 20f;

    [Header("Move Direction")]
    public Vector3 m_MoveDirection;

    //Movement
    private float m_Horizontal;
    private float m_Vertical;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (m_CharacterController.isGrounded)
        {
            m_Horizontal = GetHorizontal();
            m_Vertical = GetVertical();

            m_MoveDirection = new Vector3(m_Horizontal, 0f, m_Vertical);
            m_MoveDirection *= m_MovementSpeed;
        }

        m_MoveDirection.y -= m_Gravity * Time.deltaTime;
        m_CharacterController.Move(m_MoveDirection * Time.deltaTime);
    }

    public float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetVertical()
    {
        return Input.GetAxis("Vertical");
    }
}