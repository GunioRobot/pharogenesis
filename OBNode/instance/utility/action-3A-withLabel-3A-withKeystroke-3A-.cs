action: aSelector withLabel: aString withKeystroke: aChar
	^ OBAction
		label: aString
		receiver: self
		selector: aSelector
		arguments: #()
		keystroke: aChar