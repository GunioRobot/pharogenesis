scanToNextMessageIn: aStream
	"Scan to the start of the next message. Answer true if we find a message delimiter, false if we hit the end of the file first. The stream is left positioned at the start of the next message (at the message delimiter) or at the end of the stream."

	| delimiter |
	[self scanToNextAndSigns: aStream] whileTrue:
		[delimiter _ aStream next: 10.
		 ((delimiter = '&&&&&start') or: [delimiter = '&&&&&XXXXX'])
			ifTrue: [aStream skip: -10. ^true]
			ifFalse: [aStream skip: -5]  "Keep going - it was't a delimiter"
		].
	^false	"end of file"