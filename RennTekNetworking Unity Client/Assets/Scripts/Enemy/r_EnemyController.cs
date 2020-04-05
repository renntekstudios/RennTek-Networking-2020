using RennTekNetworking.Client.Public.Controllers;
using RennTekNetworking.Client.Public.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_EnemyController : MonoBehaviour
{
    public GameObject[] m_TargetPoints;

    public int m_PointIndex;

    public float m_ChangeTargetDistance = 0.5f;
    public float m_MovementSpeed = 1f;

    public void Awake()
    {
        m_TargetPoints = GameObject.FindGameObjectsWithTag("Points"); 
    }

    private void GetNextPoint()
    {
        if (m_PointIndex == m_TargetPoints.Length - 1)
            m_PointIndex = 0;
        else m_PointIndex++;
    }

    private float GetDistance()
    {
        return Vector3.Distance(transform.position, m_TargetPoints[m_PointIndex].transform.position);
    }

    private Vector3 GetTargetPosition()
    {
        return m_TargetPoints[m_PointIndex].transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GetDistance() < m_ChangeTargetDistance)
        {
           // GetNextPoint();
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, GetTargetPosition(), m_MovementSpeed * Time.deltaTime);
          //  transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), m_MovementSpeed * Time.deltaTime);
        }
    }
}
