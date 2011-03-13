script42
	
| names |
names := '
39Deprecated-md.10.mcz
Balloon-ar.9.mcz
Flash-ar.1.mcz
TrueType-ar.1.mcz
Collections-md.49.mcz
CollectionsTests-md.17.mcz
Compiler-md.42.mcz 
Compression-stephaneducasse.4.mcz
Exceptions-md.7.mcz
EToys-md.11.mcz
FFI-CdG.4.mcz
Files-stephaneducasse.15.mcz
FlexibleVocabularies-stephaneducasse.3.mcz
Graphics-stephaneducasse.26.mcz
GraphicsTests-md.3.mcz
Kernel-md.102.mcz
KernelTests-md.28.mcz
Morphic-md.75.mcz
MorphicExtras-md.17.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-md.293.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Movies-stephaneducasse.4.mcz
Multilingual-stephaneducasse.11.mcz
Nebraska-md.7.mcz
Network-md.22.mcz
NetworkTests-gk.8.mcz
OmniBrowser-md.276.mcz
OB-Standard-cwp.93.mcz
PackageInfo-stephaneducasse.4.mcz
ReleaseBuilder-md.3.mcz
PlusTools-md.33.mcz
PreferenceBrowser-stephaneducasse.29.mcz
Protocols-stephaneducasse.8.mcz
Services-Base-md.26.mcz
SMBase-stephaneducasse.71.mcz
SMLoader-md.29.mcz
SmaCC-stephaneducasse.6.mcz
Sound-stephaneducasse.4.mcz
ST80-md.30.mcz
StarSqueak-sd.6.mcz
SUnit-md.30.mcz
SUnitGUI-md.5.mcz
System-md.73.mcz
Tests-md.14.mcz
ToolBuilder-Kernel-stephaneducasse.14.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.62.mcz
Traits-md.208.mcz
Speech-md.8.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
