VerifyColor: parameter
	"If the parameter is a valid color (triple or named color) this method returns true, otherwise it throws an exception"

	(parameter isKindOf: SequenceableCollection)
		ifTrue: [
			(((((parameter size) = 3)
				and: [ ((parameter at: 1) isNumber) and:
							[ ((parameter at: 1) >= 0) and: [ ((parameter at: 1) <= 1) ] ] ] )
				and: [ ((parameter at: 2) isNumber) and:
 							[ ((parameter at: 2) >= 0) and: [ ((parameter at: 2) <= 1) ] ] ] )
				and: [ ((parameter at: 3) isNumber) and:
							[ ((parameter at: 3) >= 0) and: [ ((parameter at: 3) <= 1) ] ] ] )
					ifTrue: [ ^ true ]
					ifFalse: [ [ Color perform: parameter. ]
								ifError: [ :msg : rcvr | self error: (parameter asString) ,
												' is not a valid color. '].
							  ^ true.
							].
  				]
		ifFalse: [ self error: (parameter asString) , ' is not a valid color. ' ].
