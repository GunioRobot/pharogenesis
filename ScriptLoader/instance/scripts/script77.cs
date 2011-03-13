script77

	| names|
names := '39Deprecated-md.11.mcz
Balloon-ar.13.mcz
Collections-md.70.mcz
CollectionsTests-md.33.mcz
Compiler-md.51.mcz
Compression-ar.8.mcz
EToys-sd.21.mcz
Exceptions-sd.8.mcz
FFI-md.12.mcz
Files-md.18.mcz
FixInvisible-bf.1.mcz
FixUnderscores-cmm.10.mcz
Flash-ar.5.mcz
FlexibleVocabularies-al.5.mcz
Graphics-ar.39.mcz
GraphicsTests-ar.9.mcz
Kernel-md.144.mcz
KernelTests-md.45.mcz
Monticello-md.308.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Morphic-md.107.mcz
MorphicExtras-md.31.mcz
MorphicTests-md.6.mcz
Movies-md.7.mcz
Multilingual-sd.21.mcz
Nebraska-sd.11.mcz
Network-md.32.mcz
NetworkTests-md.9.mcz
OB-Standard.39-cwp.3.mcz
OmniBrowser.39-cwp.1.mcz
PackageInfo-al.6.mcz
PlusTools-md.34.mcz
PreferenceBrowser-hpt.32.mcz
Protocols-md.12.mcz
ReleaseBuilder-md.4.mcz
SMBase-sd.85.mcz
SMLoader-md.32.mcz
ST80-sd.35.mcz
SUnit-md.32.mcz
SUnitGUI-sd.7.mcz
Services-Base-md.27.mcz
SmaCC-md.9.mcz
Sound-md.6.mcz
Speech-md.9.mcz
StarSqueak-sd.6.mcz
System-md.90.mcz
SystemChangeNotification-Tests-sd.5.mcz
Tests-md.17.mcz
ToolBuilder-Kernel-cwp.17.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-Morphic-ar.19.mcz
ToolBuilder-SUnit-cwp.12.mcz
Tools-md.71.mcz
Traits-al.224.mcz
TrueType-md.2.mcz
VersionNumber-dew.1.mcz'
findTokens: ' ', String cr.

	self loadTogether: names merge: false.