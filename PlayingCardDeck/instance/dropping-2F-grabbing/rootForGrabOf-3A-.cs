rootForGrabOf: aCard

	self hasSubmorphs ifFalse: [^ nil].
	(target ~~ nil and: [cardDraggedSelector ~~ nil]) 
		ifTrue: [^target perform: cardDraggedSelector with: aCard with: self]
		ifFalse: [^self firstSubmorph]