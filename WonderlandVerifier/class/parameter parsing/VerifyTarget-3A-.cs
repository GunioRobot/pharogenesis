VerifyTarget: parameter
	"If the parameter is a valid target (triple or kind of WonderlandActor) this method returns true, otherwise it throws an exception"

	((parameter isKindOf: WonderlandActor)
		or: 	[ ((((parameter isKindOf: SequenceableCollection)
				and: [ (parameter size) = 3 ] )
				and: [ ((parameter at: 1) isNumber) or: [ (parameter at: 1) = asIs ] ] )
				and: [ ((parameter at: 2) isNumber) or: [ (parameter at: 2) = asIs ] ] )
 				and: [ ((parameter at: 3) isNumber) or: [ (parameter at: 3) = asIs ] ]
  			])
				ifTrue: [ ^ true ]
				ifFalse: [ self error: (parameter asString) , ' is not a valid target. ' ].
