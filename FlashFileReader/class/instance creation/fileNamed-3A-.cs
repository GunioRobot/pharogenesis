fileNamed: aString
	"FlashFileReader fileNamed:'/home/isg/raab/WDI/flash/samples/top.swf'"
	^self on: (FileStream readOnlyFileNamed: aString).