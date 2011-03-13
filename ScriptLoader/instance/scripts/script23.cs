script23
	"
	new SUnit UI. 
	merged Tools-md-44
	"
	"
	| res |
	res := ReadWriteStream on: String new. 
	MCWorkingCopy allManagers collect: [:each | res nextPutAll: each ancestry ancestors first name ; nextPutAll: '.mcz' ; cr].
	res contents"
	
| names |
Flaps unregisterQuad: #(#TestRunner #prototypicalToolWindow 'Test Runner' 'The SUnit Test Runner' ) forFlapNamed: 'Tools'.
	names _ '
38Deprecated-sd.5.mcz
39Deprecated-sd.4.mcz
Balloon-stephaneducasse.7.mcz
BalloonMMFlash-stephaneducasse.3.mcz
Collections-sd.36.mcz
CollectionsTests-sd.11.mcz
Compiler-sd.24.mcz 
Compression-CdG.3.mcz
Exceptions-stephaneducasse.5.mcz
EToys-jmv.5.mcz
FFI-CdG.4.mcz
Files-CdG.13.mcz
FlexibleVocabularies-CdG.2.mcz
Graphics-CdG.16.mcz
GraphicsTests-md.3.mcz
Kernel-stephaneducasse.73.mcz
KernelTests-sd.14.mcz
Morphic-jmv.58.mcz
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
Services-Base-stephaneducasse.21.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-bp.27.mcz
SmaCC-md.5.mcz
Sound-CdG.3.mcz
Speech-stephaneducasse.5.mcz
ST80-stephaneducasse.26.mcz
StarSqueak-sd.6.mcz
SUnit-CdG.28.mcz
SUnitGUI-md.3.mcz
System-stephaneducasse.57.mcz
Tests-CdG.9.mcz
ToolBuilder-Kernel-ar.13.mcz
ToolBuilder-Morphic-md.15.mcz
ToolBuilder-MVC-ar.8.mcz
ToolBuilder-SUnit-ar.9.mcz
Tools-stephaneducasse.47.mcz
Traits-al.200.mcz
VersionNumber-dew.1.mcz
FixUnderscores-stephaneducasse.7.mcz
'  
findTokens: ' ', String cr.

	self loadTogether: names merge: true.
