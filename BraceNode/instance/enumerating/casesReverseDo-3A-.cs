casesReverseDo: aBlock
	"For each case in reverse order, evaluate aBlock with three arguments:
	 the key block, the value block, and whether it is the last case."

	| numCases case |
	(numCases _ elements size) to: 1 by: -1 do:
		[:i |
		case _ elements at: i.
		aBlock value: case receiver value: case arguments first value: i=numCases]