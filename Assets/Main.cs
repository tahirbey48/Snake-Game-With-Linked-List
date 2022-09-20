using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Main : MonoBehaviour
{


    private CubeList cubeList;
    [SerializeField] float speed = 10;
    [SerializeField] GameObject headCube;
    private Vector3 moveDirection = Vector3.forward;

    int i = 0;
    private void Awake()
    {
        cubeList = new CubeList(0, headCube);
    }
    void Start()
    {

    }

    void Update()
    {

        MoveHeadOfLinkedList();
        AppendCubes();
        TranslationMethodForTail();


    }

    private void AppendCubes()
    {
        if (Input.GetKeyDown("c"))
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject myText = new GameObject();
            cube.transform.localPosition = new Vector3(0, 0, 0);
            cubeList.append_cube(3, cube);

            myText.transform.SetParent(cube.transform);
            TextMesh textMesh = myText.AddComponent<TextMesh>();
            textMesh.text = 3.ToString();
            textMesh.color = Color.black;
        }
    }

    private void MoveHeadOfLinkedList()
    {
        cubeList.head.body.transform.position = Vector3.MoveTowards(cubeList.head.body.transform.position, new Vector3(cubeList.head.body.transform.position.x, cubeList.head.body.transform.position.y, cubeList.head.body.transform.position.z) + moveDirection, 0.1f);

        if (Input.GetKeyDown("a"))
        {
            float a = moveDirection.x;
            float b = moveDirection.y;
            float c = moveDirection.z;
            moveDirection = new Vector3(-c, b, a);
        }

        if (Input.GetKeyDown("d"))
        {
            float a = moveDirection.x;
            float b = moveDirection.y;
            float c = moveDirection.z;
            moveDirection = new Vector3(c, b, -a);
        }
    }

    private void TranslationMethodForTail()
    {
        
        Cube tmp = cubeList.head;
        if (cubeList.head.next != null)
        {
            Cube follower = tmp.next;
            
            while (follower != null)   
            {
                if (Vector3.Distance(follower.body.transform.position, tmp.body.transform.position) > 1.2)
                { 
                follower.body.transform.position = Vector3.MoveTowards(follower.body.transform.position,  tmp.body.transform.position, 0.1f);
                }
                tmp = tmp.next;
                follower = follower.next;  
            }
        }           
    }



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

    public void delete_gameobject(CubeList list, int ind)
    {
        Destroy(list.get_cube(ind).body);
        list.remove_cube(ind);
    }


    public void refreshColor(CubeList list)
    {
        Cube tmp = list.head;
        while (tmp.next != null)
        {
            tmp.body.GetComponent<MeshRenderer>().material.color = Color.white;
            list.head.body.GetComponent<MeshRenderer>().material.color = Color.green;
            list.tail.body.GetComponent<MeshRenderer>().material.color = Color.blue;
            tmp = tmp.next;
        }
    }
}
