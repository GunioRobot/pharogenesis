buttonWithState: getState action: action label: buttonLabel
	^ (PluggableButtonMorph on: self getState: getState action: action)
			label: buttonLabel;
			onColor: Color white darker darker
			offColor: Color white;
			borderWidth: 0;
			borderRaised;
			hResizing: #spaceFill;
			vResizing: #spaceFill.