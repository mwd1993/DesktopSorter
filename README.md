# DesktopSorter
C# Application, when ran, sorts your Desktop files by their extension name, into their own folders, in a folder named DesktopSorter  


### ** Recommended to run CMD as Administrator **


## Compile yourself, or Download from [Releases](https://github.com/mwd1993/DesktopSorter/releases) & Run from CMD Line:  
  
#### (this sorts all of your desktop items)
```
DesktopSorter.exe compress
```  
#### (this sorts all of your desktop items, ignoring extensions seperated by ",")
```
DesktopSorter.exe compress .exe,.ini,.mp3,.wav,.mp4
```  
#### (this extracts all of your compressed items back to the desktop)  
```
DesktopSorter.exe decompress
```  


# Known Issues:  
```
None
```  

# Fixed Issues:  
```
1. Shortcuts or some other weird extension type, is not being moved to the compression path, needs further looking into.
    (FIX) The problem was actually some desktop icons were in the Public Desktop location (different from default desktop location)
    & to move files back into that location, requires running CMD as administrator.
```  
# Image Example:
### (After running "compression")  
 ![](DesktopSorter.png)
