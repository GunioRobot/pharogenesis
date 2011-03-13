scrollSelectionToTop

	scrollerOwner ifNil: [^self].
	scrollerOwner scrollSelectionIntoView: nil alignTop: true.
