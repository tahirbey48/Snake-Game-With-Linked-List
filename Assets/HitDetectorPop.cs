using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorPop : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            Destroy(this.gameObject);
            Main.instance.pop_gameobject(Main.instance.cubeList);
            Main.instance.popOnStage--;
        }

    }

}
