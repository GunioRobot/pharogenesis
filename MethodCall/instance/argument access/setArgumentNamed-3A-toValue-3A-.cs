setArgumentNamed: aName toValue: aValue
	"Set the argument of the given name to the given value"

	| anIndex |
	anIndex _ self methodInterface argumentVariables findFirst:
		[:aVariable | aVariable variableName = aName].
	anIndex > 0
		ifTrue:
			[arguments at: anIndex put: aValue]
		ifFalse:
			[self error: 'argument missing'].
	self changed: #argumentValue