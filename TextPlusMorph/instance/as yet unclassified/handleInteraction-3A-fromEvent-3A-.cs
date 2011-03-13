handleInteraction: interactionBlock fromEvent: evt
	
	super handleInteraction: interactionBlock fromEvent: evt.
	scrollerOwner ifNil: [^self].
	scrollerOwner scrollSelectionIntoView: nil alignTop: false.