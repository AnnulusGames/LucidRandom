# Lucid Random
Enhanced random number generator for Unity

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/Header.png" width="800">

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)

[English README](README.md)

## 概要
Lucid RandomはUnityのRandomクラスを拡張し、再現可能な乱数や重み付きの抽選など、多くの機能を追加します。

### 特徴
* UnityEngine.Randomをベースに多くの機能を追加したLucidRandomクラス
* 最小値と最大値を扱う構造体
* 重み付きのリストを扱うWeightedList

## セットアップ

### 要件
* Unity 2020.1 以上

### インストール
1. Window > Package ManagerからPackage Managerを開く
2. 「+」ボタン > Add package from git URL
3. 以下を入力する
   * https://github.com/AnnulusGames/LucidRandom.git?path=/Assets/LucidRandom


あるいはPackages/manifest.jsonを開き、dependenciesブロックに以下を追記

```json
{
    "dependencies": {
        "com.annulusgames.lucid-random": "https://github.com/AnnulusGames/LucidRandom.git?path=/Assets/LucidRandom"
    }
}
```

### Namespace
Lucid Randomを利用する場合は、ファイルの冒頭に以下の一行を追加します。

```cs
using AnnulusGames.LucidTools.RandomKit;
```

## 基本的な使い方
基本的にはUnity.Randomクラスと同じように使用できます。

```cs
//0.0fから10.0fまでの値をランダムに取得
float value = LucidRandom.Range(0f, 10f);

//ランダムな色を取得
Color color = LucidRandom.ColorHSV();
```

シード値を設定したい場合はInitStateを利用します。

```cs
int seed = (int)System.DateTime.Now.Ticks;
//シード値を指定
LucidRandom.InitState(seed);
```


ランダムなbool値を取得したい場合はvalueBoolを利用します。

```cs
//trueかfalseをランダムに返す
if (LucidRandom.valueBool)
{
    Debug.Log("Hello!");
}
```

また、Vector2やVector3もRangeの引数として指定できます。

```cs
//(0, 0)から(1, 1)までのランダムなVector2を返す
Vector2 vector2 = LucidRandom.Range(Vector2.zero, Vector2.one);

//(0, 0, 0)から(1, 1, 1)までのランダムなVector3を返す
Vector3 vector3 = LucidRandom.Range(Vector3.zero, Vector3.one);
```

onUnitCubeやinsideUnitSquareなども利用できます。

```cs
//単位立方体の表面の座標をランダムに取得する
Vector3 p1 = LucidRandom.onUnitCube;

//単位正方形の内部の座標をランダムに取得する
Vector2 p2 = LucidRandom.insideUnitSquare;
```

確率による計算を行う場合はGetChanceを利用します。

```cs
//15%の確率でtrueを返す
if (LucidRandom.GetChance(0.15f))
{
    Debug.Log("Lucky!");
}
```

ダイスを振る場合はRollDiceを利用します。

```cs
//6面ダイスを振ったときの出目を取得
int valueD6 = LucidRandom.RollDice(DiceType.D6);

//10面ダイスを二つ振ったときの出目の合計値を取得
int value2D10 = LucidRandom.RollDice(2, DiceType.D10);
```

配列やListのランダムな要素を取得したい場合はRandomElementを利用します。

```cs
int[] array = { 1, 2, 3, 4, 5, 6 };
//配列のランダムな要素を取得する
int a = LucidRandom.RandomElement(array);

//可変長引数による指定も可能
int b = LucidRandom.RandomElement(1, 2, 3, 4, 5, 6);
```

配列やリストの順番をランダムに入れ替えたい場合はShuffleを利用します。
```cs
int[] array = { 1, 2, 3, 4, 5, 6 };
//順番をシャッフル
array = LucidRandom.Shuffle(array).ToArray();
```

Gradientの中からランダムな色を取得したい場合は、RandomColorを利用します。

```cs
Color color = LucidRandom.RandomColor(gradient);
```

## 拡張メソッド

