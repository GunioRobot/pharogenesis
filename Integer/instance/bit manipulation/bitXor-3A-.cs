bitXor: n 
	"Answer an Integer whose bits are the logical XOR of the receiver's bits 
	and those of the argument, n."
	| norm |
	norm _ n normalize.
	^self
		digitLogic: norm
		op: #bitXor:
		length: (self digitLength max: norm digitLength)