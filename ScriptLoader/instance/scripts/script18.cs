script18
	"
	integer printOn:padded 2229
	character fixes 2254
	date fixes 2117
	compiler fix of lukas evaluate:in:to:notifying:
	http://bugs.impara.de/view.php?id=1041 LowSpaceAndInterruptHandler-3-dtl
	added omnibrowser.273
	"
	"
	| res |
	res := ReadWriteStream on: String new. 
	MCWorkingCopy allManagers collect: [:each | res nextPutAll: each ancestry ancestors first name ; nextPutAll: '.mcz' ; cr].
	res contents"
	
| names |
	names _ '
38Deprecated-sd.5.mcz
39Deprecated-sd.4.mcz
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
Monticello-al.287.mcz
MonticelloConfigurations-md.37.mcz
Movies-stephaneducasse.3.mcz
Multilingual-CdG.10.mcz
Nebraska-sd.6.mcz
Network-CdG.21.mcz
NetworkTests-md.7.mcz
OmniBrowser-cwp.273.mcz
PackageInfo-stephaneducasse.4.mcz
PlusTools-CdG.22.mcz
PreferenceBrowser-hpt.27.mcz
Protocols-CdG.7.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-bp.27.mcz
SmaCC-md.5.mcz
Sound-CdG.3.mcz
Speech-stephaneducasse.5.mcz
ST80-sd.25.mcz
StarSqueak-sd.6.mcz
SUnit-CdG.28.mcz
System-sd.53.mcz
Tests-CdG.9.mcz
ToolBuilder-Kernel-ar.13.mcz
ToolBuilder-Morphic-md.15.mcz
ToolBuilder-MVC-ar.8.mcz
ToolBuilder-SUnit-ar.9.mcz
Tools-al.43.mcz
Traits-al.198.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
