changeEmphasis
	| aList reply  |
	aList := #(normal bold italic narrow underlined struckOut).
	reply := UIManager default chooseFrom: (aList collect: [:t | t translated]) values: aList.
	reply ifNotNil: [
		self setEmphasis: reply.
		paragraph composeAll.
		self recomputeSelection].
	^ true