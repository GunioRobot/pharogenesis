= other
	| otherRuns |
	^ other isText
		ifTrue:	["This is designed to run fast even for megabytes"
				otherRuns _ other asText runs.
				(string == other string or: [string = other string])
					and: [runs == otherRuns or: [runs = otherRuns]]]
		ifFalse: [false]