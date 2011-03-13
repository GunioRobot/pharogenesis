keyboardFocusChange: aBoolean
	| hadFocus |
	owner ifNil: [ ^self ].
	hadFocus _ owner hasFocus.
	super keyboardFocusChange: aBoolean.
	aBoolean ifFalse:
		[hadFocus ifTrue:
			[owner lostFocusWithoutAccepting; doneWithEdits].
		^ self delete]