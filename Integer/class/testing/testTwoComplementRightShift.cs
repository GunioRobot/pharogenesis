testTwoComplementRightShift
	"self testTwoComplementRightShift"
	| large small |
	small _ 2 << 16.
	large _ 2 << 32.
	"2-complement test"
	(small negated bitShift: -1) ~= ((small + 1) negated bitShift: -1)
		== ((large negated bitShift: -1) ~= ((large + 1) negated bitShift: -1))
		ifFalse: [^ self inform: 'ERROR: Two-complement shifts of negative Integers are NOT consistent!'].
	(small bitShift: -1) ~= (small + 1 bitShift: -1)
		== ((large bitShift: -1) ~= (large + 1 bitShift: -1))
		ifFalse: [^ self inform: 'ERROR: Two-complement shifts of positive Integers are NOT consistent!'].
	^ self inform: 'OK: Two-complement shifts of small and large Integers are consistent!'.