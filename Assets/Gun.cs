using UnityEngine;

namespace Assets
{
    public class Gun
    {
        public static int FireRateLevel;
        public static int DamageLevel;

        public static float FireRate()
        {
            var fireRate = 0.3f - FireRateLevel * 0.01f * _boost(FireRateLevel);
            return fireRate;
        }

        public static float FireRateCost(int level)
        {
            var cost = 100 * Mathf.Pow(1.2f, level - 1);
            return cost;
        }

        public static float Damage()
        {
            var cost = 1 * Mathf.Pow(1.1f, DamageLevel - 1)*_boost(DamageLevel);
            return cost;
        }

        public static float DamageCost(int level)
        {
            var cost = 1000 * Mathf.Pow(1.2f, level - 1);
            return cost;
        }

        public static float Accuracy(int level)
        {
            return 1;
        }

        public static float AccuracyCost(int level)
        {
            return 1;
        }

        private static float _boost (int level)
        {
            if (level >= 10)
            {
                return 2f;
            }
            if (level >= 25)
            {
                return 2*1.5f;
            }
            return 1;
        }
    }
}