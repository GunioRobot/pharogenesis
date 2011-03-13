interpretJump

	| byte |
	byte _ self method at: pc.
	(byte between: 144 and: 151) ifTrue:
		[pc _ pc + 1. ^byte - 143].
	(byte between: 160 and: 167) ifTrue:
		[pc _ pc + 2. ^(byte - 164) * 256 + (self method at: pc - 1)].
	^nil