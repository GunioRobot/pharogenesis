willJumpIfTrue 
	"Answer whether the next bytecode is a jump-if-true."
 
	| byte |
	byte _ self method at: pc.
	^ byte between: 168 and: 171