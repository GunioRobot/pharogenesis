dispatchOnCharacter: char with: typeAheadStream
	"Accept and terminate the interation if the user hits a CR or the enter key."

	(char = Character cr) | (char = Character enter)
		ifTrue:
			[sensor keyboard.  "gobble the character"
			self accept.
			^ true]
		ifFalse:
			[^ super dispatchOnCharacter: char with: typeAheadStream].
