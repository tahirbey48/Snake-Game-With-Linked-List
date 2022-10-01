using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeListMonoBehavior : MonoBehaviour
{
   


        public CubeMonoBehavior head;
        public CubeMonoBehavior tail;
        public int length;


        public CubeListMonoBehavior(int value, GameObject cube)
        {
            CubeMonoBehavior newcube = new CubeMonoBehavior(value, cube);
            head = newcube;
            tail = newcube;
            length = 1;
        }


        public void AppendCubeListMonoBehavior(int value, GameObject cube)
        {

        }






}




[SerializeField]
public class CubeMonoBehavior : MonoBehaviour
{


    public int value;
    public GameObject body;
    public CubeMonoBehavior next;

    public CubeMonoBehavior(int newvalue, GameObject newbody)
    {
        value = newvalue;
        next = null;
        body = newbody;
    }




}

