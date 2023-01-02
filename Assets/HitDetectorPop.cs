using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorPop : MonoBehaviour
{
    [SerializeField] private string _popCube;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_popCube))
        {
            Destroy(collision.gameObject);
            Main.instance.pop_gameobject(Main.instance.cubeList);
            Main.instance.popOnStage--;
        }

    }

}
