newItalicButtonMorph
	"Answer a button for the italic emphasis of the font."
	
	^self
		newButtonFor: self
		getState: #isItalic
		action: #toggleItalic
		arguments: nil
		getEnabled: nil
		labelForm: self theme smallItalicIcon
		help: 'Toggle italic font' translated