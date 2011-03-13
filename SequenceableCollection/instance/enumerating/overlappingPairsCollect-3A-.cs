overlappingPairsCollect: aBlock 
	"Answer the result of evaluating aBlock with all of the overlapping pairs of my elements."
	| retval |
	retval _ self species new: self size - 1.
	1 to: self size - 1
		do: [:i | retval at: i put: (aBlock value: (self at: i) value: (self at: i + 1)) ].
	^retval