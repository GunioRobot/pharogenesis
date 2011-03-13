setValueAtCursor: aPlayer
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #valueAtCursor:) ifTrue: [^ renderedMorph valueAtCursor: aPlayer costume].

	(costume respondsTo: #valueAtCursor:) ifTrue: [costume valueAtCursor: aPlayer costume]