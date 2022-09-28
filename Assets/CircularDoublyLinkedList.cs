using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularDoublyLinkedList
{
    // Start is called before the first frame update
    public DNode head;
    public DNode tail;
    public int length;

    public CircularDoublyLinkedList(Vector3 value)
    {
        DNode newnode = new DNode(value);
        head = newnode;
        tail = newnode;
        length = 1;
    }


    public void AppendFromHead(Vector3 value)
    {
        DNode tmp = new DNode(value);
        if (head == null)
        {
            head = tmp;
            tail = tmp;
        }
        tail.next = tmp;
        tmp.next = head;
        head.prev = tmp;
        tmp.prev = tail;
        head = tmp;
        length++;
    }



}


[SerializeField]
public class DNode
{
    public Vector3 vector3D;
    public DNode next;
    public DNode prev;
    public DNode(Vector3 i)
    {
        vector3D = i;
        next = null;
        prev = null;
    }
}
