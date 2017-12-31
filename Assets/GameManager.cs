using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets
{
    public class GameManager : MonoBehaviour
    {

        public EnemyController EnemyController;
        public DebreeController DebreeController;
        public tractorBeamController TractorBeamController;
        public LaserController LaserController;
        public PlayerMovementController PlayerMovementController;


        public shieldController shieldController;
        public Enemy Enemy;


        
        public Shop Shop;

        public UiText UiText;


        void Start()
        {
            //SetUp to avoid time issues with initialization
            DebreeController.SetUp();
            EnemyController.SetUp();

            TractorBeamController.DebreeController = DebreeController;
            LaserController.Player = PlayerMovementController;
            LaserController.EnemyController = EnemyController;


            shieldController.EnemyController = EnemyController;
            shieldController.Player = PlayerMovementController;




        }


        void Update()
        {

        }
    }
}
