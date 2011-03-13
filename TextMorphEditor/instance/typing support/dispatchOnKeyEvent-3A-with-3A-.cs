dispatchOnKeyEvent: keyEvent with: typeAheadStream
	"Carry out the action associated with this character, if any.
	Type-ahead is passed so some routines can flush or use it."

	((keyEvent keyCharacter = Character cr) and: [morph acceptOnCR])
		ifTrue: [
			self closeTypeIn.
			^ true].

	^ super dispatchOnKeyEvent: keyEvent with: typeAheadStream