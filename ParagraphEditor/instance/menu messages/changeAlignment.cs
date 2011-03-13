changeAlignment
	| aList reply  |
	aList := #(leftFlush centered justified rightFlush).
	reply := UIManager default chooseFrom: (aList collect: [:t | t translated]) values: aList.
	reply ifNil:[^self].
	self setAlignment: reply.
	paragraph composeAll.
	self recomputeSelection.
	^ true