setCursor: aNumber
	| aMorph |
	((aMorph _ costume renderedMorph) respondsTo: #cursor:) ifTrue: [^ aMorph cursor: aNumber].
	^ (self costumeNamed: #PasteUpMorph) cursor: aNumber