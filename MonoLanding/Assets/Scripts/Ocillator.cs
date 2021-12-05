using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float Period = 2f;

    void Start()
    {
        startingPosition = transform.position; //current position
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Period <= Mathf.Epsilon){return;}
        float cycles = Time.time / Period; // geçen zamanı 2 ye bölüp tam bir döngüyü buluyoruz.

        const float tau = Mathf.PI *2; // pi gibi özel bir değer "tau".6.283
        float rawSinWawe = Mathf.Sin(cycles * tau); //döngü ile tau çarpılıp -1 ve 1 arasında gidip gelmesi sağlanıyor.

        movementFactor = (rawSinWawe +1f)/2; // -1 den 1 e gideceğine 0 dan 1 e gitsin.
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
