using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectorPop : MonoBehaviour
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
            Main.instance.pop_gameobject(Main.instance.cubeList);
            Main.instance.popOnStage--;
            //StartCoroutine(WaitAfterCollision(3));
        }

    }


    //IEnumerator WaitAfterCollision(float waitTime)
    //{

    //    yield return new WaitForSeconds(waitTime);
    //}
}
