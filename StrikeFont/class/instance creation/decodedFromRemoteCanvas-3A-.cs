decodedFromRemoteCanvas: aString
	| stream |
	stream := RWBinaryOrTextStream with: aString.
	stream reset.
	stream binary.
	^self new readFromStrike2Stream: stream