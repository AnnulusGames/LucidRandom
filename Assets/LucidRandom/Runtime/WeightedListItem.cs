using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnnulusGames.LucidTools.RandomKit
{
    [Serializable]
    public struct WeightedListItem<T>
    {
        public T value;
        public float weight;

        public WeightedListItem(T value, float weight)
        {
            this.value = value;
            this.weight = weight;
        }
    }
}
