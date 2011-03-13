deleteCard
	"Delete the current card from the stack"

	| aCard |
	aCard _ self currentCard.
	cards size = 1 ifTrue: [^ self beep].
	(self confirm: 'Really delete this card and all of its data?') ifTrue: [
		self goToNextCardInStack.
		cards remove: aCard].