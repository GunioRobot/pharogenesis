retractableOrNot  "Change scroll bar operation"
	retractableScrollBar _ retractableScrollBar not.
	retractableScrollBar
		ifTrue: [self privateRemoveMorph: scrollBar]
		ifFalse: [(submorphs includes: scrollBar) 
					ifFalse: [self privateAddMorph: scrollBar atIndex: 1]].
	self extent: self extent