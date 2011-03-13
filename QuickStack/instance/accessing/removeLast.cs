removeLast
	| answer |
	answer := self at: top.
	top := top - 1.
	^ answer