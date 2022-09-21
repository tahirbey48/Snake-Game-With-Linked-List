using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public static Main instance;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            //int value = Random.Range(0, 50);
            Destroy(this.gameObject);
            //Main.instance.AppendCubes();
            Main.instance.AppendCubesWithHit(Main.instance.value);
            Main.instance.cubeOnStage = false;
        }
    }
}
