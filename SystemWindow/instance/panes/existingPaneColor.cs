existingPaneColor
	| aColor |
	"Answer the existing pane color for the window, obtaining it from the first paneMorph if any, and fall back on using the second stripe color if necessary."

	paneMorphs isEmptyOrNil
		ifFalse:
			[((aColor _ paneMorphs first color) isKindOf: Color)
				ifTrue:
					[^ aColor]].
	^ stripes second color