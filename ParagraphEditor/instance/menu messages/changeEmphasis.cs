changeEmphasis
	| aList reply  |
	aList _ #(normal bold italic narrow underlined struckOut).
	reply _ (SelectionMenu labelList: (aList collect: [:t | t translated]) selections: aList) startUp.
	reply ~~ nil ifTrue:
		[self setEmphasis: reply.
		paragraph composeAll.
		self recomputeSelection.
		self mvcRedisplay].
	^ true