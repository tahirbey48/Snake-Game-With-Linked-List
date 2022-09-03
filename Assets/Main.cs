using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main : MonoBehaviour
{


    public GameObject border1;
    public GameObject border2;
    public GameObject border3;
    public GameObject border4;


    CubeList cubeList;
    int i = 0;
    private void Awake()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localPosition = new Vector3(0, 1, 0);
        //cube.transform.localScale = new Vector3(1, 1, 1);
        cube.GetComponent<MeshRenderer>().material.color = Color.red;
        cubeList = new CubeList(0, cube);
        //cubeList.append_cubes(0,cube);


        

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetMouseButtonDown(0))
        {
            i++;
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.localPosition = new Vector3(0, 1+2*i, 0);
            cubeList.append_cube(i, cube);
        }


        if (Input.GetMouseButtonDown(1))
        {
            pop_firstgameobject(cubeList);


        }

        if (Input.GetKey("s"))
        {
            cubeList.head.body.transform.position = Vector3.MoveTowards(cubeList.head.body.transform.position, border1.transform.position, 0.1f);
            Cube tmp = cubeList.head;
            Cube after = tmp.next;
            while (after != null)
            {
                after.body.transform.position = Vector3.MoveTowards(after.body.transform.position, tmp.body.transform.position, 0.1f);
                tmp = tmp.next;
                after = after.next;
            }
        }


        if (Input.GetKey("a"))
        {
            cubeList.head.body.transform.position = Vector3.MoveTowards(cubeList.head.body.transform.position, border4.transform.position, 0.1f);
            Cube tmp = cubeList.head;
            Cube after = tmp.next;
            while (after != null)
            {
                after.body.transform.position = Vector3.MoveTowards(after.body.transform.position, tmp.body.transform.position, 0.1f);
                tmp = tmp.next;
                after = after.next;
            }
        }



        if (Input.GetKey("q"))
        {
            cubeList.head.body.transform.position = Vector3.MoveTowards(cubeList.head.body.transform.position, border3.transform.position, 0.1f);
            Cube tmp = cubeList.head;
            Cube after = tmp.next;
            while (after != null)
            {
                after.body.transform.position = Vector3.MoveTowards(after.body.transform.position, tmp.body.transform.position, 0.1f);
                tmp = tmp.next;
                after = after.next;
            }
        }



        if (Input.GetKey("w"))
        {
            cubeList.head.body.transform.position = Vector3.MoveTowards(cubeList.head.body.transform.position, border2.transform.position, 0.1f);
            Cube tmp = cubeList.head;
            Cube after = tmp.next;
            while (after != null)
            {
                after.body.transform.position = Vector3.MoveTowards(after.body.transform.position, tmp.body.transform.position, 0.1f);
                tmp = tmp.next;
                after = after.next;
            }
        }


        if (Input.GetKey("d"))
        {
            int ind = Mathf.RoundToInt(i / 3); //index to delete
            Debug.Log("index to delete    " + ind);           
            //Cube before = cubeList.get_cube(ind-1);
            //Cube delete = before.next;
            //before.next = delete.next;
            //delete.next = null;
            Cube tmp = cubeList.get_cube(ind-1);
            Cube cubeToDelete = tmp.next;
            Cube afterDelete = cubeList.get_cube(ind + 1);
            cubeList.remove_cube(ind);
            Destroy(cubeToDelete.body);
            tmp.next = afterDelete;
            
            
            
        }

        //if (Input.GetKey("p"))
        //{
        //    Debug.Log("p pressed");
        //    cubeList.pop_cube();
        //    Destroy(cubeList.tail.body);
        //}





    }


























    //static Text CreateText(GameObject cube)
    //{
    //    cube.transform.parent = cube.parent;
    //    go.transform.parent = parent;
    //    var text = go.AddComponent<Text>();
    //    return text;
    //}



    //private GameObject addNewCube(int value, int i)
    //{


    //    GameObject newcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    newcube.transform.localPosition = new Vector3(0, 2 * i, 0);
    //    newcube.transform.localScale = new Vector3(1, 1, 1);
    //    newcube.AddComponent<Cube>();
    //    newcube.GetComponent<Cube>().value = value;
    //    newcube.GetComponent<Cube>().next = null;
    //    cubeList.append_cubes(value);
    //    cubeList.print_cubes();
    //    return newcube;


    //}




    //cube.transform.DOMove(border1.transform.position, 1).OnComplete(
    //           () =>
    //           {
    //};





    public void pop_gameobject(CubeList list)
    {
        Destroy(list.tail.body);
        list.pop_cube();
    }


    public void pop_firstgameobject(CubeList list)
    {
        Destroy(list.head.body);
        list.pop_first_cube();
    }


}