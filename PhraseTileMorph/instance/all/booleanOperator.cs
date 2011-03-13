booleanOperator
	| op |
	"If the receiver represents a boolean value, return the associated operator; if not, return nil"

	submorphs size < 2 ifTrue: [^ nil].
	(op _ submorphs second) type == #operator ifFalse: [^ nil].
	^ (#(< <= = == ~= > >= ~~) includes: op operatorOrExpression)
		ifTrue:
			[op operatorOrExpression]
		ifFalse:
			[nil]