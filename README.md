# ¿Cómo depurar y compilar?
Es recomendable usar el IDE visual studio 2019, sin embargo, también se puede depurar usando el editor de código Visual Studio Code. A continuación se detallan los pasos para depurar en ambos:

## Visual Studio 2019
1. Descarga el [instalador de Visual Studio 2019](https://visualstudio.microsoft.com/es/vs/).
2. Corre el instalador, para este proyecto no necesitas instalar ningún paquete además de:
![image](https://user-images.githubusercontent.com/45268815/110478441-fbf68e80-80a9-11eb-86b9-93df45a0e36c.png)
3. Deja que inicie la descarga e instalación del paquete, esta parte es la que toma tiempo puesto que la descarga del IDE es pesada.
4. Después de la instalación, puedes abrir la solución (el archivo .sln) desde el IDE o abrir el IDE al darle doble click a la solución.
5. Para compilar/depurar la solución, solo tienes que darle click al botón Play, asegúrate que la configuración de compilación sea DEBUG, como se muestra en la siguiente imagen:

![image](https://user-images.githubusercontent.com/45268815/110479448-02d1d100-80ab-11eb-9425-e69ecfa51230.png)

## Visual Studio Code
Puedes seguir [esta guía](https://code.visualstudio.com/docs/languages/dotnet) para instalar los requisitos necesario para usar C# dentro de VSCode, básicamente tienes que:
1. Instalar el [editor de visual studio code](https://code.visualstudio.com/).
2. Instalar el SDK de .Net 5.0, puedes seguir los pasos de "¿Solo quieres compilar?" para realizar este paso.
3. Instalar el [paquete de extensiones que tiene Visual Studio Code para desarrollo de aplicaciones en C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).
Con esto ya puedes correr cualquier aplicación en VSCode, sin embargo, por el momento no puedes depurar, sigue esta guía para [depurar aplicaciones en VSCode](https://docs.microsoft.com/en-us/dotnet/core/tutorials/debugging-with-visual-studio-code), sin embargo básicamente tienes que:
1. Crear un launch.json, esto configura el depurador, necesitas cambiar la propiedad "console" a "integratedTerminal".
2. Poner algún breakpoint en donde el programa vaya a detenerse para inspección.

# ¿Solo quieres compilar?
Si solo necesitas compilar el proyecto en una aplicación, puedes hacerlo de una manera bien sencilla sin necesidad de usar el IDE que tiene una descarga muy pesada, esto es usar el SDK que ofrece microsoft. Puedes seguir los pasos 
1. Primero descarga el [.dotnet SDK](https://dotnet.microsoft.com/download), tienes que usar la versión 5.0.
2. Corre el instalador del SDK.
3. Después verifica la instalación corriendo el comando dotnet en la consola de la siguiente manera:
![image](https://user-images.githubusercontent.com/45268815/110476756-f8620800-80a7-11eb-9432-f48f4d9af9d0.png)
4. Clona o descarga el repositorio en tu computadora.
5. Entra a la consola y dirígete a la carpeta del proyecto en tu computadora, es la carpeta que tiene el archivo .sln.
6. Ahora solo necesitas correr el comando dotnet cake para compilar el proyecto según tu plataforma, la aplicación la encontrarás dentro de "Builds", busca un archivo con el nombre de "Problemas Pasantía".
