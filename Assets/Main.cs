using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Main : MonoBehaviour
{

    
  

    public static Main instance;


    
    public CubeList cubeList;
    
    [SerializeField] GameObject headCube; //head node, initialize the linkedlist with this nead not as the body part of the first Node.
    //starting direction of head movement
    private Vector3 moveDirection = Vector3.forward;

    [SerializeField] GameObject CubeToSpawnPrefab;
    [SerializeField] GameObject popPrefab;
    [SerializeField] GameObject removePrefab;

    [Header("Variables and relevant class references for camera position arrangesments.")]
    private Vector3 cameraPosition;
    private DNode tmpCamera;
    private LinkedList<Vector3> myCameraPositions;
    private LinkedListNode<Vector3> tmp;
    private CircularDoublyLinkedList circularCameraLocalPositions;
    [SerializeField] private GameObject transfornCamera;
    [SerializeField] private Camera cam2; //Second Camera for TPP View.
    public GameObject cameraTarget; // Virtual Camera follows this gameobject.

    [Header("Fine tuning")]
    private float timeRemaining = 5;
    public int popOnStage; //its accessor is public since it is accessed outside of the class.
    [SerializeField] float speed = 10;


    public bool cubeOnStage; //its public since it is accessed outside of the class.
    public int value;

    private void Awake()
    {
        popOnStage = 0;
        //Camera positions are appended to Circular doubly Linked list so as to switch based on orientation of the head of the CubeList.
        circularCameraLocalPositions = new CircularDoublyLinkedList(new Vector3(-2, 2, 0));
        circularCameraLocalPositions.AppendFromHead(new Vector3(0, 2, 2));
        circularCameraLocalPositions.AppendFromHead(new Vector3(2, 2, 0));
        circularCameraLocalPositions.AppendFromHead(new Vector3(0, 2, -2));
        tmpCamera = circularCameraLocalPositions.head;


        cubeList = new CubeList(0, headCube); // I decided to start the game with a head that is premliminary created, so that I could make camera arrangements. Then I initialized the first object of the class.
        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }


   
    void Start()
    {
        cubeOnStage = false;
    }

    void Update()
    {
        SpawnCubesToRemoveRandom();
        SpawnCubesToPop();
        MoveHeadOfLinkedList();
        TranslationMethodForTail();
        SpawnCubesToAppend();
    }

    private void SpawnCubesToRemoveRandom()
    {
        if (timeRemaining > 0)
        {
            Debug.Log(timeRemaining);
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 10;
            float Xrandom = Random.Range(-13, 13);
            float Zrandom = Random.Range(-13, 13); // We made sure the spawns are on the main pitch.
            GameObject randomCube = Instantiate(removePrefab);
            randomCube.AddComponent<BoxCollider>();
            randomCube.AddComponent<HitDetectorRemoveRandom>();
            GameObject myText = new GameObject();
            myText.transform.SetParent(randomCube.transform);
            myText.transform.localPosition = new Vector3(-0.342999995f, 1.49800003f, 0.150999993f);
            TextMesh textMesh = myText.AddComponent<TextMesh>();
            //value = Random.Range(32458, 50008);
            textMesh.text = "Remove Random";
            TextMeshConfig(textMesh);
            randomCube.transform.position = new Vector3(Xrandom, 0.66f, Zrandom);

        }
    }

    

    private void SpawnCubesToPop()
    {
        if (popOnStage < 2)
        {
            float Xrandom = Random.Range(-13, 13);
            float Zrandom = Random.Range(-13, 13);
            GameObject randomCube = Instantiate(popPrefab);
            randomCube.AddComponent<BoxCollider>();
            //GameObject randomCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            randomCube.AddComponent<HitDetectorPop>();
            GameObject myText = new GameObject();
            myText.transform.SetParent(randomCube.transform);
            myText.transform.localPosition = new Vector3(-0.342999995f, 1.49800003f, 0.150999993f);
            TextMesh textMesh = myText.AddComponent<TextMesh>();
            textMesh.text = "POP";
            TextMeshConfig(textMesh);
            randomCube.transform.position = new Vector3(Xrandom, 0.66f, Zrandom);
            popOnStage++;
        }
    }

    private void SpawnCubesToAppend()
    {
    if (!cubeOnStage)
    {
        float Xrandom = Random.Range(-13, 13);
        float Zrandom = Random.Range(-13, 13);
        GameObject randomCube = Instantiate(CubeToSpawnPrefab);
        //GameObject randomCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        randomCube.AddComponent<BoxCollider>();
        randomCube.AddComponent<HitDetector>();
        GameObject myText = new GameObject();
        myText.transform.SetParent(randomCube.transform);
        myText.transform.localPosition = new Vector3(-0.342999995f, 1.49800003f, 0.150999993f);
        TextMesh textMesh = myText.AddComponent<TextMesh>();
        value = Random.Range(32245, 50008);
        textMesh.text = value.ToString();
        TextMeshConfig(textMesh);
        randomCube.transform.position = new Vector3(Xrandom, 0.66f, Zrandom);
        cubeOnStage = true;
    }
    }

    public void AppendCubesWithHit(int value)
    {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cube = Instantiate(CubeToSpawnPrefab);
        GameObject myText = new GameObject();
        cube.transform.position = cubeList.tail.body.transform.position;
        cubeList.append_cube(value, cube);
        myText.transform.SetParent(cube.transform);
        myText.transform.localPosition = new Vector3(-0.342999995f, 1.49800003f, 0.150999993f);
        TextMesh textMesh = myText.AddComponent<TextMesh>();
        textMesh.text = value.ToString();
        TextMeshConfig(textMesh);
    }


    //To Avoid Repetitive Code
    private static void TextMeshConfig(TextMesh textMesh)
    {
        textMesh.anchor = TextAnchor.UpperCenter; // Arrangments are made during the game, and set in script.
        textMesh.characterSize = 0.73f; // Arrangments are made during the game, and set in script.
        textMesh.fontStyle = FontStyle.Bold;
        textMesh.fontSize = 10;
        textMesh.color = Color.black;
    }
    private void MoveHeadOfLinkedList()
    {
        //cubeList.head.body.transform.position = Vector3.MoveTowards(cubeList.head.body.transform.position, new Vector3(cubeList.head.body.transform.position.x, cubeList.head.body.transform.position.y, cubeList.head.body.transform.position.z) + moveDirection, 0.1f);
        cubeList.head.body.transform.position = Vector3.MoveTowards(cubeList.head.body.transform.position, cubeList.head.body.transform.position + moveDirection, 0.1f);

        if (Input.GetKeyDown("a"))
        {
            float a = moveDirection.x;
            float b = moveDirection.y;
            float c = moveDirection.z;
            moveDirection = new Vector3(-c, b, a);
            tmpCamera = tmpCamera.next;
            cameraTarget.transform.DOLocalMove(tmpCamera.vector3D,1);
            transfornCamera.transform.DOLookAt(moveDirection, 1);
        }

        if (Input.GetKeyDown("d"))
        {
            float a = moveDirection.x;
            float b = moveDirection.y;
            float c = moveDirection.z;
            moveDirection = new Vector3(c, b, -a);
            tmpCamera = tmpCamera.prev;
            cameraTarget.transform.DOLocalMove(tmpCamera.vector3D, 1);
            transfornCamera.transform.DOLookAt(moveDirection, 1);
        }


        if (Input.GetKeyDown("r"))
        {
            int del = Random.Range(1, cubeList.length-1);
            delete_gameobject(cubeList, del);
            Debug.Log("Deleted");
        }


        if (Input.GetKey("l"))
        {
            cam2.depth = 4;
        } else
        {
            cam2.depth = 2;
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

    public void delete_gameobject(CubeList list, int ind)
    {
        Destroy(list.get_cube(ind).body);
        list.remove_cube(ind);
    }
  
}
