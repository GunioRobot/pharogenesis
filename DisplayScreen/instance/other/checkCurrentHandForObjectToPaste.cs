checkCurrentHandForObjectToPaste

	| response |
	self flag: #bob.	
	World currentHand pasteBuffer ifNil: [^self].
	response _ (PopUpMenu labels: 'Delete\Keep' withCRs)
		startUpWithCaption: 'Hand is holding a Morph in its paste buffer:\' withCRs,
			World currentHand pasteBuffer printString.
	response = 1 ifTrue: [World currentHand pasteBuffer: nil].
