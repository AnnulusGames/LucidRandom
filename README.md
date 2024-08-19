# Lucid Random
Enhanced random number generator for Unity

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/Header.png" width="800">

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)

[日本語版README](README_JP.md)

> [!IMPORTANT]
> This repository has been archived. Consider migrating to [Random Extensions](https://github.com/AnnulusGames/RandomExtensions).

## Overview
Lucid Random extends Unity's Random class, adding more features such as reproducible random numbers and weighted list.

### Features
* LucidRandom class based on UnityEngine.Random and adding many functions
* Struct that handles minimum and maximum values
* WeightedList class to handle weighted elements

## Setup

### Requirement
* Unity 2020.1 or higher

### Install
1. Open the Package Manager from Window > Package Manager
2. "+" button > Add package from git URL
3. Enter the following to install
   * https://github.com/AnnulusGames/LucidRandom.git?path=/Assets/LucidRandom


or open Packages/manifest.json and add the following to the dependencies block.

```json
{
    "dependencies": {
        "com.annulusgames.lucid-random": "https://github.com/AnnulusGames/LucidRandom.git?path=/Assets/LucidRandom"
    }
}
```

### Namespace
When using Lucid Random, add the following line at the beginning of the file.

```cs
using AnnulusGames.LucidTools.RandomKit;
```

## Basic Usage
You can use it in the same way as the Unity.Random class.

```cs
// get a random value from 0.0f to 10.0f
float value = LucidRandom.Range(0f, 10f);

// get a random color
Color color = LucidRandom.ColorHSV();
```

Use InitState to set the seed state, 

```cs
int seed = (int)System.DateTime.Now.Ticks;
// set seed state
LucidRandom.InitState(seed);
```


Use valueBool to get a random bool value, 

```cs
// return true or false randomly
if (LucidRandom.valueBool)
{
    Debug.Log("Hello!");
}
```

Vector2 and Vector3 can also be specified as Range arguments.

```cs
// returns a random Vector2 from (0, 0) to (1, 1)
Vector2 vector2 = LucidRandom.Range(Vector2.zero, Vector2.one);

// returns a random Vector3 from (0, 0, 0) to (1, 1, 1)
Vector3 vector3 = LucidRandom.Range(Vector3.zero, Vector3.one);
```

You can also use onUnitCube, insideUnitSquare, etc.

```cs
// get a random coordinate on the unit cube
Vector3 p1 = LucidRandom.onUnitCube;

// get a random coordinate inside the unit square
Vector2 p2 = LucidRandom.insideUnitSquare;
```

Use GetChance to perform probabilistic calculations, 

```cs
// returns true with a probability of 15%
if (LucidRandom.GetChance(0.15f))
{
    Debug.Log("Lucky!");
}
```

Use RollDice to roll the dice, 

```cs
// get the result when rolling a 6-sided dice
int valueD6 = LucidRandom.RollDice(DiceType.D6);

// get the sum of the results when rolling two 10-sided dice
int value2D10 = LucidRandom.RollDice(2, DiceType.D10);
```

Use RandomElement to get a random element of an array or list, 

```cs
int[] array = { 1, 2, 3, 4, 5, 6 };
// get a random element of the array
int a = LucidRandom.RandomElement(array);

// can also be specified with variable length arguments
int b = LucidRandom.RandomElement(1, 2, 3, 4, 5, 6);
```

Use Shuffle to randomly change the order of an array or list,
```cs
int[] array = { 1, 2, 3, 4, 5, 6 };
// shuffle order
array = LucidRandom.Shuffle(array).ToArray();
```

Use RandomColor to get a random color from the gradient.

```cs
Color color = LucidRandom.RandomColor(gradient);
```

## Extension Methods

RandomElement, Shuffle, and RandomColor are provided as extension methods.

```cs
// get a random element of the array
int[] array = { 1, 2, 3, 4, 5, 6 };
int a = array.RandomElement();

// shuffle order
array = array.Shuffle().ToArray();

// get a random color from the gradient
Color color = gradient.RandomColor();
```

## Random Generator

Unity's Random class cannot be instantiated, so it is not suitable for generating reproducible random numbers.
With Lucid Random, you can easily reproduce random numbers by using the RandomGenerator class.

```cs
int seed = 0;
// specify the seed in the argument
RandomGenerator rand = new RandomGenerator(seed);

// the same methods and properties as the LucidRandom class are available
float value1 = rand.value;
float value2 = rand.value;
float value3 = rand.value;
```

You can also register and acquire RandomGenerator by using AddGenerator and GetGenerator. This is useful when you want to use the same random number in multiple classes.

```cs
int seed = 0;
// register a new RandomGenerator
LucidRandom.AddGenerator("Key", seed);

// get RandomGenerator by specifying Key
float value1 = LucidRandom.GetGenerator("Key").value;
float value2 = LucidRandom.GetGenerator("Key").value;
float value3 = LucidRandom.GetGenerator("Key").value;
```

## MinMaxValue

Lucid Random defines a structure that handles minimum and maximum values.

```cs
// float with minimum 0 and maximum 100
MinMaxFloat mmFloat = new MinMaxFloat(0f, 100f);

// get minimum value
float minValue = mmFloat.min;
// get maximum value
float minValue = mmFloat.max;
// get a random number in the range from minimum value to maximum value
float randomValue = mmFloat.random;

// get length of value range (int, float only)
float length = mmFloat.length;

// minimum to maximum Lerp
float value = mmFloat.Lerp(0.2f);
```

They can also be used as Range arguments.

```cs
MinMaxFloat mmFloat = new MinMaxFloat(0f, 100f);

// get a random value from 0.0f to 100.0f
float value = LucidRandom.Range(mmFloat);
```

Also, these value can be edited from the Inspector.

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/img1.png" width="500">

Supported types are as follows.
* int
* float
* Vector2
* Vector2Int
* Vector3
* Vector3Int

## WeightedList

When using random numbers in a game, you may want to get random numbers with some weight rather than a constant probability. With Lucid Random, you can easily implement a weighted list by using WeightedList.

WeightedList can be used like a normal List.

```cs
WeightedList<string> weightedList = new WeightedList<string>();

//add value
weightedList.Add("Hello!");
weightedList.Add("How are you?");

//edit value
weightedList[1].value = "I'm good.";

//remove value
weightedList.Remove("Hello!");
weightedList.RemoveAt(0);
```

If you want to give weight to the element, specify it when adding the element or change the weight value of the element. If not specified, weight is set to 1.

```cs
WeightedList<string> weightedList = new WeightedList<string>();

// add weighted elements
weightedList.Add("Legendary", 0.5f);
weightedList.Add("Epic", 2.5f);
weightedList.Add("Rare", 12f);
weightedList.Add("Uncommon", 25f);
weightedList.Add("Common", 60f);

// edit weights
weightedList[4].weight = 50f;
weightedList["Uncommon"] = 35f;

// get a random element
string rarity = weightedList.RandomElement();
```

WeightedList treats added elements as WeightedListItem. WeightedListItem holds two values, a value and a weight.


```cs
WeightedList<string> weightedList = new WeightedList<string>();

WeightedListItem<string> item = new WeightedListItem<string>("Value", 10f);
weightesList.Add(item);
```

Also, WeightedList can be edited from the Inspector.

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/img2.png" width="500">

## License

[Mit License](LICENSE)
