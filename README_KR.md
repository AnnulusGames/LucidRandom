# Lucid Random
Enhanced random number generator for Unity

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/Header.png" width="800">

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)

[日本語版README](README_JP.md)

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
Lucid Random을 사용하는 경우 파일 시작 부분에 다음 줄을 추가합니다.

```cs
using AnnulusGames.LucidTools.RandomKit;
```

## Basic Usage
Unity.Random 클래스와 동일하게 사용할 수 있습니다.

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


임의의 부울 값을 얻으려면 valueBool을 사용하십시오.

```cs
// return true or false randomly
if (LucidRandom.valueBool)
{
    Debug.Log("Hello!");
}
```

임의의 Vector2 및 Vector3 범위도 지정할 수 있습니다.

```cs
// returns a random Vector2 from (0, 0) to (1, 1)
Vector2 vector2 = LucidRandom.Range(Vector2.zero, Vector2.one);

// returns a random Vector3 from (0, 0, 0) to (1, 1, 1)
Vector3 vector3 = LucidRandom.Range(Vector3.zero, Vector3.one);
```

onUnitCube, insideUnitSquare 등을 사용할 수도 있습니다.

```cs
// get a random coordinate on the unit cube
Vector3 p1 = LucidRandom.onUnitCube;

// get a random coordinate inside the unit square
Vector2 p2 = LucidRandom.insideUnitSquare;
```

GetChance를 사용하여 확률 계산을 수행할 수 있습니다

```cs
// 15%의 확률로 반환합니다
if (LucidRandom.GetChance(0.15f))
{
    Debug.Log("Lucky!");
}
```

RollDice를 사용하여 주사위를 굴릴 수 있습니다, 

```cs
// 6면체 주사위를 굴려서 나온 결과값
int valueD6 = LucidRandom.RollDice(DiceType.D6);

// 10면체 주사위를 굴려서 나온 결과값
int value2D10 = LucidRandom.RollDice(2, DiceType.D10);
```

RandomElement를 사용하여 배열 또는 리스트의 임의 요소를 가져옵니다, 

```cs
int[] array = { 1, 2, 3, 4, 5, 6 };
// get a random element of the array
int a = LucidRandom.RandomElement(array);

// can also be specified with variable length arguments
int b = LucidRandom.RandomElement(1, 2, 3, 4, 5, 6);
```

Shuffle을 이용하여 array나 list를 섞습니다,
```cs
int[] array = { 1, 2, 3, 4, 5, 6 };
// shuffle order
array = LucidRandom.Shuffle(array).ToArray();
```

RandomColor를 이용하여 gradient에서 랜덤값을 가져옵니다.

```cs
Color color = LucidRandom.RandomColor(gradient);
```

## Extension Methods

확장 메소드로 RandomElement, Shuffle, RandomColor 제공.

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

Unity의 Random 클래스는 인스턴스화할 수 없으므로 재현 가능한 난수를 생성하는 데 적합하지 않습니다.
Lucid Random에서는 RandomGenerator 클래스를 사용하여 난수를 쉽게 재현할 수 있습니다.

```cs
int seed = 0;
// specify the seed in the argument
RandomGenerator rand = new RandomGenerator(seed);

// the same methods and properties as the LucidRandom class are available
float value1 = rand.value;
float value2 = rand.value;
float value3 = rand.value;
```

AddGenerator 및 GetGenerator를 사용하여 RandomGenerator를 등록하고 획득할 수도 있습니다. 이는 여러 클래스에서 동일한 난수를 사용하려는 경우에 유용합니다.

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

Lucid Random을  최소값과 최대값을 처리하는 구조를 정의합니다.

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

또한 이 값은 Inspector에서 편집할 수 있습니다.

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/img1.png" width="500">

지원하는 타입은 아래와 같습니다.
* int
* float
* Vector2
* Vector2Int
* Vector3
* Vector3Int

## WeightedList

게임에서 임의의 숫자를 사용할 때 일정한 확률보다는 가중치가 있는 임의의 숫자를 얻고 싶을 수 있습니다. Lucid Random을 사용하면 WeightedList를 사용하여 쉽게 가중치 목록을 구현할 수 있습니다.

WeightedList는 일반 목록처럼 사용할 수 있습니다.

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

요소에 가중치를 주고 싶다면 요소를 추가할 때 지정하거나 요소의 가중치 값을 변경하면 됩니다. 지정하지 않으면 가중치가 1로 설정됩니다.

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

WeightedList는 추가된 요소를 WeightedListItem으로 취급합니다. WeightedListItem은 값과 가중치라는 두 가지 값을 보유합니다.


```cs
WeightedList<string> weightedList = new WeightedList<string>();

WeightedListItem<string> item = new WeightedListItem<string>("Value", 10f);
weightesList.Add(item);
```

또한 WeightedList는 Inspector에서 편집할 수 있습니다.

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/img2.png" width="500">

## License

[Mit License](LICENSE)
