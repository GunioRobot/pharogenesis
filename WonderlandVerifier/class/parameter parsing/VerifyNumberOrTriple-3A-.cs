VerifyNumberOrTriple: parameter
	"If the parameter is a number or a valid triple this method returns true, otherwise it throws an exception"

	((parameter isNumber) or: [(((((parameter isKindOf: SequenceableCollection)
			and: [ (parameter size) = 3 ] )
			and: [ ((parameter at: 1) isNumber) ] )
			and: [ ((parameter at: 2) isNumber) ] )
 			and: [ ((parameter at: 3) isNumber) ] ) ])
 				ifTrue: [ ^ true ]
				ifFalse: [ self error: (parameter asString) , ' is not a number or triple. ' ].
