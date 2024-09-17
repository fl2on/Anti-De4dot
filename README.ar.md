# مكافحة De4dot

يقوم Anti-De4dot بحماية ثنائيات .NET من أداة فك التحويل البرمجي De4dot، مما يحمي الملكية الفكرية من الوصول غير المصرح به. هذه الأداة مستقلة ولا تتطلب وحدات أو مكتبات إضافية. ومع ذلك، فهو ليس مضمونًا ويجب دمجه مع إجراءات أمنية أخرى.

## Translation

| 🇺🇸                 | 🇨🇳                               | 🇹🇼                                 | 🇮🇳                    | 🇫🇷                  | 🇦🇪                 | 🇩🇪                      | 🇯🇵                      | 🇪🇸                      |
| -------------------- | ---------------------------------- | ------------------------------------ | ----------------------- | --------------------- | -------------------- | ------------------------- | ------------------------- | ------------------------- |
| [إنجليزي](README.md) | [الصينية المبسطة](README.zh-CN.md) | [الصينية التقليدية](README.zh-TW.md) | [الهندية](README.hi.md) | [فرنسي](README.fr.md) | [عربى](README.ar.md) | [الألمانية](README.de.md) | [اليابانية](README.ja.md) | [الأسبانية](README.es.md) |

## لقطات الشاشة

![6874](https://github.com/qzxtu/Anti-De4dot/assets/69091361/0a750eb0-44e3-4d15-a799-16382325b8e8)

## سمات

-   يمكنك إسقاط التطبيق أو كتابة المسار إلى الملف.
-   Random generation of type names: The code uses an instance of the 	"RandomNumberGenerator" class to generate an array of random bytes that are used to create unique type names.
-   استخدام الكتل "باستخدام": يستخدم الكود كتل "باستخدام" لضمان تنظيف الكائنات بشكل صحيح بعد الاستخدام ولتحرير الموارد مثل الذاكرة المستخدمة بواسطة مثيل "RandomNumberGenerator".

## تشغيل الاختبارات

لتشغيل الاختبارات

```text
  Just open it or drop the application.
```

## رخصة

[مع](https://choosealicense.com/licenses/mit/)

## المؤلفون

-   [@qzxtu](https://www.github.com/qzxtu)

## يدعم

[![PayPal](https://img.shields.io/badge/PayPal-00457C?style=for-the-badge&logo=paypal&logoColor=white)](https://paypal.me/nova355killer)  
[![Ko-Fi](https://img.shields.io/badge/kofi-00457C?style=for-the-badge&logo=ko-fi&logoColor=white)](https://ko-fi.com/nova355)
