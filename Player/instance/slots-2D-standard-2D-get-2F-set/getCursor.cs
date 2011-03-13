getCursor
	| aMorph |
	((aMorph _ costume renderedMorph) respondsTo: #cursor) ifTrue: [^ aMorph cursor].
	^ (self costumeNamed: #PasteUpMorph) cursor