buildRefreshButton
	| refreshButton |
	refreshButton _ PluggableButtonMorph
				on: self
				getState: #refreshButtonState
				action: #refreshTests
				label: #refreshButtonLabel.
	refreshButton color: self runButtonColor;
		 hResizing: #spaceFill;
		 vResizing: #spaceFill;
		 useRoundedCorners.
	refreshButton onColor: self runButtonColor offColor: self runButtonColor.
	^ refreshButton