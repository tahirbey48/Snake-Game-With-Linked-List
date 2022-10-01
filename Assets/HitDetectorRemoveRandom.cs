using UnityEngine;

public class HitDetectorRemoveRandom : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Head")
        {
            int del = Random.Range(1, Main.instance.cubeList.length - 1);
            Debug.Log("Deleted");
            Destroy(this.gameObject);
            Main.instance.delete_gameobject(Main.instance.cubeList, del);
        }


    }



}