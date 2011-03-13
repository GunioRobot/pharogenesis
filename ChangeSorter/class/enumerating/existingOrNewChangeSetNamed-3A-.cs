existingOrNewChangeSetNamed: aName

	| newSet |

	^(self changeSetNamed: aName) ifNil: [
		newSet _ ChangeSet new initialize name: aName.
		AllChangeSets add: newSet.
		newSet
	]