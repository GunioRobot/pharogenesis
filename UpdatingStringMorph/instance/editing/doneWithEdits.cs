doneWithEdits
	"If in a SyntaxMorph, shrink min width after editing"

	| editor |
	super doneWithEdits.
	(owner respondsTo: #parseNode) ifTrue: [minimumWidth _ 8].
	editor _ (submorphs detect: [ :sm | sm isKindOf: StringMorphEditor ] ifNone: [ ^self ]).
	editor delete.