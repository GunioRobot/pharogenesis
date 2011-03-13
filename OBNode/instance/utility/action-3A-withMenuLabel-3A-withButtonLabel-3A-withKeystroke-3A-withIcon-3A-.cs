action: aSelector withMenuLabel: aString withButtonLabel: aString2 withKeystroke: aChar withIcon: anIcon 
	^OBAction 
		label: aString
		buttonLabel: aString2
		receiver: self
		selector: aSelector
		arguments: #()
		keystroke: aChar
		icon: anIcon