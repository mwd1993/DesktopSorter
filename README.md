# DesktopSorter
C# Application to sort and clean your Desktop by doing the following:  

1. Groups all files, by extension-type, then moves the files to a folder named by said type (jpg, mp3, exe, etc).
2. Then, moves any folders less than 1 Gig in size, to a main folder named, "\_DesktopSorterFolders".  
3. Lastly, it stores all of these new folders and files, into a Main folder on your desktop named, "DesktopSorter".  
4. You can then run this program 'backwards' which places everything back onto the Desktop.    
##### ** USE AT YOUR OWN RISK **
##### ** Recommended to run CMD as Administrator **
##### Compile yourself, or Download from [Releases](https://github.com/mwd1993/DesktopSorter/releases) & Run from CMD Line:  

# Usage
  
#### (this sorts all of your desktop items)
```
DesktopSorter.exe compress
```  
#### (this sorts all of your desktop items, ignoring extensions (or folders) seperated by ",")
```
DesktopSorter.exe compress .exe,.ini,folders,.mp3,.wav,.mp4
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
 ![](IMG_DesktopSorter.png)
