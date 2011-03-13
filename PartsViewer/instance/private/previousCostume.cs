previousCostume
	"The receiver's player is currently being viewed via a particular costume.  Now switch to a plausible different costume."

	| ind acn c |
	ind _ (acn _ scriptedPlayer availableCostumeNamesForArrows) indexOf: scriptedPlayer costume renderedMorph class name.
	ind _ ind - 1.
	ind < 1 ifTrue: [ind _ acn size].
	scriptedPlayer costume:
		(c _ scriptedPlayer costumeNamed: (acn at: ind)) fullCopy.
	c isInWorld ifTrue: [self presenter updatePartsViewer: self]