arrowAction: delta
	"Figure out what to do when the up or down arrow is pressed.
	May be overridden in subclasses"
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
			^ self acceptNewLiteral]
	