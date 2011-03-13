deleteCard: aCard
	"Delete the current card from the stack."

	cards size = 1 ifTrue: [^ self beep].
	(aCard == self currentCard) ifTrue: [^ self deleteCard].

	cards remove: aCard ifAbsent: []