addCustomMenuItems: aCustomMenu hand: aHandMorph

	super addCustomMenuItems: aCustomMenu hand: aHandMorph.
	aCustomMenu addLine.
	aCustomMenu add: 'make a flex morph' selector: #makeFlexMorphFor: argument: aHandMorph.
	flipOnClick
		ifTrue: [aCustomMenu add: 'disable bookmark action' action: #toggleBookmark]
		ifFalse: [aCustomMenu add: 'enable bookmark action' action: #toggleBookmark].
	(bookMorph isKindOf: BookMorph)
		ifTrue:
			[aCustomMenu add: 'set page sound' action: #setPageSound:.
			aCustomMenu add: 'set page visual' action: #setPageVisual:]
