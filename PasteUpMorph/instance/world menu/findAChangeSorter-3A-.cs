findAChangeSorter: evt
	"Locate a change sorter, open it, and bring it to the front.  Create one if necessary.  Only works in morphic, initially, probably"

	| aWindow |
	submorphs do:
		[:aMorph | (((aWindow _ aMorph renderedMorph) isKindOf: SystemWindow) and:
			[aWindow model isKindOf: ChangeSorter orOf: DualChangeSorter])
				ifTrue:
					[aWindow isCollapsed ifTrue: [aWindow expand].
					aWindow activateAndForceLabelToShow.
					^ self]].
	"None found, so create one"
	DualChangeSorter open