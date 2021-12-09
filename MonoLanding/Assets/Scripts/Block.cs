using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]int TimePassed =3;
    MeshRenderer Renderer;
    Rigidbody Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();

        Renderer.enabled = false;
        
        Rigidbody = GetComponent<Rigidbody>();

        Rigidbody.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > TimePassed)
        {
            Renderer.enabled =true;
            Rigidbody.useGravity = true;
        }
    }
}
