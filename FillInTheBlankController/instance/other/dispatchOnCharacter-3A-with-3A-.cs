dispatchOnCharacter: char with: typeAheadStream
	"Accept the current input if the user hits the carriage return or the enter key."

	(model acceptOnCR and:
	 [(char = Character cr) | (char = Character enter)])
		ifTrue: [
			sensor keyboard.  "absorb the character"
			self accept.
			^ true]
		ifFalse: [
			^ super dispatchOnCharacter: char with: typeAheadStream].
