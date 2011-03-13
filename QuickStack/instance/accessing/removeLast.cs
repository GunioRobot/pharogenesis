removeLast
	| answer |
	answer _ self at: top.
	top _ top - 1.
	^ answer