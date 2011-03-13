script17
	"
	integer printOn:padded 2229
	character fixes 2254
	date fixes 2117
	compiler fix of lukas evaluate:in:to:notifying:
	http://bugs.impara.de/view.php?id=1041 LowSpaceAndInterruptHandler-3-dtl
	
	"
	"
	| res |
	res := ReadWriteStream on: String new. 
	MCWorkingCopy allManagers collect: [:each | res nextPutAll: each ancestry ancestors first name ; nextPutAll: '.mcz' ; cr].
	res contents"
	
	"| names |
	names _ '
38Deprecated-sd.5.mcz
39Deprecated-stephaneducasse.3.mcz
Balloon-stephaneducasse.7.mcz
BalloonMMFlash-stephaneducasse.3.mcz
Collections-sd.36.mcz
CollectionsTests-sd.11.mcz
Compiler-sd.22.mcz 
Compression-CdG.3.mcz
Exceptions-stephaneducasse.5.mcz
EToys-stephaneducasse.2.mcz
FFI-CdG.4.mcz
Files-CdG.13.mcz
FlexibleVocabularies-CdG.2.mcz
Graphics-CdG.16.mcz
GraphicsTests-md.3.mcz
Kernel-sd.71.mcz
KernelTests-sd.14.mcz
Morphic-stephaneducasse.56.mcz
MorphicExtras-CdG.7.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-bf.287.mcz
Movies-stephaneducasse.3.mcz
Multilingual-CdG.10.mcz
Nebraska-sd.6.mcz
Network-CdG.21.mcz
NetworkTests-md.7.mcz
PackageInfo-stephaneducasse.4.mcz
PlusTools-CdG.22.mcz
PreferenceBrowser-hpt.27.mcz
Protocols-CdG.7.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-bp.27.mcz
SmaCC-md.5.mcz
Sound-CdG.3.mcz
Speech-stephaneducasse.5.mcz
ST80-stephaneducasse.24.mcz
StarSqueak-sd.6.mcz
SUnit-CdG.28.mcz
System-al.52.mcz
Tests-CdG.9.mcz
ToolBuilder-Kernel-ar.13.mcz
ToolBuilder-Morphic-md.15.mcz
ToolBuilder-MVC-ar.8.mcz
ToolBuilder-SUnit-ar.9.mcz
Tools-al.43.mcz
Traits-al.198.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
' "

| names |
	names _
'Tools-al.43.mcz
SUnit-CdG.28.mcz
Movies-stephaneducasse.3.mcz
FlexibleVocabularies-CdG.2.mcz
ToolBuilder-Kernel-ar.13.mcz
BalloonMMFlash-stephaneducasse.3.mcz
SmaCC-md.5.mcz
KernelTests-sd.14.mcz
39Deprecated-stephaneducasse.3.mcz
VersionNumber-dew.1.mcz
ToolBuilder-MVC-ar.8.mcz
MonticelloConfigurations-md.37.mcz
ToolBuilder-SUnit-ar.9.mcz
ST80-stephaneducasse.24.mcz
ToolBuilder-Morphic-md.15.mcz
Files-CdG.13.mcz
Exceptions-stephaneducasse.5.mcz
Balloon-stephaneducasse.7.mcz
GraphicsTests-md.3.mcz
PlusTools-CdG.22.mcz
Sound-CdG.3.mcz
SMBase-stephaneducasse.69.mcz
Traits-al.198.mcz
Protocols-CdG.7.mcz
CollectionsTests-sd.11.mcz
PackageInfo-stephaneducasse.4.mcz
FFI-CdG.4.mcz
Kernel-sd.71.mcz
Network-CdG.21.mcz
PreferenceBrowser-hpt.27.mcz
MorphicExtras-CdG.7.mcz
FixUnderscores-stephaneducasse.7.mcz
MorphicTests-stephaneducasse.4.mcz
Nebraska-sd.6.mcz
ScriptLoader-sd.58.mcz
StarSqueak-sd.6.mcz
Graphics-CdG.16.mcz
Speech-stephaneducasse.5.mcz
System-al.52.mcz
38Deprecated-sd.5.mcz
Multilingual-CdG.10.mcz
Monticello-al.287.mcz
Compression-CdG.3.mcz
SMLoader-bp.27.mcz
Compiler-sd.22.mcz
Tests-CdG.9.mcz
Collections-sd.36.mcz
EToys-stephaneducasse.2.mcz
NetworkTests-md.7.mcz
Morphic-stephaneducasse.56.mcz
'
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
