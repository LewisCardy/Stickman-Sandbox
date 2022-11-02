using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelagate : MonoBehaviour
{

    public GameObject leftArmAttackPoint, rightArmAttackPoint, footAttackPoint;

    void leftArmAttackOn(){
        leftArmAttackPoint.SetActive(true);
    }
    void leftArmAttackOff(){
        if(leftArmAttackPoint.activeInHierarchy){
            leftArmAttackPoint.SetActive(false);
        }
    }

    void rightArmAttackOn(){
        rightArmAttackPoint.SetActive(true);
    }
    void rightArmAttackOff(){
        if(rightArmAttackPoint.activeInHierarchy){
            rightArmAttackPoint.SetActive(false);
        }
    }

    void footAttackOn(){
        footAttackPoint.SetActive(true);
    }
    void footAttackOff(){
        if(footAttackPoint.activeInHierarchy){
            footAttackPoint.SetActive(false);
        }
    }

}
