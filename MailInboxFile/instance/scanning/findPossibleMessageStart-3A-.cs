findPossibleMessageStart: aStream
	"Find the next line starting with the string 'From' followed by a space. Leave the input stream positioned at the character following the space."

	(self nextStringIs: 'From ' in: aStream) ifTrue: [^true].
	[true] whileTrue: [
		aStream skipTo: Character cr.
		[aStream peek = Character cr] whileTrue: [aStream next].
		(self nextStringIs: 'From ' in: aStream) ifTrue: [^true].
		aStream atEnd ifTrue: [^false].
	].