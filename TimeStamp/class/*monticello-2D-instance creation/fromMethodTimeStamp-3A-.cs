fromMethodTimeStamp: aString
	| stream |
	(stream := aString readStream)
		skipSeparators;
		skipTo: Character space.
	^self readFrom: stream.