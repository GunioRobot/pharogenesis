methodDiffFor: aString class: aPseudoClass selector: selector meta: meta 
	"Answer the diff between the current copy of the given class/selector/meta for the string provided"

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
		showWhile: [TextDiffBuilder buildDisplayPatchFrom: source to: aString inClass: theClass prettyDiffs: self showingPrettyDiffs]