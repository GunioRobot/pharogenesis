fontNamed: fontName fromLiteral: aString
	"This method allows a font set to be captured as sourcecode in a subclass.
	The string literals will presumably be created by printing, eg,
		(FileStream readOnlyFileNamed: 'Palatino24.sf2') contentsOfEntireFile,
		and then pasting into a browser after a heading like, eg,
sizeNewYork10
	^ self fontNamed: 'NewYork10' fromLiteral:
	'--unreadable binary data--'

	See the method installAsTextStyle to see how this can be used."

	^ StrikeFont new 
		name: fontName;
		readFromStrike2Stream: (ReadStream on: aString asByteArray)