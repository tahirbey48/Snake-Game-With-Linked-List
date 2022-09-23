using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorHead : MonoBehaviour
{
    public static Main instance;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Event verildi");
        if (collision.gameObject.tag == "Cube")
        //if (collision.gameObject.GetComponent<MeshFilter>().mesh.name == "Cube Instance")
        {
            //int value = Random.Range(0, 50);
            Destroy(collision.gameObject);
            //Main.instance.AppendCubes();
            Main.instance.AppendCubesWithHit(Main.instance.value);
            Main.instance.cubeOnStage = false;
        }
    }
}