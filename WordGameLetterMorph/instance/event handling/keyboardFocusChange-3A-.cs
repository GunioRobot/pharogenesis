keyboardFocusChange: boolean

	| panel |
	boolean ifFalse:
		[panel _ self nearestOwnerThat: [:m | m respondsTo: #checkForLostFocus].
		panel ifNotNil: [panel checkForLostFocus]]