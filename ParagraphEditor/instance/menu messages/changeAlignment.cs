changeAlignment
	| aList reply  |
	aList _ #(leftFlush centered justified rightFlush).
	reply _ (SelectionMenu labelList: aList selections: aList) startUp.
	reply ~~ nil ifTrue:
		[paragraph perform: reply.
		paragraph composeAll.
		self recomputeSelection.
		self mvcRedisplay].
	^ true