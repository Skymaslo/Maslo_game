using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider boxCollider;

    Vector3 leftTop;
    Vector3 rightTop;
    Vector3 rightBottom;
    Vector3 leftBottom;

    public GameObject Block;
    public int blockCount;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        Bounds bounds = boxCollider.bounds;
        rightTop = new Vector3(
            bounds.center.x - bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z + bounds.size.z / 2
            );
        leftTop = new Vector3(
            bounds.center.x + bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z + bounds.size.z / 2
            );
        leftBottom = new Vector3(
            bounds.center.x + bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z - bounds.size.z / 2
            );
        rightBottom = new Vector3(
            bounds.center.x - bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z - bounds.size.z / 2
            );

        print("center: " + bounds.center); 
        print("size: " + bounds.size);

        for (int i = 0; blockCount > i; i++)
        {
            Spawnblock();
        }
        
    }

    public void Spawnblock()
    {
        float xDiff = rightTop.x + leftTop.x;
        float spawnX = leftTop.x - Random.Range(0, xDiff);

        float zDiff = rightTop.z + rightBottom.z;
        float spawnZ = leftTop.z - Random.Range(0, zDiff);

        //Instantiate(что спавним, где спавним, как поворачиваем);
        Instantiate(Block, new Vector3(spawnX, rightTop.y, spawnZ), Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        boxCollider = GetComponent<BoxCollider>();

        Bounds bounds = boxCollider.bounds;
        rightTop = new Vector3(
            bounds.center.x - bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z + bounds.size.z / 2
            );
        leftTop = new Vector3(
            bounds.center.x + bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z + bounds.size.z / 2
            );
        leftBottom = new Vector3(
            bounds.center.x + bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z - bounds.size.z / 2
            );
        rightBottom = new Vector3(
            bounds.center.x - bounds.size.x / 2,
            bounds.center.y,
            bounds.center.z - bounds.size.z / 2
            );

        Gizmos.DrawSphere(rightBottom, 3);
        Gizmos.DrawSphere(leftBottom, 3);
        Gizmos.DrawSphere(leftTop, 3);
        Gizmos.DrawSphere(rightTop, 3);

    }


    // Update is called once per frame
    void Update()
    {

    }
}
