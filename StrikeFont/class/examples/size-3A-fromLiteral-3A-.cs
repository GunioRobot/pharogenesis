size: pointSize fromLiteral: aString
	"This method allows a font set to be captured as sourcecode in a subclass.
	The string literals will presumably be created by printing, eg,
		(FileStream readOnlyFileNamed: 'Palatino24.sf2') contentsOfEntireFile,
		and then pasting into a browser after a heading like, eg,
size24
	^ self size: 24 fromLiteral:
	'--unreadable binary data--'

	See the method hackDefaultStyle to see how this can be used
"
	^ (StrikeFont new readFromStrike2Stream:
		(ReadWriteStream on: aString asByteArray from: 1 to: aString size))
		name: self name , (pointSize < 10 ifTrue: ['0' , pointSize printString]
										ifFalse: [pointSize printString])