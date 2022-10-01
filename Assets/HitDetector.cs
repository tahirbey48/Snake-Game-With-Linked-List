using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HitDetector : MonoBehaviour
{



    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            Destroy(this.gameObject);
            Main.instance.AppendCubesWithHit(Main.instance.value);
            Main.instance.cubeOnStage = false;
        }
    }
        
    

}




