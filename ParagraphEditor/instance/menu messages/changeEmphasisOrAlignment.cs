changeEmphasisOrAlignment
	| aList reply  |
	aList := #(normal bold italic narrow underlined struckOut leftFlush centered rightFlush justified).
	reply := UIManager default chooseFrom: (aList collect: [:t | t translated]) values: aList lines: #(6).
	reply ~~ nil ifTrue:
		[(#(leftFlush centered rightFlush justified) includes: reply)
			ifTrue:
				[paragraph perform: reply.
				self recomputeInterval]
			ifFalse:
				[self setEmphasis: reply.
				paragraph composeAll.
				self recomputeSelection.
				]].
	^ true