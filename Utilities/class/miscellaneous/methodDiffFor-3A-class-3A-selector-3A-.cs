methodDiffFor: aString class: aClass selector: aSelector
	^ (aClass includesSelector: aSelector)
		ifFalse:
			[aString copy]
		ifTrue:
			[TextDiffBuilder buildDisplayPatchFrom: (aClass sourceCodeAt: aSelector) to: aString]