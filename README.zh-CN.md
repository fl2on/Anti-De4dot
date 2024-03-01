# 抗De4dot

Anti-De4dot 可保护 .NET 二进制文件免遭 De4dot 反编译器的攻击，从而保护知识产权免遭未经授权的访问。该工具是独立的，不需要额外的模块或库。然而，它并不是万无一失的，应该与其他安全措施结合起来。

## 翻译

| 🇺🇸            | 🇨🇳                    | 🇹🇼                    | 🇮🇳                | 🇫🇷               | 🇦🇪                | 🇩🇪               | 🇯🇵                | 🇪🇸                 |
| --------------- | ----------------------- | ----------------------- | ------------------- | ------------------ | ------------------- | ------------------ | ------------------- | -------------------- |
| [英语](README.md) | [简体中文](README.zh-CN.md) | [繁体中文](README.zh-TW.md) | [印地语](README.hi.md) | [法语](README.fr.md) | [阿拉伯](README.ar.md) | [德语](README.de.md) | [日本人](README.ja.md) | [西班牙语](README.es.md) |

## 截图

![6874](https://github.com/qzxtu/Anti-De4dot/assets/69091361/0a750eb0-44e3-4d15-a799-16382325b8e8)

## 特征

-   您可以删除应用程序或写入文件的路径。
-   类型名称的随机生成：代码使用“RandomNumberGenerator”类的实例来生成用于创建唯一类型名称的随机字节数组。
-   Use of "using" blocks: The code uses "using" blocks to ensure that objects are properly cleaned up after use and to free resources such as memory used by the "RandomNumberGenerator" instance.

## 运行测试

运行测试

```text
  Just open it or drop the application.
```

## 执照

[和](https://choosealicense.com/licenses/mit/)

## 作者

-   [@qzxtu](https://www.github.com/qzxtu)

## 支持

[![PayPal](https://img.shields.io/badge/PayPal-00457C?style=for-the-badge&logo=paypal&logoColor=white)](https://paypal.me/nova355killer)  
[![Ko-Fi](https://img.shields.io/badge/kofi-00457C?style=for-the-badge&logo=ko-fi&logoColor=white)](https://ko-fi.com/nova355)
