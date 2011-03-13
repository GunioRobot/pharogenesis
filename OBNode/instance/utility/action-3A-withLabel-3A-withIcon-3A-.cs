action: aSelector withLabel: aString withIcon: anIcon
	^ OBAction
		label: aString
		receiver: self
		selector: aSelector
		arguments: #()
		icon: anIcon