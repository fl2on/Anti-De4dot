# 抗De4dot

Anti-De4dot 可保護 .NET 二進位檔案免於 De4dot 反編譯器的攻擊，從而保護智慧財產權免於未經授權的存取。該工具是獨立的，不需要額外的模組或庫。然而，它並不是萬無一失的，應該與其他安全措施結合。

## Translation

| 🇺🇸            | 🇨🇳                    | 🇹🇼                    | 🇮🇳                | 🇫🇷               | 🇦🇪                | 🇩🇪               | 🇯🇵                | 🇪🇸                 |
| --------------- | ----------------------- | ----------------------- | ------------------- | ------------------ | ------------------- | ------------------ | ------------------- | -------------------- |
| [英語](README.md) | [簡體中文](README.zh-CN.md) | [繁体中文](README.zh-TW.md) | [印地語](README.hi.md) | [法語](README.fr.md) | [阿拉伯](README.ar.md) | [德文](README.de.md) | [日本人](README.ja.md) | [西班牙語](README.es.md) |

## 截圖

![6874](https://github.com/fl2on/Anti-De4dot/assets/69091361/0a750eb0-44e3-4d15-a799-16382325b8e8)

## 特徵

-   您可以刪除應用程式或寫入檔案的路徑。
-   類型名稱的隨機產生：程式碼使用「RandomNumberGenerator」類別的實例來產生用於建立唯一類型名稱的隨機位元組數組。
-   使用「using」區塊：程式碼使用「using」區塊來確保物件在使用後得到正確清理，並釋放資源，例如「RandomNumberGenerator」實例使用的記憶體。

## 運行測試

運行測試

```text
  Just open it or drop the application.
```

## 執照

[和](https://choosealicense.com/licenses/mit/)

## 作者

-   [@fl2on](https://www.github.com/fl2on)

## 支援

[![PayPal](https://img.shields.io/badge/PayPal-00457C?style=for-the-badge&logo=paypal&logoColor=white)](https://paypal.me/nova355killer)  
[![Ko-Fi](https://img.shields.io/badge/kofi-00457C?style=for-the-badge&logo=ko-fi&logoColor=white)](https://ko-fi.com/nova355)
