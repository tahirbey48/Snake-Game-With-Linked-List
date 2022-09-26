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
            //int value = Random.Range(0, 50);
            Destroy(this.gameObject);
            //Main.instance.AppendCubes();
            Main.instance.AppendCubesWithHit(Main.instance.value);
            Main.instance.cubeOnStage = false;
            StartCoroutine(WaitAfterCollision(3));
        }

    }


    IEnumerator WaitAfterCollision(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
    }

}