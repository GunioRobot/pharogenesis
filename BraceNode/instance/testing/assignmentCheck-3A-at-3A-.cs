assignmentCheck: encoder at: location

	| loc |
	elements do:
		[:element |
		(loc _ element assignmentCheck: encoder at: location) >= 0 ifTrue: [^loc]].
	^-1