cString
	"Generic Subchunk containing a cstring"
	| s c |
	s := WriteStream on: (String new: 128).
	[(c := source next) ~= 0] whileTrue: 
		[s nextPut: c asCharacter].
	^s contents