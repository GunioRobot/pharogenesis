script72

	| names|
names := '39Deprecated-md.11.mcz
Balloon-ar.13.mcz
Collections-pmm.68.mcz
CollectionsTests-sd.30.mcz
Compiler-lr.50.mcz
Compression-ar.8.mcz
EToys-sd.21.mcz
Exceptions-sd.8.mcz
FFI-ar.11.mcz
Files-md.17.mcz
FixInvisible-bf.1.mcz
FixUnderscores-cmm.10.mcz
Flash-ar.5.mcz
FlexibleVocabularies-al.5.mcz
Graphics-ar.38.mcz
GraphicsTests-ar.9.mcz
Kernel-sd.138.mcz
KernelTests-sd.42.mcz
Monticello-al.305.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Morphic-sd.99.mcz
MorphicExtras-sd.29.mcz
MorphicTests-md.5.mcz
Movies-md.7.mcz
Multilingual-sd.21.mcz
Nebraska-sd.11.mcz
Network-sd.30.mcz
NetworkTests-gk.8.mcz
OB-Standard-al.112.mcz
OmniBrowser-lr.281.mcz
PackageInfo-al.6.mcz
PlusTools-md.34.mcz
PreferenceBrowser-hpt.32.mcz
Protocols-md.12.mcz
ReleaseBuilder-md.4.mcz
SMBase-gk.84.mcz
SMLoader-gk.31.mcz
ST80-sd.34.mcz
SUnit-md.32.mcz
SUnitGUI-sd.7.mcz
ScriptLoader-sd.243.mcz
Services-Base-md.27.mcz
SmaCC-md.9.mcz
Sound-md.6.mcz
Speech-md.8.mcz
StarSqueak-sd.6.mcz
System-md.88.mcz
SystemChangeNotification-Tests-sd.5.mcz
Tests-md.17.mcz
ToolBuilder-Kernel-sd.15.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.68.mcz
Traits-sd.222.mcz
TrueType-md.2.mcz
VersionNumber-dew.1.mcz'
findTokens: ' ', String cr.

	self loadTogether: names merge: false.