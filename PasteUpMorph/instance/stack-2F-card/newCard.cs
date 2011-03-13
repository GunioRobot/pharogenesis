newCard
	"Create a new card for the receiver and return it"

	| aNewInstance |
	self isStackBackground ifFalse: [^ self beep].  "bulletproof against deconstruction"
	aNewInstance _ self player class baseUniclass new.
	^ aNewInstance