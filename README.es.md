# Anti-De4dot

Anti-De4dot protege los archivos binarios .NET del descompilador De4dot, protegiendo la propiedad intelectual del acceso no autorizado. Esta herramienta es independiente y no requiere módulos ni bibliotecas adicionales. Sin embargo, no es infalible y debe combinarse con otras medidas de seguridad.

## Traducción

| 🇺🇸                | 🇨🇳                                  | 🇹🇼                                 | 🇮🇳                  | 🇫🇷                     | 🇦🇪                  | 🇩🇪                   | 🇯🇵                    | 🇪🇸                    |
| ------------------- | ------------------------------------- | ------------------------------------ | --------------------- | ------------------------ | --------------------- | ---------------------- | ----------------------- | ----------------------- |
| [Inglés](README.md) | [Chino simplificado](README.zh-CN.md) | [chino tradicional](README.zh-TW.md) | [hindi](README.hi.md) | [Francésa](README.fr.md) | [árabe](README.ar.md) | [Alemán](README.de.md) | [japonés](README.ja.md) | [Español](README.es.md) |

## Capturas de pantalla

![6874](https://github.com/qzxtu/Anti-De4dot/assets/69091361/0a750eb0-44e3-4d15-a799-16382325b8e8)

## Características

-   Puede soltar la aplicación o escribir la ruta al archivo.
-   Generación aleatoria de nombres de tipos: el código utiliza una instancia de la clase "RandomNumberGenerator" para generar una matriz de bytes aleatorios que se utilizan para crear nombres de tipos únicos.
-   Use of "using" blocks: The code uses "using" blocks to ensure that objects are properly cleaned up after use and to free resources such as memory used by the "RandomNumberGenerator" instance.

## Ejecución de pruebas

Para ejecutar pruebas

```text
  Just open it or drop the application.
```

## Licencia

[CON](https://choosealicense.com/licenses/mit/)

## Autores

-   [@qzxtu](https://www.github.com/qzxtu)

## Apoyo

[![PayPal](https://img.shields.io/badge/PayPal-00457C?style=for-the-badge&logo=paypal&logoColor=white)](https://paypal.me/nova355killer)  
[![Ko-Fi](https://img.shields.io/badge/kofi-00457C?style=for-the-badge&logo=ko-fi&logoColor=white)](https://ko-fi.com/nova355)
