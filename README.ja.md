# アンチDe4dot

Anti-De4dot は、De4dot デコンパイラーから .NET バイナリを保護し、不正アクセスから知的財産を保護します。このツールは独立しているため、追加のモジュールやライブラリは必要ありません。ただし、これは確実ではないため、他のセキュリティ対策と組み合わせる必要があります。

## 翻訳

| 🇺🇸            | 🇨🇳                      | 🇹🇼                    | 🇮🇳                   | 🇫🇷                  | 🇦🇪                | 🇩🇪                 | 🇯🇵                | 🇪🇸                  |
| --------------- | ------------------------- | ----------------------- | ---------------------- | --------------------- | ------------------- | -------------------- | ------------------- | --------------------- |
| [英語](README.md) | [簡体字中国語](README.zh-CN.md) | [繁体中文](README.zh-TW.md) | [ヒンディー語](README.hi.md) | [フランス語](README.fr.md) | [アラブ](README.ar.md) | [ドイツ語](README.de.md) | [日本語](README.ja.md) | [スペイン語](README.es.md) |

## スクリーンショット

![6874](https://github.com/fl2on/Anti-De4dot/assets/69091361/0a750eb0-44e3-4d15-a799-16382325b8e8)

## 特徴

-   アプリケーションをドロップするか、ファイルへのパスを書き込むことができます。
-   Random generation of type names: The code uses an instance of the 	"RandomNumberGenerator" class to generate an array of random bytes that are used to create unique type names.
-   "using" ブロックの使用: コードは、"using" ブロックを使用して、オブジェクトが使用後に適切にクリーンアップされることを保証し、「RandomNumberGenerator」インスタンスによって使用されるメモリなどのリソースを解放します。

## テストの実行

テストを実行するには

```text
  Just open it or drop the application.
```

## ライセンス

[と](https://choosealicense.com/licenses/mit/)

## 著者

-   [@fl2on](https://www.github.com/fl2on)

## サポート

[![PayPal](https://img.shields.io/badge/PayPal-00457C?style=for-the-badge&logo=paypal&logoColor=white)](https://paypal.me/nova355killer)  
[![Ko-Fi](https://img.shields.io/badge/kofi-00457C?style=for-the-badge&logo=ko-fi&logoColor=white)](https://ko-fi.com/nova355)
