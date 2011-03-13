encodedForRemoteCanvas

	| stream |
	stream := RWBinaryOrTextStream on: ''.
	stream nextPutAll: self familyName.
	stream nextPut: Character space.
	stream nextPutAll: self name.
	stream nextPut: Character space.
	stream nextPutAll: self height.
	stream nextPut: Character space.
	stream nextPutAll: self emphasis asString.
	^ stream contents asString.
