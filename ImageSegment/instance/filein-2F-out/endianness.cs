endianness
	"Return which endian kind the incoming segment came from"

	^ (segment first bitShift: -24) asCharacter == $d ifTrue: [#big] ifFalse: [#little]