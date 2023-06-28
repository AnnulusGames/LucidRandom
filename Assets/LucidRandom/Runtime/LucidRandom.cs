using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnnulusGames.LucidTools.RandomKit
{
    public static class LucidRandom
    {
        private static RandomGenerator instance = new RandomGenerator((int)System.DateTime.Now.Ticks);
        private static Dictionary<string, RandomGenerator> dictionary = new Dictionary<string, RandomGenerator>();

        public static RandomGenerator AddGenerator(string key, int seed)
        {
            RandomGenerator random = new RandomGenerator(seed);
            dictionary.Add(key, random);
            return random;
        }

        public static bool RemoveGenerator(string key)
        {
            return dictionary.Remove(key);
        }

        public static void RemoveAllGenerators()
        {
            dictionary.Clear();
        }

        public static RandomGenerator GetGenerator(string key)
        {
            return dictionary[key];
        }

        public static Random.State state
        {
            get => instance.state;
            set => instance.state = value;
        }

        public static void InitState(int seed)
        {
            instance.InitState(seed);
        }

        public static float Range(float min, float max)
        {
            return instance.Range(min, max);
        }

        public static int Range(int min, int max)
        {
            return instance.Range(min, max);
        }

        public static Vector2 Range(Vector2 min, Vector2 max)
        {
            return instance.Range(min, max);
        }

        public static Vector2Int Range(Vector2Int min, Vector2Int max)
        {
            return instance.Range(min, max);
        }
        public static Vector3 Range(Vector3 min, Vector3 max)
        {
            return instance.Range(min, max);
        }

        public static Vector3Int Range(Vector3Int min, Vector3Int max)
        {
            return instance.Range(min, max);
        }

        public static Vector4 Range(Vector4 min, Vector4 max)
        {
            return instance.Range(min, max);
        }

        public static int Range(MinMaxInt minMaxValue)
        {
            return instance.Range(minMaxValue);
        }

        public static float Range(MinMaxFloat minMaxValue)
        {
            return instance.Range(minMaxValue);
        }

        public static Vector2 Range(MinMaxVector2 minMaxValue)
        {
            return instance.Range(minMaxValue);
        }

        public static Vector2Int Range(MinMaxVector2Int minMaxValue)
        {
            return instance.Range(minMaxValue);
        }

        public static Vector3 Range(MinMaxVector3 minMaxValue)
        {
            return instance.Range(minMaxValue);
        }

        public static Vector3Int Range(MinMaxVector3Int minMaxValue)
        {
            return instance.Range(minMaxValue);
        }

        public static float value
        {
            get
            {
                return instance.value;
            }
        }

        public static bool valueBool
        {
            get
            {
                return instance.valueBool;
            }
        }

        public static Vector3 insideUnitSphere
        {
            get
            {
                return instance.insideUnitSphere;
            }
        }

        public static Vector2 insideUnitCircle
        {
            get
            {
                return instance.insideUnitCircle;
            }
        }

        public static Vector3 insideUnitCube
        {
            get
            {
                return instance.insideUnitCube;
            }
        }

        public static Vector2 insideUnitSquare
        {
            get
            {
                return instance.insideUnitSquare;
            }
        }

        public static Vector3 onUnitSphere
        {
            get
            {
                return instance.onUnitSphere;
            }
        }

        public static Vector2 onUnitCircle
        {
            get
            {
                return instance.onUnitCircle;
            }
        }

        public static Vector3 onUnitCube
        {
            get
            {
                return instance.onUnitCube;
            }
        }

        public static Vector2 onUnitSquare
        {
            get
            {
                return instance.onUnitSquare;
            }
        }

        public static Quaternion rotation
        {
            get
            {
                return instance.rotation;
            }
        }

        public static Quaternion rotationUniform
        {
            get
            {
                return instance.rotationUniform;
            }
        }

        public static Color ColorHSV()
        {
            return instance.ColorHSV();
        }

        public static Color ColorHSV(float hueMin, float hueMax)
        {
            return instance.ColorHSV(hueMin, hueMax);
        }

        public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax)
        {
            return instance.ColorHSV(hueMin, hueMax, saturationMin, saturationMax);
        }

        public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax)
        {
            return instance.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);
        }

        public static Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float alphaMin, float alphaMax)
        {
            return instance.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, alphaMin, alphaMax);
        }

        public static bool GetChance(float probability)
        {
            return instance.GetChance(probability);
        }

        public static int RollDice(DiceType dice)
        {
            return instance.RollDice(dice);
        }

        public static int RollDice(int size, DiceType dice)
        {
            return instance.RollDice(size, dice);
        }

        public static T RandomElement<T>(WeightedList<T> weightedList)
        {
            return instance.RandomElement(weightedList);
        }

        public static T RandomElement<T>(IEnumerable<T> values)
        {
            return instance.RandomElement(values);
        }

        public static T RandomElement<T>(params T[] values)
        {
            return instance.RandomElement(values);
        }

        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> values)
        {
            return instance.Shuffle(values);
        }

        public static Color RandomColor(Gradient gradient)
        {
            return instance.RandomColor(gradient);
        }
    }
}