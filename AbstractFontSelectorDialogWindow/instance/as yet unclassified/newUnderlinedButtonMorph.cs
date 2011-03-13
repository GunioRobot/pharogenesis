newUnderlinedButtonMorph
	"Answer a button for the italic emphasis of the font."
	
	^self
		newButtonFor: self
		getState: #isUnderlined
		action: #toggleUnderlined
		arguments: nil
		getEnabled: nil
		labelForm: self theme smallUnderlineIcon
		help: 'Toggle underlined font' translated