script10
	"I should have introduced a new name when  I did updateFrom6696: I'm messy (sd)
	
	Load System (with LogStreamFile reintorudce and Tools without ab and merged
	Needed from here: the four changesets and PlusTools
	"
	
	| names |
	
	

	names _ '
38Deprecated-CdG.4.mcz
39Deprecated-stephaneducasse.3.mcz
Balloon-stephaneducasse.7.mcz
BalloonMMFlash-stephaneducasse.3.mcz
Collections-CdG.35.mcz
CollectionsTests-md.10.mcz
Compiler-CdG.19.mcz 
Compression-CdG.3.mcz
Exceptions-CdG.4.mcz
EToys-stephaneducasse.2.mcz
FFI-CdG.4.mcz
Files-CdG.13.mcz
FlexibleVocabularies-CdG.2.mcz
Graphics-CdG.16.mcz
GraphicsTests-md.3.mcz
Kernel-CdG.49.mcz
KernelTests-CdG.13.mcz
Morphic-CdG.55.mcz
MorphicExtras-CdG.7.mcz
MorphicTests-stephaneducasse.4.mcz
Monticello-bf.277.mcz
Movies-stephaneducasse.3.mcz
Multilingual-CdG.10.mcz
Nebraska-CdG.5.mcz
Network-CdG.21.mcz
NetworkTests-md.7.mcz
PackageInfo-stephaneducasse.4.mcz
PreferenceBrowser-hpt.27.mcz
Protocols-CdG.7.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-bp.27.mcz
SmaCC-md.5.mcz
Sound-CdG.3.mcz
Speech-stephaneducasse.5.mcz
ST80-CdG.23.mcz
StarSqueak-CdG.5.mcz
SUnit-CdG.28.mcz
System-stephaneducasse.47.mcz
Tests-CdG.9.mcz
ToolBuilder-Kernel-ar.13.mcz
ToolBuilder-Morphic-md.15.mcz
ToolBuilder-MVC-ar.8.mcz
ToolBuilder-SUnit-ar.9.mcz
Tools-stephaneducasse.38.mcz
VersionNumber-dew.1.mcz
' findTokens: ' ', String cr.

	self loadTogether: names merge: true.
	
