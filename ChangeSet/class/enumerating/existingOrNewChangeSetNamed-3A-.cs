existingOrNewChangeSetNamed: aName

	| newSet |
	^(self named: aName) ifNil: [
		newSet _ self basicNewNamed: aName.
		AllChangeSets add: newSet.
		newSet
	]