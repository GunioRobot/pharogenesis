script67

	| names|
names := '39Deprecated-md.11.mcz
Balloon-mir.11.mcz
Collections-sd.63.mcz
CollectionsTests-sd.27.mcz
Compiler-lr.49.mcz
Compression-stephaneducasse.4.mcz
EToys-md.20.mcz
Exceptions-md.7.mcz
FFI-CdG.4.mcz
Files-md.16.mcz
FixInvisible-bf.1.mcz
FixUnderscores-md.9.mcz
Flash-md.3.mcz
FlexibleVocabularies-al.5.mcz
Graphics-md.35.mcz
GraphicsTests-ar.8.mcz
Kernel-sd.128.mcz
KernelTests-lr.38.mcz
Monticello-al.305.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Morphic-sd.96.mcz
MorphicExtras-md.27.mcz
MorphicTests-stephaneducasse.4.mcz
Movies-md.7.mcz
Multilingual-md.20.mcz
Nebraska-md.10.mcz
Network-sd.30.mcz
NetworkTests-gk.8.mcz
OB-Standard-sd.109.mcz
OmniBrowser-lr.281.mcz
PackageInfo-al.6.mcz
PlusTools-md.34.mcz
PreferenceBrowser-md.30.mcz
Protocols-md.12.mcz
ReleaseBuilder-md.4.mcz
ScriptLoader-sd.202.mcz
Services-Base-md.27.mcz
SMBase-gk.84.mcz
SMLoader-gk.31.mcz
SmaCC-fbs.8.mcz
Sound-md.6.mcz
Speech-md.8.mcz
ST80-md.33.mcz
StarSqueak-sd.6.mcz
SUnit-md.32.mcz
SUnitGUI-sd.7.mcz
System-sd.87.mcz
SystemChangeNotification-Tests-sd.5.mcz
Tests-md.17.mcz
ToolBuilder-Kernel-sd.15.mcz
ToolBuilder-Morphic-stephaneducasse.16.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-SUnit-stephaneducasse.10.mcz
Tools-md.68.mcz
Traits-al.220.mcz
TrueType-md.2.mcz
VersionNumber-dew.1.mcz'
findTokens: ' ', String cr.

	self loadTogether: names merge: true.