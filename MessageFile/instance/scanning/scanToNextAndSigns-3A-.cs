scanToNextAndSigns: aStream
	"Scan the given stream for a pair of and-sign (&) characters and answer true if they are found before the end of the stream is reached. The stream is left positioned after the second and-sign or at the end of the stream."

	| ch |
	[true] whileTrue:
		[ch _ aStream next.
		 ((ch == $&) and:
		   [aStream next == $&]) ifTrue: [^true].	"found"
		 (ch == nil) ifTrue: [^false]].	"end of file"