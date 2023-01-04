using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnnulusGames.LucidTools.RandomKit
{
    public class RandomGenerator
    {
        private Random.State state;

        public RandomGenerator(int seed)
        {
            InitState(seed);
        }

        public void InitState(int seed)
        {
            var prevState = Random.state;
            Random.InitState(seed);
            state = Random.state;
            Random.state = prevState;
        }

        public float Range(float min, float max)
        {
            var prevState = Random.state;
            Random.state = state;
            float result = Random.Range(min, max);
            state = Random.state;
            Random.state = prevState;

            return result;
        }

        public int Range(int min, int max)
        {
            var prevState = Random.state;
            Random.state = state;
            int result = Random.Range(min, max);
            state = Random.state;
            Random.state = prevState;

            return result;
        }

        public Vector2 Range(Vector2 min, Vector2 max)
        {
            return new Vector2(Range(min.x, max.x), Range(min.y, max.y));
        }

        public Vector2Int Range(Vector2Int min, Vector2Int max)
        {
            return new Vector2Int(Range(min.x, max.x), Range(min.y, max.y));
        }

        public Vector3 Range(Vector3 min, Vector3 max)
        {
            return new Vector3(Range(min.x, max.x), Range(min.y, max.y), Range(min.z, max.z));
        }

        public Vector3Int Range(Vector3Int min, Vector3Int max)
        {
            return new Vector3Int(Range(min.x, max.x), Range(min.y, max.y), Range(min.z, max.z));
        }

        public Vector4 Range(Vector4 min, Vector4 max)
        {
            return new Vector4(Range(min.x, max.x), Range(min.y, max.y), Range(min.z, max.z), Range(min.w, max.w));
        }

        public int Range(MinMaxInt minMaxValue)
        {
            int min = minMaxValue.min <= minMaxValue.max ? minMaxValue.min : minMaxValue.max;
            int max = minMaxValue.min <= minMaxValue.max ? minMaxValue.max : minMaxValue.min;
            return Range(min, max + 1);
        }

        public float Range(MinMaxFloat minMaxValue)
        {
            return Range(minMaxValue.min, minMaxValue.max);
        }

        public Vector2 Range(MinMaxVector2 minMaxValue)
        {
            return Range(minMaxValue.min, minMaxValue.max);
        }

        public Vector2Int Range(MinMaxVector2Int minMaxValue)
        {
            int xMin = minMaxValue.min.x <= minMaxValue.max.x ? minMaxValue.min.x : minMaxValue.max.x;
            int xMax = minMaxValue.min.x <= minMaxValue.max.x ? minMaxValue.max.x : minMaxValue.min.x;
            int yMin = minMaxValue.min.y <= minMaxValue.max.y ? minMaxValue.min.y : minMaxValue.max.y;
            int yMax = minMaxValue.min.y <= minMaxValue.max.y ? minMaxValue.max.y : minMaxValue.min.y;
            return new Vector2Int(Range(xMin, xMax + 1), Range(yMin, yMax + 1));
        }

        public Vector3 Range(MinMaxVector3 minMaxValue)
        {
            return Range(minMaxValue.min, minMaxValue.max);
        }

        public Vector3Int Range(MinMaxVector3Int minMaxValue)
        {
            int xMin = minMaxValue.min.x <= minMaxValue.max.x ? minMaxValue.min.x : minMaxValue.max.x;
            int xMax = minMaxValue.min.x <= minMaxValue.max.x ? minMaxValue.max.x : minMaxValue.min.x;
            int yMin = minMaxValue.min.y <= minMaxValue.max.y ? minMaxValue.min.y : minMaxValue.max.y;
            int yMax = minMaxValue.min.y <= minMaxValue.max.y ? minMaxValue.max.y : minMaxValue.min.y;
            int zMin = minMaxValue.min.z <= minMaxValue.max.z ? minMaxValue.min.z : minMaxValue.max.z;
            int zMax = minMaxValue.min.z <= minMaxValue.max.z ? minMaxValue.max.z : minMaxValue.min.z;
            return new Vector3Int(Range(xMin, xMax + 1), Range(yMin, yMax + 1), Range(zMin, zMax + 1));
        }

        public Color ColorHSV()
        {
            return ColorHSV(0f, 1f, 0f, 1f, 0f, 1f, 1f, 1f);
        }

        public Color ColorHSV(float hueMin, float hueMax)
        {
            return ColorHSV(hueMin, hueMax, 0f, 1f, 0f, 1f, 1f, 1f);
        }

        public Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax)
        {
            return ColorHSV(hueMin, hueMax, saturationMin, saturationMax, 0f, 1f, 1f, 1f);
        }

        public Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax)
        {
            return ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, 1f, 1f);
        }

        public Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float alphaMin, float alphaMax)
        {
            var prevState = Random.state;
            Random.state = state;
            Color result = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax, alphaMin, alphaMax);
            state = Random.state;
            Random.state = prevState;

            return result;
        }

        public float value
        {
            get
            {
                var prevState = Random.state;
                Random.state = state;
                float result = Random.value;
                state = Random.state;
                Random.state = prevState;

                return result;
            }
        }

        public bool valueBool
        {
            get
            {
                return Range(0, 2) == 0;
            }
        }

        public Vector2 insideUnitCircle
        {
            get
            {
                var prevState = Random.state;
                Random.state = state;
                Vector2 result = Random.insideUnitCircle;
                state = Random.state;
                Random.state = prevState;

                return result;
            }
        }

        public Vector3 insideUnitSphere
        {
            get
            {
                var prevState = Random.state;
                Random.state = state;
                Vector3 result = Random.insideUnitSphere;
                state = Random.state;
                Random.state = prevState;

                return result;
            }
        }

        public Vector2 insideUnitSquare
        {
            get
            {
                return Range(Vector2.zero, Vector2.one);
            }
        }

        public Vector3 insideUnitCube
        {
            get
            {
                return Range(Vector3.zero, Vector3.one);
            }
        }

        public Vector3 onUnitSphere
        {
            get
            {
                var prevState = Random.state;
                Random.state = state;
                Vector3 result = Random.onUnitSphere;
                state = Random.state;
                Random.state = prevState;

                return result;
            }
        }

        public Vector2 onUnitCircle
        {
            get
            {
                return insideUnitCircle.normalized;
            }
        }

        public Vector3 onUnitCube
        {
            get
            {
                Vector3 p = insideUnitCube;
                switch (Range(0, 3))
                {
                    case 0:
                        p.x = p.x > 0.5f ? 1f : 0f;
                        break;
                    case 1:
                        p.y = p.y > 0.5f ? 1f : 0f;
                        break;
                    case 2:
                        p.z = p.z > 0.5f ? 1f : 0f;
                        break;
                }

                return p;
            }
        }

        public Vector2 onUnitSquare
        {
            get
            {
                Vector2 p = insideUnitSquare;
                if (valueBool) p.x = p.x > 0.5f ? 1f : 0f;
                else p.y = p.y > 0.5f ? 1f : 0f;

                return p;
            }
        }

        public Quaternion rotation
        {
            get
            {
                var prevState = Random.state;
                Random.state = state;
                Quaternion result = Random.rotation;
                state = Random.state;
                Random.state = prevState;

                return result;
            }
        }

        public Quaternion rotationUniform
        {
            get
            {
                var prevState = Random.state;
                Random.state = state;
                Quaternion result = Random.rotationUniform;
                state = Random.state;
                Random.state = prevState;

                return result;
            }
        }

        public bool GetChance(float probability)
        {
            return value <= probability;
        }

        public int RollDice(DiceType dice)
        {
            return Range(1, (int)dice + 1);
        }

        public int RollDice(int size, DiceType dice)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += Range(1, (int)dice + 1);
            }
            return sum;
        }

        public T RandomElement<T>(WeightedList<T> weightedList)
        {
            float totalPer = 0;
            for (int i = 0; i < weightedList.Count; i++)
            {
                totalPer += weightedList[i].weight;
            }

            float rand = Range(0, totalPer);
            for (int i = 0; i < weightedList.Count; i++)
            {
                rand -= weightedList[i].weight;

                if (rand <= 0)
                {
                    return weightedList[i].value;
                }
            }

            return default(T);
        }

        public T RandomElement<T>(IEnumerable<T> values)
        {
            int count = values.Count();

            if (count == 0) throw new System.IndexOutOfRangeException();
            return values.ElementAt(Range(0, count));
        }

        public T RandomElement<T>(params T[] values)
        {
            int count = values.Count();

            if (count == 0) throw new System.IndexOutOfRangeException();
            return values[Range(0, count)];
        }

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> values)
        {
            int count = values.Count();
            T[] result = values.ToArray();

            int n = count;
            while (n > 1)
            {
                n--;
                int k = Range(0, n + 1);
                T tmp = result[k];
                result[k] = result[n];
                result[n] = tmp;
            }
            return result;
        }

        public Color RandomColor(Gradient gradient)
        {
            return gradient.Evaluate(value);
        }
    }
}