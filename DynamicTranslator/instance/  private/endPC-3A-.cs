endPC: aCompiledMethod
	"Answer the 0-based index, relative to aCompiledMethod, of the last bytecode."
	"Note: this is based closely on CompiledMethod>>endPC"

	| lastIndex flagByte |
	lastIndex _ self stSizeOf: newMethod.			"1-based Smalltalk index of last byte in method"
	lastIndex _ lastIndex + BaseHeaderSize - 1.	"0-based VM index of last byte in method"
	flagByte _ self byteAt: aCompiledMethod + lastIndex.
	flagByte = 0 ifTrue:
		["If last byte = 0, may be either 0, 0, 0, 0 or just 0"
		 1 to: 4 do: [:i | (self byteAt: aCompiledMethod + lastIndex - i) = 0 ifFalse:[^lastIndex - i]]].
	flagByte < 252 ifTrue:
		["tempnames encoded in last few bytes; last byte is size of encoding bytes"
		^lastIndex - flagByte - 1].
	"Normal 4-byte source pointer"
	^lastIndex - 4