size
	| n cell |
	n _ 0.
	cell _ self.
	[cell == nil] whileFalse:[
		n _ n + 1.
		cell _ cell nextCell].
	^n