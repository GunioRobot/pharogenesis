makeCapitalized: characterStream 
	"Force the current selection to uppercase.  Triggered by Cmd-X."
	| prev |
	sensor keyboard.		"flush the triggering cmd-key character"
	prev _ $-.  "not a letter"
	self replaceSelectionWith: (Text fromString:
			(self selection string collect:
				[:c | prev _ prev isLetter ifTrue: [c asLowercase] ifFalse: [c asUppercase]])).
	^ true