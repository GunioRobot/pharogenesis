action: aSelector withLabel: aString withKeystroke: aChar withIcon: anIcon
	^ OBAction
		label: aString
		receiver: self
		selector: aSelector
		arguments: #()
		keystroke: aChar
		icon: anIcon