processSignature
	"Check the signature of the SWF file"
	stream nextByte asCharacter = $F ifFalse:[^false].
	stream nextByte asCharacter = $W ifFalse:[^false].
	stream nextByte asCharacter = $S ifFalse:[^false].
	^true