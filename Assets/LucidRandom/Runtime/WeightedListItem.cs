using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnnulusGames.LucidTools.RandomKit
{
    [Serializable]
    public class WeightedListItem<T>
    {
        public T value;
        public float weight = 1f;

        public WeightedListItem(T value, float weight)
        {
            this.value = value;
            this.weight = weight;
        }
    }
}
