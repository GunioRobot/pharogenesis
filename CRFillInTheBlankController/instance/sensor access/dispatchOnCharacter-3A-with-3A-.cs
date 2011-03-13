dispatchOnCharacter: char with: typeAheadStream
	"Check for CR and cause an ACCEPT"

	(char = Character cr) | (char = Character enter)
		ifTrue: [sensor keyboard. 	"gobble cr"
				self replaceSelectionWith:
					(Text string: typeAheadStream contents
						emphasis: emphasisHere).
				self accept.
				^ true]
		ifFalse: [^ super dispatchOnCharacter: char with: typeAheadStream]