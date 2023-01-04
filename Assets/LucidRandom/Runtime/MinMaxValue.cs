using System;
using UnityEngine;

namespace AnnulusGames.LucidTools.RandomKit
{
    public interface IMinMaxValue<T>
    {
        public T min { get; set; }
        public T max { get; set; }
    }

    [Serializable]
    public struct MinMaxInt : IMinMaxValue<int>, IEquatable<MinMaxInt>
    {
        [SerializeField] private int minValue;
        [SerializeField] private int maxValue;

        public MinMaxInt(int min, int max)
        {
            minValue = min;
            maxValue = max;
        }

        public int min { get { return minValue; } set { minValue = value; } }
        public int max { get { return maxValue; } set { maxValue = value; } }
        public int random { get { return LucidRandom.Range(this); } }
        public int length { get { return Math.Abs(max - min); } }
        public int Lerp(float t)
        {
            return (int)MathF.Floor(minValue + (minValue - maxValue) * t);
        }

        public override bool Equals(object obj)
        {
            return obj is MinMaxInt mm && Equals(mm);
        }
        public bool Equals(MinMaxInt other)
        {
            return other.minValue == minValue && other.maxValue == maxValue;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(minValue, maxValue);
        }
        public static bool operator ==(MinMaxInt left, MinMaxInt right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(MinMaxInt left, MinMaxInt right)
        {
            return !(left == right);
        }
    }

    [Serializable]
    public struct MinMaxFloat : IMinMaxValue<float>, IEquatable<MinMaxFloat>
    {
        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;

        public MinMaxFloat(float min, float max)
        {
            minValue = min;
            maxValue = max;
        }

        public float min { get { return minValue; } set { minValue = value; } }
        public float max { get { return maxValue; } set { maxValue = value; } }
        public float random { get { return LucidRandom.Range(this); } }
        public float length { get { return Math.Abs(max - min); } }
        public float Lerp(float t)
        {
            return minValue + (minValue - maxValue) * t;
        }

        public override bool Equals(object obj)
        {
            return obj is MinMaxFloat mm && Equals(mm);
        }
        public bool Equals(MinMaxFloat other)
        {
            return other.minValue == minValue && other.maxValue == maxValue;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(minValue, maxValue);
        }
        public static bool operator ==(MinMaxFloat left, MinMaxFloat right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(MinMaxFloat left, MinMaxFloat right)
        {
            return !(left == right);
        }
    }

    [Serializable]
    public struct MinMaxVector2 : IMinMaxValue<Vector2>, IEquatable<MinMaxVector2>
    {
        [SerializeField] private Vector2 minValue;
        [SerializeField] private Vector2 maxValue;

        public MinMaxVector2(Vector2 min, Vector2 max)
        {
            minValue = min;
            maxValue = max;
        }

        public Vector2 min { get { return minValue; } set { minValue = value; } }
        public Vector2 max { get { return maxValue; } set { maxValue = value; } }
        public Vector2 random { get { return LucidRandom.Range(this); } }
        public Vector2 Lerp(float t)
        {
            return Vector2.LerpUnclamped(minValue, maxValue, t);
        }

        public override bool Equals(object obj)
        {
            return obj is MinMaxVector2 mm && Equals(mm);
        }
        public bool Equals(MinMaxVector2 other)
        {
            return other.minValue == minValue && other.maxValue == maxValue;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(minValue, maxValue);
        }
        public static bool operator ==(MinMaxVector2 left, MinMaxVector2 right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(MinMaxVector2 left, MinMaxVector2 right)
        {
            return !(left == right);
        }
    }

    [Serializable]
    public struct MinMaxVector2Int : IMinMaxValue<Vector2Int>, IEquatable<MinMaxVector2Int>
    {
        [SerializeField] private Vector2Int minValue;
        [SerializeField] private Vector2Int maxValue;

        public MinMaxVector2Int(Vector2Int min, Vector2Int max)
        {
            minValue = min;
            maxValue = max;
        }

        public Vector2Int min { get { return minValue; } set { minValue = value; } }
        public Vector2Int max { get { return maxValue; } set { maxValue = value; } }
        public Vector2Int random { get { return LucidRandom.Range(this); } }
        public Vector2Int Lerp(float t)
        {
            return new Vector2Int(
                (int)MathF.Floor(minValue.x + (minValue.x - maxValue.x) * t),
                (int)MathF.Floor(minValue.y + (minValue.y - maxValue.y) * t)
            );
        }

        public override bool Equals(object obj)
        {
            return obj is MinMaxVector2Int mm && Equals(mm);
        }
        public bool Equals(MinMaxVector2Int other)
        {
            return other.minValue == minValue && other.maxValue == maxValue;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(minValue, maxValue);
        }
        public static bool operator ==(MinMaxVector2Int left, MinMaxVector2Int right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(MinMaxVector2Int left, MinMaxVector2Int right)
        {
            return !(left == right);
        }
    }

    [Serializable]
    public struct MinMaxVector3 : IMinMaxValue<Vector3>, IEquatable<MinMaxVector3>
    {
        [SerializeField] private Vector3 minValue;
        [SerializeField] private Vector3 maxValue;

        public MinMaxVector3(Vector3 min, Vector3 max)
        {
            minValue = min;
            maxValue = max;
        }

        public Vector3 min { get { return minValue; } set { minValue = value; } }
        public Vector3 max { get { return maxValue; } set { maxValue = value; } }
        public Vector3 random { get { return LucidRandom.Range(this); } }
        public Vector3 Lerp(float t)
        {
            return Vector3.LerpUnclamped(minValue, maxValue, t);
        }

        public override bool Equals(object obj)
        {
            return obj is MinMaxVector3 mm && Equals(mm);
        }
        public bool Equals(MinMaxVector3 other)
        {
            return other.minValue == minValue && other.maxValue == maxValue;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(minValue, maxValue);
        }
        public static bool operator ==(MinMaxVector3 left, MinMaxVector3 right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(MinMaxVector3 left, MinMaxVector3 right)
        {
            return !(left == right);
        }
    }

    [Serializable]
    public struct MinMaxVector3Int : IMinMaxValue<Vector3Int>
    {
        [SerializeField] private Vector3Int minValue;
        [SerializeField] private Vector3Int maxValue;

        public MinMaxVector3Int(Vector3Int min, Vector3Int max)
        {
            minValue = min;
            maxValue = max;
        }

        public Vector3Int min { get { return minValue; } set { minValue = value; } }
        public Vector3Int max { get { return maxValue; } set { maxValue = value; } }
        public Vector3Int random { get { return LucidRandom.Range(this); } }
        public Vector3Int Lerp(float t)
        {
            return new Vector3Int(
                (int)MathF.Floor(minValue.x + (minValue.x - maxValue.x) * t),
                (int)MathF.Floor(minValue.y + (minValue.y - maxValue.y) * t),
                (int)MathF.Floor(minValue.z + (minValue.z - maxValue.z) * t)
            );
        }

        public override bool Equals(object obj)
        {
            return obj is MinMaxVector3Int mm && Equals(mm);
        }
        public bool Equals(MinMaxVector3Int other)
        {
            return other.minValue == minValue && other.maxValue == maxValue;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(minValue, maxValue);
        }
        public static bool operator ==(MinMaxVector3Int left, MinMaxVector3Int right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(MinMaxVector3Int left, MinMaxVector3Int right)
        {
            return !(left == right);
        }
    }
}