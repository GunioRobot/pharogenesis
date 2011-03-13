goToCard
	"prompt the user for an ordinal number, and use that as a basis for choosing a new card to install in the receiver"

	| reply index |
	reply _ FillInTheBlank request: 'Which card number? ' initialAnswer: '1'.
	reply isEmptyOrNil ifTrue: [^ self].
	((index _ reply asNumber) > 0 and: [index <= cards size])
		ifFalse: [^ self inform: 'no such card'].
	self goToCard: (cards at: index)