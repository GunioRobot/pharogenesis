buildRunButton
	| runButton |
	runButton _ PluggableButtonMorph
				on: self
				getState: #runButtonState
				action: #runTests
				label: #runButtonLabel.
	runButton color: self runButtonColor;
		 hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 useRoundedCorners.
	runButton onColor: self runButtonColor offColor: self runButtonOffColor.
	^ runButton