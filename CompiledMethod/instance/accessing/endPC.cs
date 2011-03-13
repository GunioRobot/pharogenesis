endPC
	"Answer the index of the last bytecode."
	| size flagByte |
	"Can't create a zero-sized CompiledMethod so no need to use last for the errorEmptyCollection check.
	 We can reuse size."
	size := self size.
	flagByte := self at: size.
	flagByte = 0 ifTrue:
		["If last byte = 0, may be either 0, 0, 0, 0 or just 0"
		1 to: 4 do: [:i | (self at: size - i) = 0 ifFalse: [^size - i]]].
	flagByte < 252 ifTrue:
		["Magic sources (temp names encoded in last few bytes)"
		^flagByte <= 127
			ifTrue: [size - flagByte - 1]
			ifFalse: [size - (flagByte - 128 * 128) - (self at: size - 1) - 2]].
	"Normal 4-byte source pointer"
	^size - 4