using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//Object camera follows

    public float followSpeed = 5f;//Speed camera follows player

    public Vector3 offset;//Camera offset from player

    void LateUpdate()//Runs after Update
    {
        if (target == null)//Checks if target is missing
        {
            return;//Stops code
        }

        Vector3 targetPosition = target.position + offset;//Gets target position with offset

        targetPosition.z = transform.position.z;//Keeps camera Z position

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);//Moves camera smoothly
    }
}
