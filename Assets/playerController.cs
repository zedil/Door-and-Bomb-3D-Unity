using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float moveSpeed = 5;
    public float rotSpeed = 240; //rotation açısaldır
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        //klavye okuma
        var moveAxis = Input.GetAxis("Vertical");
        var rotAxis = Input.GetAxis("Horizontal");

        //ilerlemesini sağlıyoruz
        transform.position += transform.forward * moveAxis * moveSpeed * Time.deltaTime;

        //dönüşünü sağlıyoruz.
        transform.rotation *= Quaternion.Euler(Vector3.up * rotSpeed * rotAxis* Time.deltaTime);
    }
}
