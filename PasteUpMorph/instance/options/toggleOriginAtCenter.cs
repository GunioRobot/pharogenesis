toggleOriginAtCenter
	| hasIt |
	hasIt _ self hasProperty: #originAtCenter.
	hasIt
		ifTrue:
			[self removeProperty: #originAtCenter]
		ifFalse:
			[self setProperty: #originAtCenter toValue: true]