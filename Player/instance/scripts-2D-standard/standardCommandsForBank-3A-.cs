standardCommandsForBank: aBank
	"Return a list of typed-command arrays of the form:
		<result type> <command> <argType>" 

	(aBank = 1) ifTrue:
		[^ #((command forward: number)
			(command turn: number)
			(command wearCostumeOf: player)
			(command moveToward: player)
			(command beep: sound))].

	(aBank = 2) ifTrue:
		[^ #((command show)
			(command hide)
			(command bounce: sound)
			(command wrap)
			(command goToRightOf: player)
			(command stopProgramatically))].

	(aBank == 3 and: [costume isKindOf: PasteUpMorph]) ifTrue:
		[^ #((command goToNextCard)
			(command goToPreviousCard)
			(command newCard)
			(command deleteCard))].

	^ #()