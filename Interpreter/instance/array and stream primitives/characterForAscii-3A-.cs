characterForAscii: integerObj  "Arg must lie in range 0-255!"
	^ self fetchPointer: (self integerValueOf: integerObj)
			ofObject: (self splObj: CharacterTable)