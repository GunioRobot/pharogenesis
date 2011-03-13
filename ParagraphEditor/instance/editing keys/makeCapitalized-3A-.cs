makeCapitalized: characterStream 
	"Force the current selection to be capitalized. Triggered by Cmd-Z."
	| prev |
	sensor keyboard.		"Flush the triggering cmd-key character"
	prev _ $-.  "not a letter"
	self replaceSelectionWith: (Text fromString:
			(self selection string collect:
				[:c | prev _ prev isLetter ifTrue: [c asLowercase] ifFalse: [c asUppercase]])).
	^ true