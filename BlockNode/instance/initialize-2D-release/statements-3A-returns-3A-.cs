statements: statementsCollection returns: returnBool 
	"Decompile."

	| returnLast |
	returnLast _ returnBool.
	returns _ false.
	statements _ 
		(statementsCollection size > 1 
			and: [(statementsCollection at: statementsCollection size - 1) 
					isReturningIf])
				ifTrue: 
					[returnLast _ false.
					statementsCollection allButLast]
				ifFalse: [statementsCollection size = 0
						ifTrue: [Array with: NodeNil]
						ifFalse: [statementsCollection]].
	arguments _ Array new: 0.
	returnLast ifTrue: [self returnLast]