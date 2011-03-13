action: aSelector buttonLabel: buttonString menuLabel: menuString
	^ OBAction
		label: menuString
		buttonLabel: buttonString
		receiver: self
		selector: aSelector
		arguments: #()