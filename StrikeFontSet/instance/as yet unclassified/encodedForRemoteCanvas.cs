encodedForRemoteCanvas

	| stream |
	stream := RWBinaryOrTextStream on: ''.
	self writeNameOn: stream.
	^ stream contents asString.
