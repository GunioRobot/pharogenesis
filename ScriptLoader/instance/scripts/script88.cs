script88

	| names|
names := '39Deprecated-md.11.mcz
Balloon-ar.13.mcz
Collections-md.70.mcz
CollectionsTests-md.33.mcz
Compiler-lr.56.mcz
Compression-ar.8.mcz
EToys-sd.21.mcz
Exceptions-sd.8.mcz
Files-md.18.mcz
FixUnderscores-cmm.10.mcz
Flash-ar.5.mcz
FlexibleVocabularies-al.5.mcz
Graphics-ar.39.mcz
GraphicsTests-ar.9.mcz
Kernel-md.148.mcz
KernelTests-lr.49.mcz
Monticello-md.308.mcz
MonticelloConfigurations-stephaneducasse.38.mcz
Morphic-sd.113.mcz
MorphicExtras-md.31.mcz
MorphicTests-md.6.mcz
Movies-md.7.mcz
Multilingual-sd.21.mcz
Nebraska-md.13.mcz
Network-md.32.mcz
NetworkTests-md.9.mcz
OB-Standard.39-cwp.3.mcz
OmniBrowser.39-cwp.1.mcz
PackageInfo-al.6.mcz
PreferenceBrowser-hpt.32.mcz
Protocols-md.12.mcz
ReleaseBuilder-md.4.mcz
SMBase-sd.85.mcz
SMLoader-gk.37.mcz
ST80-sd.35.mcz
SUnit-md.33.mcz
SUnitGUI-sd.7.mcz
Services-Base-md.33.mcz
SmaCC-md.9.mcz
Sound-md.6.mcz
Speech-md.9.mcz
StarSqueak-sd.6.mcz
System-sd.100.mcz
SystemChangeNotification-Tests-sd.5.mcz
Tests-sd.18.mcz
ToolBuilder-Kernel-cwp.17.mcz
ToolBuilder-MVC-dtl.12.mcz
ToolBuilder-Morphic-ar.19.mcz
ToolBuilder-SUnit-cwp.12.mcz
Tools-md.74.mcz
Traits-sd.226.mcz
TrueType-ar.4.mcz
VersionNumber-dew.1.mcz'
findTokens: ' ', String cr.

	self loadTogether: names merge: false.