arrowAction: delta
	"Do what is appropriate when an arrow on the tile is pressed; delta will be +1 or -1"

	| index aList |
	owner ifNil: [^ self].
	(type == #literal and: [literal isNumber])
		ifTrue:
			[self literal: literal + delta. ^ self layoutChanged.].

	(type == #literal and: [literal isKindOf: Boolean])
		ifTrue: [self literal: literal not.  ^ self layoutChanged].

	operatorOrExpression ifNotNil:
		[aList _ #(+ - * / // \\ min: max:).
		index _ aList indexOf: operatorOrExpression.
		index  > 0 ifTrue:
			[self setOperatorAndUseArrows: (aList atWrap: index + delta)].

		aList _ #(< <= = ~= > >= isDivisibleBy:).
		index _ aList indexOf: operatorOrExpression.
		index  > 0 ifTrue:
			[owner firstSubmorph type = #number 
				ifTrue: [self setOperator: (aList atWrap: index + delta)]
				ifFalse: [self setOperator: (#(= ~=) atWrap: index - 2 + delta)]].
						"Color does not understand <"
			submorphs last setBalloonText: (ScriptingSystem helpStringForOperator: operatorOrExpression).
			^ self acceptNewLiteral]
	