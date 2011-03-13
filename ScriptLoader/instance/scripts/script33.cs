script33
	
| names |
names := '
39Deprecated-md.6.mcz
Balloon-ar.9.mcz
Flash-ar.1.mcz
TrueType-ar.1.mcz
Morphic-Balloon-ar.1.mcz
Morphic-TrueType-ar.1.mcz
Collections-md.45.mcz
CollectionsTests-md.14.mcz
Compiler-md.33.mcz 
Compression-stephaneducasse.4.mcz
Exceptions-sd.6.mcz
EToys-md.6.mcz
FFI-CdG.4.mcz
Files-stephaneducasse.15.mcz
FlexibleVocabularies-stephaneducasse.3.mcz
Graphics-stephaneducasse.26.mcz
GraphicsTests-md.3.mcz
Kernel-md.90.mcz
KernelTests-md.20.mcz
Morphic-md.68.mcz
MorphicExtras-stephaneducasse.10.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-stephaneducasse.288.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Movies-stephaneducasse.4.mcz
Multilingual-stephaneducasse.11.mcz
Nebraska-sd.6.mcz
Network-CdG.21.mcz
NetworkTests-gk.8.mcz
OmniBrowser-stephaneducasse.274.mcz
PackageInfo-stephaneducasse.4.mcz
ReleaseBuilder-stephaneducasse.2.mcz
PlusTools-md.27.mcz
PreferenceBrowser-stephaneducasse.29.mcz
Protocols-stephaneducasse.8.mcz
Services-Base-stephaneducasse.24.mcz
SMBase-stephaneducasse.71.mcz
SMLoader-stephaneducasse.28.mcz
SmaCC-stephaneducasse.6.mcz
Sound-stephaneducasse.4.mcz
ST80-md.28.mcz
StarSqueak-sd.6.mcz
SUnit-stephaneducasse.29.mcz
SUnitGUI-lr.4.mcz
System-md.65.mcz
Tests-md.12.mcz
ToolBuilder-Kernel-stephaneducasse.14.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-ar.8.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.55.mcz
Traits-md.202.mcz
Speech-stephaneducasse.7.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
