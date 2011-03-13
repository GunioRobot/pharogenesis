encodedForRemoteCanvas
	| stream |
	stream := RWBinaryOrTextStream on: ''.
	self writeAsStrike2On: stream.
	^stream contents asString