wordSize
	"Answer the size (in bytes) of an object pointer."
	"Smalltalk wordSize"

	^[SmalltalkImage current vmParameterAt: 40] on: Error do: [4]