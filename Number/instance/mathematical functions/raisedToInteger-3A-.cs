raisedToInteger: operand 
	"Answer the receiver raised to the power operand, an Integer."
	| count result |
	#Numeric.
	"Changed 200/01/19 For ANSI <number> support."
	operand isInteger ifFalse: [^ ArithmeticError signal: 'parameter is not an Integer'"<- Chg"].
	operand = 0 ifTrue: [^ self class one].
	operand = 1 ifTrue: [^ self].
	operand < 0 ifTrue: [^ (self raisedToInteger: operand negated) reciprocal].
	count := 1.
	[(count := count + count) < operand] whileTrue.
	result := self class one.
	[count > 0]
		whileTrue: 
			[result := result * result.
			(operand bitAnd: count)
				= 0 ifFalse: [result := result * self].
			count := count bitShift: -1].
	^ result