script564

	| names |
names := 'Announcements-adrian_lienhard.22.mcz
Balloon-MarcusDenker.33.mcz
Collections-Abstract-StephaneDucasse.28.mcz
Collections-Arrayed-MarcusDenker.21.mcz
Collections-Sequenceable-StephaneDucasse.37.mcz
Collections-SkipLists-adrian_lienhard.6.mcz
Collections-Stack-stephane_ducasse.3.mcz
Collections-Streams-StephaneDucasse.28.mcz
Collections-Strings-MarcusDenker.42.mcz
Collections-Support-StephaneDucasse.10.mcz
Collections-Text-StephaneDucasse.14.mcz
Collections-Unordered-StephaneDucasse.38.mcz
Collections-Weak-StephaneDucasse.13.mcz
CollectionsTests-MarcusDenker.393.mcz
Compiler-AdrianLienhard.139.mcz
CompilerTests-AdrianLienhard.25.mcz
Compression-StephaneDucasse.37.mcz
EToys-StephaneDucasse.114.mcz
Exceptions-StephaneDucasse.38.mcz
Files-StephaneDucasse.ducasse.84.mcz
FixUnderscores-stephane_ducasse.17.mcz
FreeType-StephaneDucasse.463.mcz
FreeTypeSubPixelAntiAliasing-stephane_ducasse.18.mcz
FreeTypeTests-tween.1.mcz
Gofer-AdrianLienhard.72.mcz
Graphics-StephaneDucasse.135.mcz
GraphicsTests-StephaneDucasse.20.mcz
HostMenus-StephaneDucasse.31.mcz
Kernel-AdrianLienhard.435.mcz
KernelTests-AdrianLienhard.161.mcz
Monticello-StephaneDucasse.400.mcz
MonticelloConfigurations-stephane_ducasse.54.mcz
MonticelloGUI-AdrianLienhard.18.mcz
Morphic-StephaneDucasse.386.mcz
MorphicTests-StephaneDucasse.20.mcz
Multilingual-StephaneDucasse.85.mcz
MultilingualTests-marcus_denker.denker.5.mcz
Network-Kernel-StephaneDucasse.19.mcz
Network-MIME-marcus_denker.9.mcz
Network-MailSending-StephaneDucasse.4.mcz
Network-Protocols-StephaneDucasse.16.mcz
Network-RFC822-StephaneDucasse.4.mcz
Network-RemoteDirectory-StephaneDucasse.16.mcz
Network-URI-StephaneDucasse.8.mcz
Network-UUID-StephaneDucasse.6.mcz
Network-Url-StephaneDucasse.15.mcz
NetworkTests-StephaneDucasse.16.mcz
PackageInfo-StephaneDucasse.34.mcz
PinesoftEnhancementsForFreetype-marcus_denker.4.mcz
Polymorph-EventEnhancements-StephaneDucasse.6.mcz
Polymorph-Geometry-stephane_ducasse.5.mcz
Polymorph-ToolBuilder-StephaneDucasse.15.mcz
Polymorph-Tools-Diff-StephaneDucasse.30.mcz
Polymorph-Widgets-StephaneDucasse.103.mcz
PreferenceBrowser-StephaneDucasse.45.mcz
ST80-StephaneDucasse.81.mcz
SUnit-AdrianLienhard.82.mcz
SUnitGUI-AdrianLienhard.42.mcz
Services-Base-StephaneDucasse.55.mcz
SplitJoin-adrian_lienhard.37.mcz
System-Applications-marcus_denker.8.mcz
System-Change Notification-marcus_denker.9.mcz
System-Changes-MarcusDenker.15.mcz
System-Clipboard-StephaneDucasse.9.mcz
System-Digital Signatures-StephaneDucasse.5.mcz
System-Download-MikeRoberts.11.mcz
System-FilePackage-StephaneDucasse.12.mcz
System-FileRegistry-stephane_ducasse.6.mcz
System-Finalization-adrian_lienhard.10.mcz
System-Hashing-StephaneDucasse.4.mcz
System-Localization-adrian_lienhard.18.mcz
System-Object Events-sd.2.mcz
System-Object Storage-StephaneDucasse.32.mcz
System-Platforms-stephane_ducasse.4.mcz
System-Pools-sd.2.mcz
System-Serial Port-StephaneDucasse.8.mcz
System-Support-AdrianLienhard.103.mcz
System-Tools-StephaneDucasse.12.mcz
Tests-AdrianLienhard.34.mcz
ToolBuilder-Kernel-adrian_lienhard.31.mcz
ToolBuilder-Morphic-adrian_lienhard.44.mcz
ToolBuilder-SUnit-adrian_lienhard.24.mcz
Tools-StephaneDucasse.221.mcz
ToolsTest-stephane_ducasse.denker.5.mcz
Traits-AdrianLienhard.321.mcz
TrueType-MarcusDenker.14.mcz
VB-Regex-StephaneDucasse.33.mcz'
findTokens: String lf , String cr.

	self loadTogether: names merge: false.