nextByte
	| byte |
	byte _ theStream next.
	byte == nil
		ifTrue:[^nil]
		ifFalse:[^byte asInteger]