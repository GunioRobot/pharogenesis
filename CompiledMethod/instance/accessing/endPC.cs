endPC
	"Answer the index of the last bytecode."
	| flagByte |
	flagByte _ self last.
	flagByte = 0 ifTrue:
		["If last byte = 0, may be either 0, 0, 0, 0 or just 0"
		1 to: 4 do: [:i | (self at: self size - i) = 0 ifFalse: [^ self size - i]]].
	flagByte < 252 ifTrue:
		["Magic sources (tempnames encoded in last few bytes)"
		^ self size - self last - 1].
	"Normal 4-byte source pointer"
	^ self size - 4