RandomElement、Shuffle、RandomColorはそれぞれ拡張メソッドとして用意されています。
```cs
//配列のランダムな要素を取得
int[] array = { 1, 2, 3, 4, 5, 6 };
int a = array.RandomElement();

//順番をシャッフル
array = array.Shuffle().ToArray();

//ランダムな色を取得
Color color = gradient.RandomColor();
```

## 乱数の再現

UnityのRandomクラスはインスタンス化ができないため、再現可能な乱数を生成するのには向いていません。
Lucid Randomでは、RandomGeneratorクラスを用いることで乱数の再現を簡単に行うことができます。

```cs
int seed = 0;
//引数でシード値を指定する
RandomGenerator rand = new RandomGenerator(seed);

//LucidRandomクラスと同じメソッドやプロパティが利用可能
float value1 = rand.value;
float value2 = rand.value;
float value3 = rand.value;
```

また、AddGenerator・GetGeneratorを利用することでRandomGeneratorを登録しておくことができます。これは、複数のクラスで同じ乱数を使い回したい時に便利です。

```cs
int seed = 0;
//新たなRandomGeneratorを登録
LucidRandom.AddGenerator("Key", seed);

//Keyを指定してRandomGeneratorを取得する
float value1 = LucidRandom.GetGenerator("Key").value;
float value2 = LucidRandom.GetGenerator("Key").value;
float value3 = LucidRandom.GetGenerator("Key").value;
```

## MinMaxValue

Lucid Randomでは、最小値と最大値を扱う構造体が定義されています。

```cs
//0を最小、100を最大とするfloat
MinMaxFloat mmFloat = new MinMaxFloat(0f, 100f);

//最小値を取得
float minValue = mmFloat.min;
//最大値を取得
float minValue = mmFloat.max;
//最小値〜最大値を範囲とする乱数を取得
float randomValue = mmFloat.random;

//値の範囲の長さを取得 (int, floatのみ)
float length = mmFloat.length;

//最小値〜最大値のLerpを利用可能
float value = mmFloat.Lerp(0.2f);
```

これらはRangeの引数としても使用可能です。
```cs
MinMaxFloat mmFloat = new MinMaxFloat(0f, 100f);

//0.0fから100.0fまでの値をランダムに取得
float value = LucidRandom.Range(mmFloat);
```

また、この値はInspector上から編集が可能です。

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/img1.png" width="500">

対応している型は以下の通りです。
* int
* float
* Vector2
* Vector2Int
* Vector3
* Vector3Int

## WeightedList

ゲーム内で抽選を行う場合、一定の確率ではなく、ある程度の重みをつけた抽選を行う必要がある場合があります。Lucid Randomでは、WeightedListを利用することで重み付きの抽選を簡単に実装できます。

WeightedListは通常のListのように利用することができます。

```cs
WeightedList<string> weightedList = new WeightedList<string>();

//値を追加
weightedList.Add("Hello!");
weightedList.Add("How are you?");

//値を編集
weightedList[1].value = "I'm good.";

//値を削除
weightedList.Remove("Hello!");
weightedList.RemoveAt(0);
```

要素に重みを付けたい場合は、要素を追加する際に指定するか、要素が持つweightの値を変更します。指定がない場合、weightは1に設定されます。

```cs
WeightedList<string> weightedList = new WeightedList<string>();

//重み付きの要素を追加
weightedList.Add("Legendary", 0.5f);
weightedList.Add("Epic", 2.5f);
weightedList.Add("Rare", 12f);
weightedList.Add("Uncommon", 25f);
weightedList.Add("Common", 60f);

//重みを編集
weightedList[4].weight = 50f;
weightedList["Uncommon"] = 35f;

//抽選を行う
string rarity = weightedList.RandomElement();
```

WeightedListは追加された要素をWeightedListItemとして扱います。WeightedListItemはvalueとweightの二つの値を保持します。


```cs
WeightedList<string> weightedList = new WeightedList<string>();

WeightedListItem<string> item = new WeightedListItem<string>("Value", 10f);
weightesList.Add(item);
```

また、WeightedListはInspector上から編集が可能です。

<img src="https://github.com/AnnulusGames/LucidRandom/blob/main/Assets/LucidRandom/Documentation~/img2.png" width="500">

## ライセンス

[Mit License](LICENSE)