makeCapitalized: characterStream 
	"Force the current selection to be capitalized. Triggered by Cmd-Z."
	| prev |
prev := $-.  "not a letter"
	self replaceSelectionWith: (Text fromString:
			(self selection string collect:
				[:c | prev := prev isLetter ifTrue: [c asLowercase] ifFalse: [c asUppercase]])).
	^ true