getValueFromCostume: aSelector
	| aCostume |
	(aCostume _ self costumeRespondingTo: aSelector) ifNotNil:
		[^ aCostume perform: aSelector].
	^ nil