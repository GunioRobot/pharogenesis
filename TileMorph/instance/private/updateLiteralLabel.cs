updateLiteralLabel

	| myLabel |
	(myLabel _ self labelMorph) ifNil: [^ self].

	myLabel acceptValue:
		(type == #literal
			ifTrue:
				[literal] 
			ifFalse: [operatorReadoutString 
				ifNil:		[ScriptingSystem wordingForOperator: operatorOrExpression]
				ifNotNil:  	[operatorReadoutString]]).
	self changed.