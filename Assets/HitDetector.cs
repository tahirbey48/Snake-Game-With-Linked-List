using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HitDetector : MonoBehaviour
{

    [SerializeField] private string _normalCube;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_normalCube))
        {
            Destroy(collision.gameObject);
            Main.instance.AppendCubesWithHit(Main.instance.value);
            Main.instance.cubeOnStage = false;
        }
    }
        
    

}




