action: aSelector withLabel: aString
	^ OBAction
		label: aString
		receiver: self
		selector: aSelector
		arguments: #()