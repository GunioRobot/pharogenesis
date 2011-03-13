jumpToDocumentTop

	self editor selectFrom: 1 to: 0.
	self changed.
	scrollerOwner ifNil: [^self].
	scrollerOwner scrollSelectionIntoView: nil alignTop: true.
