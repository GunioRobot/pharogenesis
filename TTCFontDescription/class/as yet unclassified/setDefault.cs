setDefault
"
	self setDefault
"

	TTCDefault _ TTCFontReader readFrom: (FileStream readOnlyFileNamed: 'C:\WINDOWS\Fonts\msgothic.ttc').
	self clearDescriptions.

