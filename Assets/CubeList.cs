using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CubeList
{


    public Cube head;
    public Cube tail;
    public int length;


    public CubeList(int value, GameObject cube)
    {
        Cube newcube = new Cube(value, cube);
        head = newcube;
        tail = newcube;
        length = 1;
    }


    public void append_cube(int value, GameObject cube)
    {
        Cube newcube = new Cube(value, cube);
        if(head == null)
        {
            head = newcube;
            tail = newcube;
        } else
        {
            tail.next = newcube;
            tail = newcube;
        }
        length++;

    }


    public void pop_cube()
    {
        if (length == 0)
            return;
        else if (length == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            Cube tmp = head;
            //while (tmp.next != tail)
            while (tmp.next != tail)
            {
                tmp = tmp.next;
            }
            tmp.next = null;
            tail = tmp;
        }
        length--;

    }



    public void pop_first_cube()
    {
        if (head == null)
            return;
        else if (length == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            Cube tmp = head;
            head = tmp.next;
            tmp.next = null;
        }
        length--;

    }


    public Cube get_cube(int index)
    {
        Cube tmp = head;
        int i = 0;
        while (i < index)
        {
            tmp = tmp.next;
            i++;
        }
        return tmp;
    }



    public void remove_cube(int index)
    {
        if (index > length && index < 0)
            return;
        if (head == null)
            return;
        if (index == 0)
        {
            this.pop_first_cube();
        }
        else if (index == length)
        {
            this.pop_cube();
        }
        else
        {
            Cube before = get_cube(index-1);
            Cube tmp = before.next;
            before.next = tmp.next;
            tmp.next = null;

        }
        length--;
    }

}


