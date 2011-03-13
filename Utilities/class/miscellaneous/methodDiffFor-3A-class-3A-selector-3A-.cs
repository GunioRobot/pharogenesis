methodDiffFor: aString class: aClass selector: aSelector 
	^ (aClass includesSelector: aSelector)
		ifTrue: [TextDiffBuilder
				buildDisplayPatchFrom: (aClass sourceCodeAt: aSelector)
				to: aString
inClass: aClass]
		ifFalse: [aString copy]