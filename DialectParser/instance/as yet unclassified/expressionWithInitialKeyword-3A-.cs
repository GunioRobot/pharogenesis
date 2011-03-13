expressionWithInitialKeyword: kwdIfAny

	| checkpoint |
	(hereType == #word and: [here = 'Set' and: [tokenType == #word]]) ifTrue:
			["Parse assignment statement 'Set' var 'to' expression"
			checkpoint _ self checkpoint.
			self advance.
			token = 'to'
				ifTrue: [^ self assignment: self variable]
				ifFalse: [self revertToCheckpoint: checkpoint]].
	self matchKeyword
		ifTrue: ["It's an initial keyword."
				kwdIfAny isEmpty ifFalse: [self error: 'compiler logic error'].
				^ self expressionWithInitialKeyword: ':' , self advance , ':'].
	hereType == #leftBrace
		ifTrue: [self braceExpression]
		ifFalse: [self primaryExpression ifFalse: [^ false]].
	(self messagePart: 3 repeat: true initialKeyword: kwdIfAny)
		ifTrue: [hereType == #semicolon ifTrue: [self cascade]].
	^ true