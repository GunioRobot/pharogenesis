testNBitAndNNegatedEqualsN
	"Verify that (n bitAnd: n negated) = n for single bits"
	| n |
	1 to: 100 do: [:i | n _ 1 bitShift: i.
				self assert: (n bitAnd: n negated) = n]