changeEmphasisOrAlignment
	| aList reply  |
	aList _ #(normal bold italic narrow underlined struckOut leftFlush centered rightFlush justified).
	reply _ (SelectionMenu labelList: aList lines: #(6) selections: aList) startUp.
	reply ~~ nil ifTrue:
		[(#(leftFlush centered rightFlush justified) includes: reply)
			ifTrue:
				[paragraph perform: reply.
				self recomputeInterval]
			ifFalse:
				[self setEmphasis: reply.
				paragraph composeAll.
				self recomputeSelection.
				self mvcRedisplay]].
	^ true