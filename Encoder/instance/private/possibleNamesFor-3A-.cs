possibleNamesFor: proposedName
	| results |
	results := class possibleVariablesFor: proposedName continuedFrom: nil.
	^ proposedName correctAgainst: nil continuedFrom: results.
