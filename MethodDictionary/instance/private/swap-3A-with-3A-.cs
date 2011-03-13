swap: oneIndex with: otherIndex
	| element |
	element _ self basicAt: oneIndex.
	self basicAt: oneIndex put: (self basicAt: otherIndex).
	self basicAt: otherIndex put: element.
	super swap: oneIndex with: otherIndex.
