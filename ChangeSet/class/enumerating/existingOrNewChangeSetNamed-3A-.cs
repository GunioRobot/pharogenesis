existingOrNewChangeSetNamed: aName

	| newSet |
	^(self named: aName) ifNil: [
		newSet := self basicNewNamed: aName.
		AllChangeSets add: newSet.
		newSet
	]