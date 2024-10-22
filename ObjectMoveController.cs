using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveController : MonoBehaviour
{
    [SerializeField] 
    private float m_Amplitude = 1;
    [SerializeField]
    private float m_Period = 1;
    [SerializeField, Range(0, 1)] 
    private float m_Phase = 0;

    private enum Axis
    {
        X,
        Y,
        Z
    }

    [SerializeField]
    private Axis axis;

    private Transform m_Transform;
    private Vector3 InitPosition;

    private bool isStopped = false;
    private float stopTime = 0f;

    private void Awake()
    {
        m_Transform = transform;
        InitPosition = m_Transform.localPosition;
    }

    private void Update()
    {
        if (isStopped)
        {
            stopTime -= Time.deltaTime;
            if (stopTime <= 0)
            {
                isStopped = false;
            }
            return;
        }

        var t = 4 * m_Amplitude * (Time.time / m_Period + m_Phase + 0.25f);
        var value = Mathf.PingPong(t, 2 * m_Amplitude) - m_Amplitude;

        Vector3 changePos = Vector3.zero;

        switch (axis)
        {
            case Axis.X:
                changePos.x = value;
                break;
            case Axis.Y:
                changePos.y = value;
                break;
            case Axis.Z:
                changePos.z = value;
                break;
        }

        m_Transform.localPosition = InitPosition + changePos;
    }
}
