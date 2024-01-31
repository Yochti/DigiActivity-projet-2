using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeRotation : MonoBehaviour
{
    public GameObject cube;
    float rotationSpeed = 90f; 
    float rotationTime;
    public TextMeshProUGUI chronometerText;
    float rotationCooldown = 10f;
    public Transform from;
    public Transform to;
    float speed = 1f;
    float timeCount = 0.0f;
    bool isRotating = false;
    private int rotationCubeInt = 90;// la valeur dont le cube va tourner toutes les 10 secondes
    private void Update()
    {
        if(!isRotating)
        {
            rotationTime += Time.deltaTime;
            chronometerText.text = (rotationCooldown - rotationTime).ToString("F2");
            //print(rotationTime);
            if (rotationTime >= rotationCooldown)
            {
                isRotating = true;
                StartCoroutine(RotationCoroutine());
                rotationTime = 0f;
            }
        }
        
        
    }
    /*private void RotationOnCube()
    {
        //cube.transform.Rotate(Vector3.forward, rotationSpeed);
        
    }*/
    IEnumerator RotationCoroutine()
    {
        
        while(timeCount < 1)
        {
            yield return null;
            transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, timeCount);
            timeCount += Time.deltaTime * speed;
            //print(timeCount);
        }
        transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, 1);
        timeCount = 0;
        from.rotation = Quaternion.Euler(from.rotation.eulerAngles.x , from.rotation.eulerAngles.y, from.rotation.eulerAngles.z + rotationCubeInt);
        to.rotation = Quaternion.Euler(to.rotation.eulerAngles.x, to.rotation.eulerAngles.y, to.rotation.eulerAngles.z + rotationCubeInt);
        print(to.rotation.z);
        isRotating = false;
        
    }

}