using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[SerializeField]
public class Cube
{
    public int value;
    public GameObject body;
    public Cube next;
    public Cube(int newvalue, GameObject newbody)
    {
        value = newvalue;
        next = null;
        body = newbody;
    }

}