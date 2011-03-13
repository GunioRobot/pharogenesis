script6
	"to work script 5 should be loaded first."
	
	"Change Set:		scanFor
	Change Set:		withOutLeadingBlanks
	SharedQueue2 : An implementation of a shared queue based on class Monitor. 
	Change Set:		FasterRectangelInsetBy
	Change Set:		Complex-ln-bug-1815-v1
	Change Set:		DebuggerCreateFix-md
	"
	
	| names |
	
	self loadOneAfterTheOther: #('Kernel-md.42.mcz') merge: false.

	names _ '
38Deprecated-md.3.mcz
39Deprecated-stephaneducasse.3.mcz
Balloon-stephaneducasse.7.mcz
BalloonMMFlash-stephaneducasse.3.mcz
Collections-md.32.mcz
CollectionsTests-md.10.mcz
Compiler-md.13.mcz
Compression-md.2.mcz
Exceptions-md.3.mcz
EToys-stephaneducasse.2.mcz
FFI-tbn.3.mcz
Files-stephaneducasse.8.mcz
FlexibleVocabularies-stephaneducasse.1.mcz
Graphics-md.14.mcz
GraphicsTests-md.3.mcz
Kernel-md.42.mcz
KernelTests-md.11.mcz
Morphic-stephaneducasse.51.mcz
MorphicExtras-md.4.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-md.275.mcz
Movies-stephaneducasse.3.mcz
Multilingual-stephaneducasse.8.mcz
Nebraska-stephaneducasse.4.mcz
Network-stephaneducasse.17.mcz
NetworkTests-md.7.mcz
PackageInfo-md.3.mcz
PreferenceBrowser-hpt.27.mcz
Protocols-stephaneducasse.4.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-bp.27.mcz
SmaCC-md.5.mcz
Sound-stephaneducasse.2.mcz
Speech-stephaneducasse.5.mcz
ST80-stephaneducasse.19.mcz
StarSqueak-stephaneducasse.4.mcz
SUnit-md.26.mcz
System-stephaneducasse.43.mcz
Tests-md.8.mcz
ToolBuilder-Kernel-ar.13.mcz
ToolBuilder-Morphic-md.15.mcz
ToolBuilder-MVC-ar.8.mcz
Tools-md.33.mcz
VersionNumber-dew.1.mcz
' findTokens: ' ', String cr.

	self loadTogether: names merge: true.