newColorPickerButtonMorph
	"Answer a button to enable picking of colour."

	^self
		newButtonFor: self
		getState: nil
		action: #pickColor
		arguments: nil
		getEnabled: nil
		labelForm: ((ScriptingSystem formAtKey: #Eyedropper)
						scaledIntoFormOfSize: 16)
		help: 'Pick a colour from the screen' translated