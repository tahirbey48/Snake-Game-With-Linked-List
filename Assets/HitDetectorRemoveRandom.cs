using UnityEditor.UIElements;
using UnityEngine;

public class HitDetectorRemoveRandom : MonoBehaviour
{
    [SerializeField] private string _removeRandomTag;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RemoveRandom"))
        {
            int del = Random.Range(1, Main.instance.cubeList.length - 1);
            Destroy(collision.gameObject);
            Main.instance.delete_gameobject(Main.instance.cubeList, del);
        }
    }



}