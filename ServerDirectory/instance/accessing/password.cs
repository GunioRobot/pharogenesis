password

	passwordHolder ifNil: [passwordHolder _ Password new].
	^ passwordHolder passwordFor: self	"may ask the user"