newBoldButtonMorph
	"Answer a button for the boldness of the font."
	
	^self
		newButtonFor: self
		getState: #isBold
		action: #toggleBold
		arguments: nil
		getEnabled: nil
		labelForm: self theme smallBoldIcon
		help: 'Toggle bold font' translated