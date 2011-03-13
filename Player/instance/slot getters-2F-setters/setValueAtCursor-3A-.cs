setValueAtCursor: aPlayer
	| renderedMorph aCostume |
	aCostume _ self costume.
	((renderedMorph _ aCostume renderedMorph) respondsTo: #valueAtCursor:) ifTrue: [^ renderedMorph valueAtCursor: aPlayer costume].

	(aCostume respondsTo: #valueAtCursor:) ifTrue: [aCostume valueAtCursor: aPlayer costume]