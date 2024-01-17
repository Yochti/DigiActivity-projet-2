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
    private void Update()
    {
        rotationTime += Time.deltaTime;
        chronometerText.text =  (rotationCooldown-rotationTime).ToString("F2"); 
        print(rotationTime);
        if(rotationTime >= rotationCooldown)
        {
            RotationOnCube();
            rotationTime = 0f;
        }
    }
    private void RotationOnCube()
    {
        cube.transform.Rotate(Vector3.forward, rotationSpeed);
    }

}