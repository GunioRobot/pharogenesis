buildStopButton
	| stopButton |
	stopButton _ PluggableButtonMorph
				on: self
				getState: #stopButtonState
				action: #terminateRun
				label: #stopButtonLabel.
	stopButton color: self runButtonColor;
		hResizing: #spaceFill; vResizing: #spaceFill;
		 useRoundedCorners.
	stopButton onColor: self runButtonColor offColor: self runButtonOffColor.
	^ stopButton