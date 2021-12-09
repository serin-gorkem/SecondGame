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
    void Update()
    {
        if (Period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / Period; //We are dividing passed time to the period.

        const float tau = Mathf.PI * 2; //a constant like Pi "tau" and it's 6.283.. or 2pi.
        float rawSinWawe = Mathf.Sin(cycles * tau); //cycle multipiled by tau so the Wawe we created can go between -1 and 1.

        movementFactor = (rawSinWawe + 1f) / 2; //We are adjusting Wawe so it can go from 0 to 1.

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
