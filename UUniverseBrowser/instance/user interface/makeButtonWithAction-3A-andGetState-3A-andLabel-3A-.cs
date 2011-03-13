makeButtonWithAction: selector andGetState: getStateSelector andLabel: aString
	^(PluggableButtonMorph on: self getState: getStateSelector action: selector)
		label: aString;
		useRoundedCorners;
		vResizing: #spaceFill;
		hResizing: #spaceFill;
		onColor: self defaultBackgroundColor offColor: self defaultBackgroundColor muchLighter;
		yourself