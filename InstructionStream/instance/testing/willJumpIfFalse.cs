willJumpIfFalse
	"Answer whether the next bytecode is a jump-if-false."

	| byte |
	byte _ self method at: pc.
	^(byte between: 152 and: 159) or: [byte between: 172 and: 175]