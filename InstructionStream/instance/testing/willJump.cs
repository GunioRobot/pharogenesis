willJump
	"unconditionally"

	| byte |
	byte _ self method at: pc.
	^ (byte between: 144 and: 151) or: [byte between: 160 and: 167]