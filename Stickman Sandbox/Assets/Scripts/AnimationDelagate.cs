using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelagate : MonoBehaviour
{
    //handles the creation of the attack points when the animation is played

    public GameObject leftArmAttackPoint, rightArmAttackPoint, footAttackPoint;

    void Start(){ //deactivates attack points
        leftArmAttackPoint.SetActive(false);
        rightArmAttackPoint.SetActive(false);
        footAttackPoint.SetActive(false);
    }

    //for each attack point turn it on when activated as part of the animation
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
