using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCube : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 throwVector;
    Rigidbody _rigidBody;
    LineRenderer _lineRenderer;
    [SerializeField] Camera _camPlayer2;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ThrowDirection();
            ThrowLine();
        }

        if (Input.GetMouseButton(0))
        {
            ThrowDirection();
            ThrowLine();
        }
        if (Input.GetMouseButtonDown(0))
        {
            RemoveLine();
            ThrowCube();
        }

        if (Input.GetMouseButtonDown(1))
        {   StopAllCoroutines();
            StartCoroutine(MoveCube(new Vector3(0.5f,0.5f,0.5f)));
        }

        }







    //private void OnMouseDown()
    //{
    //    ThrowDirection();
    //    ThrowLine();
    //}

    //private void OnMouseDrag()
    //{
    //    ThrowDirection();
    //    ThrowLine();
    //}

    //private void OnMouseUp()
    //{
    //    RemoveLine();
    //    ThrowCube();
    //}
    public void ThrowDirection()
    {
        Vector3 finalDest = _camPlayer2.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = finalDest - transform.position;
        throwVector = - direction.normalized * 100;
    }

    public void ThrowLine()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, throwVector.normalized / 2);
        _lineRenderer.enabled = true;
    }
    private void ThrowCube()
    {
        _lineRenderer.enabled = false;
    }

    private void RemoveLine()
    {
        _rigidBody.velocity = throwVector *  0.1f;
    }

    
    IEnumerator MoveCube(Vector3 V0)
    {

        float time = 0;
        while (time < 4)
        {
            float x = V0.x * time;
            float y = V0.y - 0.5f * -Physics.gravity.y * Mathf.Pow(time, 2);
            float z = V0.z * time;
            transform.position = transform.position + new Vector3(x, y, z);
            time += Time.deltaTime;
            yield return null;
        }
        
        
        
    }


}
