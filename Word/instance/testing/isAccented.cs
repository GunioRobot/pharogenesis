isAccented
	^ (self syllables detect: [ :one | one isAccented] ifNone: []) notNil