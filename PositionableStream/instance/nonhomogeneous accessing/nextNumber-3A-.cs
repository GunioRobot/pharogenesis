nextNumber: n 
	"Answer the next n bytes as a positive Integer or LargePositiveInteger."
	| s |
	s _ 0.
	1 to: n do: 
		[:i | s _ (s bitShift: 8) bitOr: self next asInteger].
	^ s normalize