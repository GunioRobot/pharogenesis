methodDiffFor: aString class: aPseudoClass selector: selector meta: meta 
	| theClass source |
	theClass _ Smalltalk
				at: aPseudoClass name
				ifAbsent: [^ aString copy].
	meta
		ifTrue: [theClass _ theClass class].
	(theClass includesSelector: selector)
		ifFalse: [^ aString copy].
	source _ theClass sourceCodeAt: selector.
	^ Cursor wait
		showWhile: [TextDiffBuilder buildDisplayPatchFrom: source to: aString inClass: theClass]