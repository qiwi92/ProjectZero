using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{


    public class EnemyPrefabController : MonoBehaviour {
    
        public GameObject hpBar;
        public GameObject hpBarFrame;

        public GameObject enemyObject;

        public Animator killAnimation;
        public AudioSource explotionSound;


        private void Start()
        {
            //killAnimation.StartPlayback();
        }

        public void setHpBar(float currenthp, float maxHp)
        {
            var currentScaling = currenthp / maxHp;
            hpBar.transform.localScale = new Vector3(currentScaling, 1, 1);
        }


        public void DisplayHpBar(Enemy enemy, bool isActive)
        {
            hpBar.SetActive(isActive);
            hpBarFrame.SetActive(isActive);
        }

        public Transform Transform()
        {
            return enemyObject.transform;
        }

    }
}