# GraphicsSln
## Download
### clone the repository
```bash
git clone https://github.com/ahmniab/GraphicsSln.git
```
change dir to `GraphicsSln/graphics_pack`
```bash
cd GraphicsSln/graphics_pack
```
now u can run the project
```bash
dotnet run
```
## Dependencies
I used `dotnet-sdk-9.0.102` (**U can change dotnet version btw** just change it from `global.json`)<br>
add `Moq` for testing <br>

```bash
dotnet add package Moq
```
----
u need to add image package in `GraphicsSln/graphics_pack` dir

```bash
dotnet add package SixLabors.ImageSharp
```