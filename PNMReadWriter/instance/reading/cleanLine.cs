cleanLine
	"upTo LF or CR, tab as space"

	| line loop b |
	line _ WriteStream with: ''.
	loop _ true.
	[loop] whileTrue: [
		b _ stream next.
		b ifNil:[
			loop _ false		"EOS"
		]
		ifNotNil: [
			(b = (Character cr) or:[b = Character lf]) ifTrue:[
				loop _ false.
			]
			ifFalse:[
				b = (Character tab) ifTrue:[b _ Character space].
				line nextPut: b.
			]
		]
	].
	^line contents