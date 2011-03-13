currentHand

	self flag: #bob.		"need to do a better job here"
	^ (self outermostWorldMorph ifNil: [^ super currentHand]) primaryHand