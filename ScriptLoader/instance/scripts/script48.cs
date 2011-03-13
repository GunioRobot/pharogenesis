script48
	
| names | 
names := '
39Deprecated-md.11.mcz
Balloon-ar.10.mcz
Flash-ar.1.mcz
TrueType-ar.1.mcz
Collections-md.53.mcz
CollectionsTests-md.18.mcz
Compiler-md.44.mcz 
Compression-stephaneducasse.4.mcz
Exceptions-md.7.mcz
EToys-md.14.mcz
FFI-CdG.4.mcz
Files-md.16.mcz
FlexibleVocabularies-stephaneducasse.3.mcz
Graphics-md.32.mcz
GraphicsTests-ar.8.mcz
Kernel-md.107.mcz
KernelTests-md.30.mcz
Morphic-md.81.mcz
MorphicExtras-md.21.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-md.294.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Movies-stephaneducasse.4.mcz
Multilingual-md.12.mcz
Nebraska-md.8.mcz
Network-md.24.mcz
NetworkTests-gk.8.mcz
OmniBrowser-md.276.mcz
OB-Standard-cwp.93.mcz
PackageInfo-stephaneducasse.5.mcz
ReleaseBuilder-md.3.mcz
PlusTools-md.34.mcz
PreferenceBrowser-md.30.mcz
Protocols-md.9.mcz
Services-Base-md.26.mcz
SMBase-md.72.mcz
SMLoader-md.29.mcz
SmaCC-stephaneducasse.6.mcz
Sound-md.5.mcz
ST80-md.31.mcz
StarSqueak-sd.6.mcz
SUnit-md.31.mcz
SUnitGUI-md.5.mcz
System-md.78.mcz
Tests-md.15.mcz
ToolBuilder-Kernel-stephaneducasse.14.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.66.mcz
Traits-md.212.mcz
Speech-md.8.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
