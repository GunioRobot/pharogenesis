checkCurrentHandForObjectToPaste

	| response |
	self primaryHand pasteBuffer ifNil: [^self].
	response _ (PopUpMenu labels: 'Delete\Keep' withCRs)
		startUpWithCaption: 'Hand is holding a Morph in its paste buffer:\' withCRs,
			self primaryHand pasteBuffer printString.
	response = 1 ifTrue: [self primaryHand pasteBuffer: nil].
