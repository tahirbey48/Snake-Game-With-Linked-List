using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HitDetectorReverse : MonoBehaviour
{



    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Event verildi");
        if (collision.gameObject.tag == "Head")
        {
            Destroy(this.gameObject);
            Main.instance.reverseList(Main.instance.cubeList);
        }

    }



}