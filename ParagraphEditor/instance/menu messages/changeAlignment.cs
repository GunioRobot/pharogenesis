changeAlignment
	| aList reply  |
	aList _ #(leftFlush centered justified rightFlush).
	reply _ (SelectionMenu labelList: (aList collect: [:t | t translated]) selections: aList) startUp.
	reply ifNil:[^self].
	self setAlignment: reply.
	paragraph composeAll.
	self recomputeSelection.
	self mvcRedisplay.
	^ true