createStringStartingAt: index for: bytes

	| results candidate data |
	data _ String new: bytes*2.
	results _ WriteStream on: data.
	index to: index+bytes -1 do: 
		[:i |
		candidate _ ((self at: i) printStringBase: 16) last: 2.
		candidate first = $r ifTrue: [candidate _ String with: $0 with: candidate last].
		results nextPutAll: candidate].
	^data asLowercase