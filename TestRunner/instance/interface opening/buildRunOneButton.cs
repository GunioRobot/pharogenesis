buildRunOneButton
	| runOneButton |
	runOneButton _ PluggableButtonMorph
				on: self
				getState: #runButtonState
				action: #runOneTest
				label: #runOneButtonLabel.
	runOneButton color: self runButtonColor;
		 hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 useRoundedCorners.
	runOneButton onColor: self runButtonColor offColor: self runButtonOffColor.
	^ runOneButton