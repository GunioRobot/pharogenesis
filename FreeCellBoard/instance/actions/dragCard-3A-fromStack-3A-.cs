dragCard: aCard fromStack: aCardDeck
	| i cards |

	cards _ aCardDeck cards.
	i _ cards indexOf: aCard ifAbsent: [^ nil].
	i > (self maxDraggableStackSize: false) ifTrue: [^ nil].
	[i > 1] whileTrue:
		[(aCardDeck inStackingOrder: (cards at: i-1) 
					onTopOf: (cards at: i)) ifFalse: [^ nil].
		i _ i-1].
	^ aCard