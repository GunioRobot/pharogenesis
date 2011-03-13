makeButtonWithAction: selector andGetState: getStateSelector andLabel: aString for: model
	^(PluggableButtonMorph on: model getState: getStateSelector action: selector)
		label: aString;
		useRoundedCorners;
		vResizing: #spaceFill;
		hResizing: #spaceFill;
		onColor: model defaultBackgroundColor offColor: model defaultBackgroundColor muchLighter;
		yourself