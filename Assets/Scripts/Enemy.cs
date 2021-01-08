using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 10f;

    private Transform _target;
    private int _wapointIndex = 0;

    private void Start()
    {
        _target = Waypoints._wayPoints[0];
    }

    private void Update()
    {
        Vector3 movementDirection = _target.position - transform.position;
        transform.Translate(movementDirection.normalized * _speed * Time.deltaTime, Space.World) ;

        if(Vector3.Distance(transform.position, _target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if(_wapointIndex >= Waypoints._wayPoints.Length - 1)
        {
            Destroy(gameObject);
        }
        _wapointIndex++;
        _target = Waypoints._wayPoints[_wapointIndex];
    }
}
