printOn: aStream
	| cards |
	cards _ self cards.
	aStream nextPutAll: 'aCardDeck('.
	cards size > 1 
		ifTrue: [
			cards allButLast do: [:card |
				aStream
					print: card;
					nextPutAll: ', ']].
	cards size > 0 ifTrue: [aStream print: cards last].
	aStream nextPut: $).