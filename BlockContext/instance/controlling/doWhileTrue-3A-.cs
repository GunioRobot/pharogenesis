doWhileTrue: conditionBlock
	"Evaluate the receiver once, then again as long the value of conditionBlock is true."
 
	| result |
	[result _ self value.
	conditionBlock value] whileTrue.

	^ result