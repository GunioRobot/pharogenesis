downHeap: anIndex
	"Check the heap downwards for correctness starting at anIndex.
	 Everything above (i.e. left of) anIndex is ok."
	| value k n j |
	anIndex = 0 ifTrue:[^self].
	n _ tally bitShift: -1.
	k _ anIndex.
	value _ array at: anIndex.
	[k <= n] whileTrue:[
		j _ k + k.
		"use max(j,j+1)"
		(j < tally and:[self sorts: (array at: j+1) before: (array at: j)])
				ifTrue:[ j _ j + 1].
		"check if position k is ok"
		(self sorts: value before: (array at: j)) 
			ifTrue:[	"yes -> break loop"
					n _ k - 1]
			ifFalse:[	"no -> make room at j by moving j-th element to k-th position"
					array at: k put: (array at: j).
					"and try again with j"
					k _ j]].
	array at: k put: value.