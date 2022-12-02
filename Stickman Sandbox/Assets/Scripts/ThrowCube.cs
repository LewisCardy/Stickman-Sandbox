using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
    //when the player throws a cube

    public GameObject throwPoint;
    //public Transform attackPoint;
    public GameObject cube;

    public float force;
    // Start is called before the first frame update

    public void ThrowCubeProjectile(){ //creates the cube at the postion of the hand on the player and propells it forward
        GameObject projectile = Instantiate(cube, throwPoint.transform.position + new Vector3 (0, 1, 1), throwPoint.transform.rotation);

        Rigidbody cubeRigidBody = projectile.GetComponent<Rigidbody>();

        cubeRigidBody.AddForce(force, 0, 0, ForceMode.Impulse);
    }
}
