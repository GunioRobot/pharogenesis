checkCurrentHandForObjectToPaste2

	self primaryHand pasteBuffer ifNil: [^self].
	self inform: 'Hand is holding a Morph in its paste buffer:\' withCRs,
		self primaryHand pasteBuffer printString.

