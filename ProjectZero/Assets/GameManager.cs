using System.Collections;
using System.Collections.Generic;
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
        public GunController GunController;
        public shieldController shieldController;
        public Enemy Enemy;

        public UiText UiText;


        void Start()
        {
            //SetUp to avoid time issues with initialization
            DebreeController.SetUp();
            EnemyController.SetUp();

            TractorBeamController.DebreeController = DebreeController;
            LaserController.Player = PlayerMovementController;
            LaserController.EnemyController = EnemyController;

            GunController.Player = PlayerMovementController;
            GunController.EnemyController = EnemyController;
            GunController.LaserController = LaserController;

            shieldController.EnemyController = EnemyController;
            shieldController.Player = PlayerMovementController;
        }


        void Update()
        {

        }
    }
}
