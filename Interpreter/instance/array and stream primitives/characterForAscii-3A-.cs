characterForAscii: ascii  "Arg must lie in range 0-255!"
	self inline: true.
	^ self fetchPointer: ascii ofObject: (self splObj: CharacterTable)