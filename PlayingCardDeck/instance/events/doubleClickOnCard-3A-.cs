doubleClickOnCard: aCard

	(target ~~ nil and: [cardDoubleClickSelector ~~ nil]) 
		ifTrue: [^ target perform: cardDoubleClickSelector with: self with: aCard]