# ImageToASCII

This program needs three required parametrs and one optional:


            First is a path to the image you want to convert
                supported formats:  BMP, GIF, EXIF, JPG, PNG и TIFF
            Second is a path where program will save output
                supported formats: text formats
            Third is a compression parametr defined in (0, 1] (1=full size)
            Optional parametr is an alphabet of ASCII symbols ordered from 'white' to 'black'
            space to alphabet adds automatically
            
EXAMPLE:
```
ConsoleApplication1.exe image.png result.txt 1 
```
or
```
ConsoleApplication1.exe image.png result.txt 0,5 ,;#@ 
```
