testTwoComplementRightShift
	| large small |
	small _ 2 << 16.
	large _ 2 << 32.
	
	self should: [(small negated bitShift: -1) ~= ((small + 1) negated bitShift: -1)
		== ((large negated bitShift: -1) ~= ((large + 1) negated bitShift: -1))].
		
     self should: [ (small bitShift: -1) ~= (small + 1 bitShift: -1)
		== ((large bitShift: -1) ~= (large + 1 bitShift: -1))].