dispatchOnCharacter: char with: typeAheadStream
	"Carry out the action associated with this character, if any.
	Type-ahead is passed so some routines can flush or use it."

	((char == Character cr) and: [morph acceptOnCR])
		ifTrue:
			[sensor keyboard.  "Gobble cr -- probably unnecessary."
			self closeTypeIn.
			^ true].

	^ super dispatchOnCharacter: char with: typeAheadStream