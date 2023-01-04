using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AnnulusGames.LucidTools.RandomKit
{
    [Serializable]
    public class WeightedList<T> : IList<WeightedListItem<T>>
    {
        [SerializeField] private List<WeightedListItem<T>> list;

        public WeightedList()
        {
            this.list = new List<WeightedListItem<T>>();
        }

        public WeightedList(IList<T> list)
        {
            this.list = new List<WeightedListItem<T>>(list.Select(x => new WeightedListItem<T>(x, 1f)));
        }

        public WeightedList(params T[] items)
        {
            this.list = new List<WeightedListItem<T>>(items.Select(x => new WeightedListItem<T>(x, 1f)));
        }

        public WeightedList(IList<WeightedListItem<T>> list)
        {
            this.list = new List<WeightedListItem<T>>(list);
        }

        public WeightedList(params WeightedListItem<T>[] items)
        {
            this.list = new List<WeightedListItem<T>>(items);
        }

        public WeightedListItem<T> this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public float this[T key]
        {
            get
            {
                return list[IndexOf(key)].weight;
            }
            set
            {
                list[IndexOf(key)].weight = value;
            }
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            list.Add(new WeightedListItem<T>(item, 1f));
        }

        public void Add(T item, float weight)
        {
            list.Add(new WeightedListItem<T>(item, weight));
        }

        public void Add(WeightedListItem<T> item)
        {
            list.Add(item);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;

            list.RemoveAt(index);
            return true;
        }

        public bool Remove(WeightedListItem<T> item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, new WeightedListItem<T>(item, 1f));
        }

        public void Insert(int index, T item, float weight)
        {
            list.Insert(index, new WeightedListItem<T>(item, weight));
        }

        public void Insert(int index, WeightedListItem<T> item)
        {
            list.Insert(index, item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Count(x =>
            {
                if (x.value is IEquatable<T>) ((IEquatable<T>)x.value).Equals(item);
                return x.value.Equals(item);
            }) > 0;
        }

        public bool Contains(WeightedListItem<T> item)
        {
            return list.Contains(item);
        }

        public int IndexOf(T item)
        {
            return list.FindIndex(x =>
            {
                if (x.value is IEquatable<T>) ((IEquatable<T>)x.value).Equals(item);
                return x.value.Equals(item);
            });
        }

        public int IndexOf(WeightedListItem<T> item)
        {
            return list.IndexOf(item);
        }

        public void CopyTo(WeightedListItem<T>[] array, int index)
        {
            array[index] = list[index];
        }

        public T RandomElement()
        {
            return LucidRandom.RandomElement(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public IEnumerator<WeightedListItem<T>> GetEnumerator()
        {
            return list.GetEnumerator();
        }

    }

}