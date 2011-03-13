possibleNamesFor: proposedName
	| results |
	results _ class possibleVariablesFor: proposedName continuedFrom: nil.
	^ proposedName correctAgainst: nil continuedFrom: results.
