nextCostume
	"The receiver's player is currently being viewed via a particular costume.  Now switch to a plausible different costume."

	| ind acn c |
	ind _ (acn _ scriptedPlayer availableCostumeNamesForArrows) indexOf: scriptedPlayer costume renderedMorph class name.
	ind _ ind + 1.
	ind > acn size ifTrue: [ind _ 1].
	scriptedPlayer costume:
		(c _ scriptedPlayer costumeNamed: (acn at: ind)) fullCopy.
	c isInWorld ifTrue: [self presenter updatePartsViewer: self]