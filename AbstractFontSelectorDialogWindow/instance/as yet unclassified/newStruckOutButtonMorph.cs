newStruckOutButtonMorph
	"Answer a button for the struck out emphasis of the font."
	
	^self
		newButtonFor: self
		getState: #isStruckOut
		action: #toggleStruckOut
		arguments: nil
		getEnabled: nil
		labelForm: self theme smallStrikeOutIcon
		help: 'Toggle struck-out font' translated