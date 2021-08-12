using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] Transform playerBoat;

    // Update is called once per frame
    void Update()
    {
        var distanceToPlane = Vector3.Dot(playerBoat.right, targetEnemy.position - objectToPan.position);
        var planePoint = targetEnemy.position - playerBoat.right * distanceToPlane;
        objectToPan.LookAt(planePoint, playerBoat.right);  
    }
    //objectToPan.localPosition.y
    //objectToPan.transform.position.y
    //Vector3 targetPosition = new Vector3 (targetEnemy.position.x, objectToPan.position.y, targetEnemy.position.z);
}
