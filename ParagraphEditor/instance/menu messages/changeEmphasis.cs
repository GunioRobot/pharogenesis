changeEmphasis
	| aList reply  |
	aList _ #(plain bold italic narrow underlined struckOut).
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[self setEmphasis: reply.
		paragraph composeAll.
		self recomputeSelection.
		self mvcRedisplay].
	^ true