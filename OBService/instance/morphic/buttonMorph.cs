buttonMorph
	^ (PluggableButtonMorph
		on: self
		getState: nil
		action: #trigger
		label: #buttonLabelMorph)	
			onColor: Color lightGray lighter offColor: Color lightGray twiceLighter;
			borderWidth: 2;
			borderRaised;
			hResizing: #spaceFill;
			vResizing: #spaceFill;
			setBalloonText: label