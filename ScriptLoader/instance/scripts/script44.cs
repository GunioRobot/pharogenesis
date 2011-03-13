script44
	
| names |
names := '
39Deprecated-md.11.mcz
Balloon-ar.10.mcz
Flash-ar.1.mcz
TrueType-ar.1.mcz
Collections-md.50.mcz
CollectionsTests-md.17.mcz
Compiler-md.43.mcz 
Compression-stephaneducasse.4.mcz
Exceptions-md.7.mcz
EToys-md.12.mcz
FFI-CdG.4.mcz
Files-md.16.mcz
FlexibleVocabularies-stephaneducasse.3.mcz
Graphics-ar.30.mcz
GraphicsTests-ar.8.mcz
Kernel-md.104.mcz
KernelTests-md.29.mcz
Morphic-md.77.mcz
MorphicExtras-md.17.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-md.293.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Movies-stephaneducasse.4.mcz
Multilingual-stephaneducasse.11.mcz
Nebraska-md.7.mcz
Network-md.23.mcz
NetworkTests-gk.8.mcz
OmniBrowser-md.276.mcz
OB-Standard-cwp.93.mcz
PackageInfo-stephaneducasse.5.mcz
ReleaseBuilder-md.3.mcz
PlusTools-md.34.mcz
PreferenceBrowser-md.30.mcz
Protocols-stephaneducasse.8.mcz
Services-Base-md.26.mcz
SMBase-stephaneducasse.71.mcz
SMLoader-md.29.mcz
SmaCC-stephaneducasse.6.mcz
Sound-md.5.mcz
ST80-md.30.mcz
StarSqueak-sd.6.mcz
SUnit-md.30.mcz
SUnitGUI-md.5.mcz
System-md.74.mcz
Tests-md.15.mcz
ToolBuilder-Kernel-stephaneducasse.14.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.63.mcz
Traits-md.211.mcz
Speech-md.8.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
