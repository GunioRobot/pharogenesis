checkCurrentHandForObjectToPaste2

	self flag: #bob.	
	World currentHand pasteBuffer ifNil: [^self].
	self inform: 'Hand is holding a Morph in its paste buffer:\' withCRs,
		World currentHand pasteBuffer printString.

