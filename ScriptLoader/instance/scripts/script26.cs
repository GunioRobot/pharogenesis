script26
	"Bugfixes:
	move scopeHas:ifTrue: to *39Deprecated, fix the senders
	JMMRemoveExtraIndexCheck: faster second...8th 
	fix open File directly
	WindowColorRegistry (Hernán Tylim)
	Fix to open real Workspace
	"
	
| names |
names _ '
38Deprecated-sd.5.mcz
39Deprecated-md.5.mcz
Balloon-stephaneducasse.7.mcz
BalloonMMFlash-stephaneducasse.3.mcz
Collections-md.37.mcz
CollectionsTests-sd.11.mcz
Compiler-md.27.mcz 
Compression-CdG.3.mcz
Exceptions-sd.6.mcz
EToys-md.6.mcz
FFI-CdG.4.mcz
Files-CdG.13.mcz
FlexibleVocabularies-CdG.2.mcz
Graphics-CdG.16.mcz
GraphicsTests-md.3.mcz
Kernel-md.77.mcz
KernelTests-stephaneducasse.15.mcz
Morphic-md.59.mcz
MorphicExtras-jmv.9.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-al.287.mcz
MonticelloConfigurations-md.37.mcz
Movies-stephaneducasse.3.mcz
Multilingual-CdG.10.mcz
Nebraska-sd.6.mcz
Network-CdG.21.mcz
NetworkTests-md.7.mcz
OmniBrowser-stephaneducasse.274.mcz
PackageInfo-stephaneducasse.4.mcz
PlusTools-CdG.22.mcz
PreferenceBrowser-stephaneducasse.28.mcz
Protocols-CdG.7.mcz
Services-Base-md.22.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-bp.27.mcz
SmaCC-md.5.mcz
Sound-CdG.3.mcz
Speech-stephaneducasse.5.mcz
ST80-stephaneducasse.26.mcz
StarSqueak-sd.6.mcz
SUnit-CdG.28.mcz
SUnitGUI-md.3.mcz
System-md.58.mcz
Tests-CdG.9.mcz
ToolBuilder-Kernel-ar.13.mcz
ToolBuilder-Morphic-md.15.mcz
ToolBuilder-MVC-ar.8.mcz
ToolBuilder-SUnit-ar.9.mcz
Tools-md.48.mcz
Traits-al.200.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
