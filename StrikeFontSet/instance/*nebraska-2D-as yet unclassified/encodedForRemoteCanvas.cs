encodedForRemoteCanvas

	| stream |
	stream := RWBinaryOrTextStream on: ''.
	stream nextPutAll: self familyName.
	stream nextPut: Character space.
	stream nextPutAll: self pointSize asString.
	stream nextPut: Character space.
	stream nextPutAll: self emphasis asString.
	^ stream contents asString.
