VerifyCondition: parameter
	"If the parameter is a valid style (BlockContext that takes 1 parameter and returns a boolean) this method returns true, otherwise it throws an exception"

	| result | 

	[ result _ ((parameter value) isKindOf: Boolean) ] 
		ifError: [ :msg :rcvr |
					self error: 'your condition must be a block that returns true or false.' ].

	(result) ifTrue: [ ^ true ]
			ifFalse: [ self error: 'your condition does not return true or false. '].
