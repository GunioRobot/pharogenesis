scanToNextMessageIn: aStream
	"Scan to the start of the next message. Answer true if we find a message delimiter, false if we hit the end of the file first. The stream is left positioned at the start of the next message (at the message delimiter) or at the end of the stream."

	| delimiter |
	[self scanToNextAndSigns: aStream] whileTrue:
		[delimiter _ aStream next: 8.
		 ((delimiter = '&&&start') or: [delimiter = '&&&XXXXX'])
			ifTrue: [aStream skip: -10. ^true]
			ifFalse: [(delimiter includes: $&) ifTrue: [aStream skip: -8]]].
	^false	"end of file"