script2
	"deprecated + CurrentProjectRefactoring + collection tests"
	
	| vm names  |
repository _ MCHttpRepository
                location: 'http://source.squeakfoundation.org/39a'
                user: ''
                password: ''.

names _ '
38Deprecated-md.3.mcz
39Deprecated-stephaneducasse.3.mcz
Balloon-stephaneducasse.7.mcz
BalloonMMFlash-stephaneducasse.3.mcz
Collections-stephaneducasse.29.mcz
CollectionsTests-stephaneducasse.9.mcz
Compiler-stephaneducasse.12.mcz
Compression-md.2.mcz
Exceptions-md.3.mcz
EToys-stephaneducasse.2.mcz
FFI-tbn.3.mcz
Files-stephaneducasse.8.mcz
FlexibleVocabularies-stephaneducasse.1.mcz
Graphics-stephaneducasse.13.mcz
GraphicsTests-md.3.mcz
Kernel-stephaneducasse.36.mcz
KernelTests-md.9.mcz
Morphic-stephaneducasse.47.mcz
MorphicExtras-stephaneducasse.2.mcz
MorphicTests-stephaneducasse.4.mcz
Movies-stephaneducasse.3.mcz
Multilingual-stephaneducasse.6.mcz
Nebraska-stephaneducasse.4.mcz
Network-stephaneducasse.16.mcz
NetworkTests-md.7.mcz
PackageInfo-md.3.mcz
PreferenceBrowser-hpt.27.mcz
Protocols-stephaneducasse.4.mcz
SMBase-stephaneducasse.69.mcz
SMLoader-md.26.mcz
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
Tools-stephaneducasse.30.mcz
VersionNumber-dew.1.mcz
' findTokens: ' ', String cr.

vm _ MCVersionMerger new.
names
    do: [:fn | vm addVersion: (repository loadVersionFromFileNamed: fn)]
    displayingProgress: 'Adding versions...'.
vm merge

