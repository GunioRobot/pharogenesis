upHeap: anIndex
	"Check the heap upwards for correctness starting at anIndex.
	 Everything below anIndex is ok."
	| value k kDiv2 tmp |
	anIndex = 0 ifTrue:[^self].
	k _ anIndex.
	value _ array at: anIndex.
	[ (k > 1) and:[self sorts: value before: (tmp _ array at: (kDiv2 _ k bitShift: -1))] ] 
		whileTrue:[
			array at: k put: tmp.
			self updateObjectIndex: k.
			k _ kDiv2].
	array at: k put: value.
	self updateObjectIndex: k.