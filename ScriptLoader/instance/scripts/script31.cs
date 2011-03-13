script31
	"0002135: Cmd-. don't work with various Mac Os X keyboard layout
	lukas TextAnchor fixes"
	
| names |
names _ '
38Deprecated-sd.5.mcz
39Deprecated-md.5.mcz
Balloon-ar.9.mcz
Flash-ar.1.mcz
TrueType-ar.1.mcz
Morphic-Balloon-ar.1.mcz
Morphic-TrueType-ar.1.mcz
Collections-md.41.mcz
CollectionsTests-md.12.mcz
Compiler-md.31.mcz 
Compression-CdG.3.mcz
Exceptions-sd.6.mcz
EToys-md.6.mcz
FFI-CdG.4.mcz
Files-md.14.mcz
FlexibleVocabularies-CdG.2.mcz
Graphics-stephaneducasse.26.mcz
GraphicsTests-md.3.mcz
Kernel-sd.84.mcz
KernelTests-stephaneducasse.15.mcz
Morphic-stephaneducasse.64.mcz
MorphicExtras-stephaneducasse.10.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-al.287.mcz
MonticelloConfigurations-md.37.mcz
Movies-stephaneducasse.3.mcz
Multilingual-stephaneducasse.11.mcz
Nebraska-sd.6.mcz
Network-CdG.21.mcz
NetworkTests-md.7.mcz
OmniBrowser-stephaneducasse.274.mcz
PackageInfo-stephaneducasse.4.mcz
ReleaseBuilder-stephaneducasse.2.mcz
PlusTools-md.24.mcz
PreferenceBrowser-stephaneducasse.28.mcz
Protocols-CdG.7.mcz
Services-Base-md.23.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-bp.27.mcz
SmaCC-md.5.mcz
Sound-CdG.3.mcz
ST80-md.27.mcz
StarSqueak-sd.6.mcz
SUnit-stephaneducasse.29.mcz
SUnitGUI-lr.4.mcz
System-stephaneducasse.61.mcz
Tests-stephaneducasse.10.mcz
ToolBuilder-Kernel-stephaneducasse.14.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-ar.8.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.51.mcz
Traits-al.200.mcz
Speech-stephaneducasse.7.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
