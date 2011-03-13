script57
	
| names | 
names := '
39Deprecated-md.11.mcz
Balloon-mir.11.mcz
Flash-mir.2.mcz
TrueType-ar.1.mcz
Collections-md.58.mcz
CollectionsTests-sd.23.mcz
Compiler-md.44.mcz 
Compression-stephaneducasse.4.mcz
Exceptions-md.7.mcz
EToys-md.18.mcz
FFI-CdG.4.mcz
Files-md.16.mcz
FlexibleVocabularies-stephaneducasse.3.mcz
Graphics-md.34.mcz
GraphicsTests-ar.8.mcz
Kernel-sd.113.mcz
KernelTests-md.32.mcz
Morphic-md.90.mcz
MorphicExtras-md.26.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-al.295.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Movies-md.7.mcz
Multilingual-sd.18.mcz
Nebraska-md.10.mcz
Network-md.26.mcz
NetworkTests-gk.8.mcz
OmniBrowser-lr.281.mcz
OB-Standard-lr.103.mcz
PackageInfo-stephaneducasse.5.mcz
ReleaseBuilder-md.4.mcz
PlusTools-md.34.mcz
PreferenceBrowser-md.30.mcz
Protocols-md.12.mcz
Services-Base-md.26.mcz
SMBase-md.72.mcz
SMLoader-md.29.mcz
SmaCC-fbs.8.mcz
Sound-md.5.mcz
ST80-md.32.mcz
StarSqueak-sd.6.mcz
SUnit-md.32.mcz
SUnitGUI-lr.6.mcz
System-md.81.mcz
Tests-md.16.mcz
ToolBuilder-Kernel-stephaneducasse.14.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.67.mcz
Traits-al.214.mcz
Speech-md.8.mcz
VersionNumber-dew.1.mcz
SystemChangeNotification-Tests-sd.5.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
