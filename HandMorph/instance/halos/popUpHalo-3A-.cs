popUpHalo: evt
	"Pop up a halo on the top-most unlocked morph below the hand."

	self world abandonAllHalos.
	targetOffset _ self position.
	(argument _ self argumentOrNil) ifNil: [^ self].
	argument submorphCount > 0 ifTrue:
		[(argument _ self chooseHaloSubmorphOf: argument caption: 'Who gets halo?')
			ifNil: [^ self]].
	self addHalo.
