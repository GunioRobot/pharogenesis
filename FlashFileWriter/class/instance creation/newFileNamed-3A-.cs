newFileNamed: aString
	"FlashFileWriter newFileNamed:'f:\wdi\GraphicsEngine\flash\test.swf'"
	^self on: (FileStream newFileNamed: aString).