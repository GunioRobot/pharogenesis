diffFromPriorSourceFor: sourceCode
	| prior |
	"If there is a prior version of source for the selected method, return a diff, else just return the source code"

	^ (prior _ self priorSourceOrNil)
		ifNil:
			[sourceCode]
		ifNotNil:
			[TextDiffBuilder buildDisplayPatchFrom: prior to: sourceCode]