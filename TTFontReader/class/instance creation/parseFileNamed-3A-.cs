parseFileNamed: aString
	"TTFontReader parseFileNamed:'c:\windows\arial.ttf'"
	"TTFontReader parseFileNamed:'c:\windows\times.ttf'"
	| contents |
	contents _ (FileStream readOnlyFileNamed: aString) binary contentsOfEntireFile.
	^self readFrom: (ReadStream on: contents)