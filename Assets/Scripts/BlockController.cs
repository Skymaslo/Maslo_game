using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private bool isDying = false;
    public float destroyTime = 1;
    public Material materialDying;


    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isDying == false)
            {
                isDying = true;
                Destroy(gameObject, destroyTime);
                meshRenderer.material = materialDying;
            }
        }

    }
}
