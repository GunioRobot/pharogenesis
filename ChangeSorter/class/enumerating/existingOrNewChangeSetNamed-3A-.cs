existingOrNewChangeSetNamed: aName

	| newSet |

	^(self changeSetNamed: aName) ifNil: [
		newSet _ ChangeSet basicNewNamed: aName.
		AllChangeSets add: newSet.
		newSet
	]