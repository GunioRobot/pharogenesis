testDefinitionString
	| d |
	d _ self mockClassA asClassDefinition.
	self assert: d definitionString = self mockClassA definition.